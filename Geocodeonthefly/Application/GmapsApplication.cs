using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Geocodeonthefly.Domain;
using Geocodeonthefly.Infrastructure.Log;
using Newtonsoft.Json;

namespace Geocodeonthefly.Application
{
    public class GmapsApplication
    {
        private readonly string _requestUri;
        private readonly Log _logger;
        
        public GmapsApplication()
        {
            _requestUri = "https://maps.googleapis.com/maps/api/geocode/json?address={0}&key=" + Helpers.GetAppSetting("gmaps-api-key") + "&sensor=false";
            _logger = new Log();
        }

        public async Task<IList<Address>> GetGeocodesAsync(IList<Address> addresses)
        {
            using (var client = new HttpClient())
            {
                var tasks = new List<Task>();

                // Let's see how fast It is!
                var watch = Stopwatch.StartNew();
                
                foreach (var address in addresses)
                {
                    // {street}, {number}, {neighborhood}, {city} - {state}, {postalCode}, {country}
                    var addressString = string.Format("{0}, {1}, {2}, {3} - {4}, {5}, {6}",
                        address.Street,
                        address.Number,
                        address.Neighborhood,
                        address.City,
                        address.State,
                        address.Postalcode,
                        address.Country);

                    var formatedUri = string.Format(_requestUri, addressString);

                    tasks.Add(client.GetAsync(formatedUri).ContinueWith(async t =>
                    {
                        var content = await t.Result.Content.ReadAsStringAsync();
                        dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(content);

                        try
                        {
                            address.Lat = jsonResponse.results[0].geometry.location.lat;
                            address.Lng = jsonResponse.results[0].geometry.location.lng;
                        }
                        catch
                        {
                            _logger.GmapsError(formatedUri, (int)t.Result.StatusCode, content);
                        };
                        
                    }));

                    Thread.Sleep(25);
                }
                
                await Task.WhenAll(tasks);

                watch.Stop();

                Console.WriteLine(string.Format("GetGeocodesAsync finished in {0}ms", watch.ElapsedMilliseconds));
            }
            
            return addresses;
        }
    }
}
