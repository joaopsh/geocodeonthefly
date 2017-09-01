using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Geocodeonthefly.Domain;
using Newtonsoft.Json;

namespace Geocodeonthefly.Application
{
    public class GmapsApplication
    {
        private const string requestUri = "http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false";

        public async Task<IList<Address>> GetGeocodesAsync(IList<Address> addresses)
        {
            using (var client = new HttpClient())
            {
                var tasks = new List<Task>();
                
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
                        dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(content);

                        try
                        {
                            address.Lat = jsonResponse.results[0].geometry.location.lat;
                            address.Lng = jsonResponse.results[0].geometry.location.lng;
                        }
                        catch { };
                    }));
                }
                
                await Task.WhenAll(tasks);
            }
            
            return addresses;
        }
    }
}
