using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Geocodeonthefly.Domain;
using Geocodeonthefly.Infrastructure.Log;
using Newtonsoft.Json;
using System.Linq;

namespace Geocodeonthefly.Application
{
    public class GmapsApplication
    {
        private readonly Log _logger;
        
        public GmapsApplication()
        {
            _logger = new Log();
        }

        public async Task<IList<Address>> GetGeocodesAsync(IList<Address> addresses)
        {
            string requestUri = "https://maps.googleapis.com/maps/api/geocode/json?address={0}&key=" + Helpers.GetAppSetting("gmaps-api-key") + "&sensor=false";
            
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

                    var formatedUri = string.Format(requestUri, addressString);

                    tasks.Add(client.GetAsync(formatedUri).ContinueWith(async t =>
                    {
                        var content = await t.Result.Content.ReadAsStringAsync();
                        GmapsResponseDTO.RootObject response = JsonConvert.DeserializeObject<GmapsResponseDTO.RootObject>(content);
                        
                        try
                        {
                            address.ApiLat = response.results[0].geometry.location.lat;
                            address.ApiLng = response.results[0].geometry.location.lng;

                            address.ApiNumber = response.results[0].address_components.FirstOrDefault(x => x.types.Contains("street_number"))?.long_name;
                            address.ApiStreet = response.results[0].address_components.FirstOrDefault(x => x.types.Contains("route"))?.long_name;
                            address.ApiNeighborhood = response.results[0].address_components.FirstOrDefault(x => x.types.Contains("sublocality"))?.long_name;
                            address.ApiCity = response.results[0].address_components.FirstOrDefault(x => x.types.Contains("administrative_area_level_2"))?.long_name;
                            address.ApiState = response.results[0].address_components.FirstOrDefault(x => x.types.Contains("administrative_area_level_1"))?.long_name;
                            address.ApiCountry = response.results[0].address_components.FirstOrDefault(x => x.types.Contains("country"))?.long_name;
                            address.ApiPostalcode = response.results[0].address_components.FirstOrDefault(x => x.types.Contains("postal_code"))?.long_name;
                            
                        }
                        catch(Exception ex)
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
