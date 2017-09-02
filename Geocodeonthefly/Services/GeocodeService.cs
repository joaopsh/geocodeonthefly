using System.Threading.Tasks;
using Geocodeonthefly.Application;
using Geocodeonthefly.Infrastructure.Repositories;

namespace Geocodeonthefly.Services
{
    public class GeocodeService
    {
        private GmapsApplication _gmaps;
        private AddressRepository _csvAddressRepository;

        public GeocodeService()
        {
            _gmaps = new GmapsApplication();
            _csvAddressRepository = new AddressRepository();
        }

        public async Task GenerateGeocodes(string sourceCsvPath, string destinationCsvPath)
        {
            var sourceAddresses = _csvAddressRepository.Read(sourceCsvPath);
            var destinationAddresses = await _gmaps.GetGeocodesAsync(sourceAddresses);
            _csvAddressRepository.Write(destinationAddresses, destinationCsvPath);
        }
    }
}
