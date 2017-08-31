using System;
using System.Threading.Tasks;
using Geocodeonthefly.Application;

namespace Geocodeonthefly.Services
{
    public class GeocodeService
    {
        private GmapsApplication _gmaps;
        private SpreadsheetApplication _spreadsheet;

        public GeocodeService()
        {
            _gmaps = new GmapsApplication();
            _spreadsheet = new SpreadsheetApplication();
        }

        public async Task<bool> GenerateGeocodes(string sourceCsvPath, string destinationCsvPath, char csvSeparator = ';')
        {
            try
            {
                var sourceAddresses = _spreadsheet.ReadFromCsv(sourceCsvPath, csvSeparator);
                var destinationAddresses = await _gmaps.GetGeocodesAsync(sourceAddresses);
                _spreadsheet.WriteCsv(destinationAddresses, destinationCsvPath, csvSeparator);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
