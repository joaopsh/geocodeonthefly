using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Geocodeonthefly.Domain;
using Newtonsoft.Json;

namespace Geocodeonthefly.Application
{
    public class GmapsApplication
    {
        private string requestUri = "http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false";

        public async Task<ICollection<Address>> GetGeocodesAsync(ICollection<Address> addresses)
        {

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

                requestUri = string.Format(requestUri, addressString);

                using (var client = new HttpClient())
                {

                    var request = await client.GetAsync(string.Format(requestUri, address));
                    var content = await request.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(content);

                    address.Lat = jsonResponse.results[0].geometry.location.lat;
                    address.Lng = jsonResponse.results[0].geometry.location.lng;

                }
            }
            
            return addresses;
        }
    }
}
