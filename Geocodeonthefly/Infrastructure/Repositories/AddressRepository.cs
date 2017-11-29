using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Geocodeonthefly.Domain;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Geocodeonthefly.Infrastructure.Repositories
{
    public class AddressRepository
    {
        private readonly char _csvDelimiter;

        public AddressRepository()
        {
            _csvDelimiter = Convert.ToChar(Helpers.GetAppSetting("csv-delimiter"));
        }

        public IList<Address> Read(string path)
        {
            var addresses = new List<Address>();
            XSSFWorkbook hssfworkbook;


            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new XSSFWorkbook(file);
            }

            ISheet sheet = hssfworkbook.GetSheetAt(0);
            IRow headerRow = sheet.GetRow(0);
            int colCount = headerRow.LastCellNum;
            int rowCount = sheet.LastRowNum;
            IEnumerator rows = sheet.GetRowEnumerator();

            // Skip header row
            rows.MoveNext();

            while (rows.MoveNext())
            {
                IRow row = (XSSFRow)rows.Current;

                addresses.Add(new Address()
                {
                    CustomIdentifier = row.GetCell(0)?.ToString(),
                    Country = "Brazil",
                    Street = row.GetCell(1)?.ToString(),
                    Number = row.GetCell(2)?.ToString(),
                    Neighborhood = row.GetCell(3)?.ToString(),
                    Postalcode = row.GetCell(4)?.ToString(),
                    State = row.GetCell(5)?.ToString(),
                    City = row.GetCell(6)?.ToString()
                });
            }

            // Removes empty entries that could be read from excel.
            addresses = addresses.Where(x => !(string.IsNullOrWhiteSpace(x.Street)
            && string.IsNullOrWhiteSpace(x.Neighborhood)
            && string.IsNullOrWhiteSpace(x.Number)
            && string.IsNullOrWhiteSpace(x.City))).ToList();

            return addresses;
        }

        public void Write(IList<Address> addresses, string path)
        {
            var workbook = new XSSFWorkbook();
            var sheet = (XSSFSheet)workbook.CreateSheet("Geocoded Addresses");

            var rowIndex = 0;
            var row = sheet.CreateRow(rowIndex);

            row.CreateCell(0).SetCellValue("Custom Identifier");
            row.CreateCell(1).SetCellValue("Street");
            row.CreateCell(2).SetCellValue("Number");
            row.CreateCell(3).SetCellValue("Neighborhood");
            row.CreateCell(4).SetCellValue("Postal Code");
            row.CreateCell(5).SetCellValue("State");
            row.CreateCell(6).SetCellValue("City");

            row.CreateCell(7).SetCellValue("API Lat");
            row.CreateCell(8).SetCellValue("API Lng");
            row.CreateCell(9).SetCellValue("API Street");
            row.CreateCell(10).SetCellValue("API Number");
            row.CreateCell(11).SetCellValue("API Neighborhood");
            row.CreateCell(12).SetCellValue("API Postal Code");
            row.CreateCell(13).SetCellValue("API State");
            row.CreateCell(14).SetCellValue("API City");
            rowIndex++;

            var headerStyle = workbook.CreateCellStyle();
            var headerFont = workbook.CreateFont();
            headerFont.Boldweight = (short)FontBoldWeight.Bold;
            headerStyle.SetFont(headerFont);
            headerStyle.BorderBottom = BorderStyle.Medium;

            row.GetCell(0).CellStyle = headerStyle;
            row.GetCell(1).CellStyle = headerStyle;
            row.GetCell(2).CellStyle = headerStyle;
            row.GetCell(3).CellStyle = headerStyle;
            row.GetCell(4).CellStyle = headerStyle;
            row.GetCell(5).CellStyle = headerStyle;
            row.GetCell(6).CellStyle = headerStyle;
            row.GetCell(7).CellStyle = headerStyle;

            row.GetCell(8).CellStyle = headerStyle;
            row.GetCell(9).CellStyle = headerStyle;
            row.GetCell(10).CellStyle = headerStyle;
            row.GetCell(11).CellStyle = headerStyle;
            row.GetCell(12).CellStyle = headerStyle;
            row.GetCell(13).CellStyle = headerStyle;
            row.GetCell(14).CellStyle = headerStyle;
            
            // API results cell style
            byte[] borderRgb = new byte[3] { 178, 178, 178 };


            byte[] successRgb = new byte[3] { 220, 250, 230 };
            XSSFCellStyle successCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            successCellStyle.FillPattern = FillPattern.SolidForeground;
            successCellStyle.SetFillForegroundColor(new XSSFColor(successRgb));
            successCellStyle.BorderBottom = BorderStyle.Thin;
            successCellStyle.BorderTop = BorderStyle.Thin;
            successCellStyle.BorderLeft = BorderStyle.Thin;
            successCellStyle.BorderRight = BorderStyle.Thin;
            successCellStyle.SetBorderColor(NPOI.XSSF.UserModel.Extensions.BorderSide.BOTTOM, new XSSFColor(borderRgb));
            successCellStyle.SetBorderColor(NPOI.XSSF.UserModel.Extensions.BorderSide.TOP, new XSSFColor(borderRgb));
            successCellStyle.SetBorderColor(NPOI.XSSF.UserModel.Extensions.BorderSide.LEFT, new XSSFColor(borderRgb));
            successCellStyle.SetBorderColor(NPOI.XSSF.UserModel.Extensions.BorderSide.RIGHT, new XSSFColor(borderRgb));
            
            byte[] errorRgb = new byte[3] { 250, 220, 220 };
            XSSFCellStyle errorCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            errorCellStyle.FillPattern = FillPattern.SolidForeground;
            errorCellStyle.SetFillForegroundColor(new XSSFColor(errorRgb));
            errorCellStyle.BorderBottom = BorderStyle.Thin;
            errorCellStyle.BorderTop = BorderStyle.Thin;
            errorCellStyle.BorderLeft = BorderStyle.Thin;
            errorCellStyle.BorderRight = BorderStyle.Thin;
            errorCellStyle.SetBorderColor(NPOI.XSSF.UserModel.Extensions.BorderSide.BOTTOM, new XSSFColor(borderRgb));
            errorCellStyle.SetBorderColor(NPOI.XSSF.UserModel.Extensions.BorderSide.TOP, new XSSFColor(borderRgb));
            errorCellStyle.SetBorderColor(NPOI.XSSF.UserModel.Extensions.BorderSide.LEFT, new XSSFColor(borderRgb));
            errorCellStyle.SetBorderColor(NPOI.XSSF.UserModel.Extensions.BorderSide.RIGHT, new XSSFColor(borderRgb));

            foreach (var address in addresses)
            {
                row = sheet.CreateRow(rowIndex);

                // Configure cell color by found result 
                var didFindResult = address.ApiLat != 0 && address.ApiLng != 0;

                var cellStyle = successCellStyle;

                if (!didFindResult)
                    cellStyle = errorCellStyle;

                // Addresses replication
                var customIdentifierCell = row.CreateCell(0);
                customIdentifierCell.SetCellValue(address.CustomIdentifier);
                if (!didFindResult)
                    customIdentifierCell.CellStyle = cellStyle;

                var streetCell = row.CreateCell(1);
                streetCell.SetCellValue(address.Street);
                if (!didFindResult)
                    streetCell.CellStyle = cellStyle;

                var numberCell = row.CreateCell(2);
                numberCell.SetCellValue(address.Number);
                if (!didFindResult)
                    numberCell.CellStyle = cellStyle;


                var neighborhoodCell = row.CreateCell(3);
                neighborhoodCell.SetCellValue(address.Neighborhood);
                if (!didFindResult)
                    neighborhoodCell.CellStyle = cellStyle;


                var postalCodeCell = row.CreateCell(4);
                postalCodeCell.SetCellValue(address.Postalcode);
                if (!didFindResult)
                    postalCodeCell.CellStyle = cellStyle;


                var stateCell = row.CreateCell(5);
                stateCell.SetCellValue(address.State);
                if (!didFindResult)
                    stateCell.CellStyle = cellStyle;


                var cityCell = row.CreateCell(6);
                cityCell.SetCellValue(address.City);
                if (!didFindResult)
                    cityCell.CellStyle = cellStyle;


                // API results
                var apiLatCell = row.CreateCell(7);
                if(address.ApiLat != 0 || address.ApiLng != 0)
                    apiLatCell.SetCellValue(address.ApiLat);
                apiLatCell.CellStyle = cellStyle;


                var apiLngCell = row.CreateCell(8);
                if (address.ApiLat != 0 || address.ApiLng != 0)
                    apiLngCell.SetCellValue(address.ApiLng);
                apiLngCell.CellStyle = cellStyle;


                var apiStreetCell = row.CreateCell(9);
                apiStreetCell.SetCellValue(address.ApiStreet);
                apiStreetCell.CellStyle = cellStyle;


                var apiNumberCell = row.CreateCell(10);
                apiNumberCell.SetCellValue(address.ApiNumber);
                apiNumberCell.CellStyle = cellStyle;

                var apiNeighborhoodCell = row.CreateCell(11);
                apiNeighborhoodCell.SetCellValue(address.ApiNeighborhood);
                apiNeighborhoodCell.CellStyle = cellStyle;

                var apiPostalCodeCell = row.CreateCell(12);
                apiPostalCodeCell.SetCellValue(address.ApiPostalcode);
                apiPostalCodeCell.CellStyle = cellStyle;

                var apiStateCell = row.CreateCell(13);
                apiStateCell.SetCellValue(address.ApiState);
                apiStateCell.CellStyle = cellStyle;

                var apiCityCell = row.CreateCell(14);
                apiCityCell.SetCellValue(address.ApiCity);
                apiCityCell.CellStyle = cellStyle;
                
                rowIndex++;
            }

            row.GetCell(0).CellStyle.Alignment = HorizontalAlignment.Left;
            sheet.SetColumnWidth(0, 4000);
            sheet.SetColumnWidth(1, 14000);
            sheet.SetColumnWidth(2, 4000);
            sheet.SetColumnWidth(3, 8000);
            sheet.SetColumnWidth(4, 4000);
            sheet.SetColumnWidth(5, 4000);
            sheet.SetColumnWidth(6, 4000);
            sheet.SetColumnWidth(7, 4000);
            sheet.SetColumnWidth(8, 4000);

            sheet.SetColumnWidth(9, 14000);
            sheet.SetColumnWidth(10, 4000);
            sheet.SetColumnWidth(11, 8000);
            sheet.SetColumnWidth(12, 4000);
            sheet.SetColumnWidth(13, 4000);
            sheet.SetColumnWidth(14, 4000);

            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }
        }

        public IList<Address> ReadCsv(string path)
        {
            
            var addresses = new List<Address>();

            using (var reader = new StreamReader(path, Encoding.Default))
            {
                //skip header
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(_csvDelimiter);

                    var address = new Address();

                    address.Country = "Brazil";
                    address.State = values[4];
                    address.City = values[5];
                    address.Neighborhood = values[2];
                    address.Street = values[0];
                    address.Number = values[1];
                    address.Postalcode = values[3];

                    if (!string.IsNullOrWhiteSpace(address.Street.Trim()))
                        addresses.Add(address);

                    reader.ReadLine();
                }
            }

            return addresses;
        }

        public void WriteCsv(IList<Address> addresses, string destinationPath)
        {
            var csv = new StringBuilder();

            csv.AppendLine(string.Format("Street{0}Number{0}Neighborhood{0}PostalCode{0}State{0}City{0}Lat{0}Lng", _csvDelimiter));

            foreach (var address in addresses)
            {
                csv.AppendLine(string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}", _csvDelimiter,
                    address.Street,
                    address.Number,
                    address.Neighborhood,
                    address.Postalcode,
                    address.State,
                    address.City,
                    address.ApiLat,
                    address.ApiLng));
            }

            File.WriteAllText(destinationPath, csv.ToString(), Encoding.Default);
        }
    }
}
