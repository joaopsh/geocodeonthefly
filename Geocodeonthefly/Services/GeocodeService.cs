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

        public async void GenerateGeocodes(string sourceCsvPath, string destinationCsvPath, char csvSeparator = ';')
        {
            var sourceAddresses = _spreadsheet.ReadFromCsv(sourceCsvPath, csvSeparator);
            var destinationAddresses = await _gmaps.GetGeocodesAsync(sourceAddresses);
            _spreadsheet.WriteCsv(destinationAddresses, destinationCsvPath, csvSeparator);
        }
    }
}
