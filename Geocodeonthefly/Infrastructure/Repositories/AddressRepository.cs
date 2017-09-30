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
                    Country = "Brazil",
                    Street = row.GetCell(0)?.ToString(),
                    Number = row.GetCell(1)?.ToString(),
                    Neighborhood = row.GetCell(2)?.ToString(),
                    Postalcode = row.GetCell(3)?.ToString(),
                    State = row.GetCell(4)?.ToString(),
                    City = row.GetCell(5)?.ToString()
                });
            }

            // Removes empty entries that could be read from excel.
            addresses = addresses.Where(x => !string.IsNullOrWhiteSpace(x.Street) 
            && !string.IsNullOrWhiteSpace(x.Neighborhood) 
            && !string.IsNullOrWhiteSpace(x.Number)
            && !string.IsNullOrWhiteSpace(x.City)).ToList();

            return addresses;
        }

        public void Write(IList<Address> addresses, string path)
        {
            var workbook = new XSSFWorkbook();
            var sheet = (XSSFSheet)workbook.CreateSheet("Geocoded Addresses");

            var rowIndex = 0;
            var row = sheet.CreateRow(rowIndex);

            row.CreateCell(0).SetCellValue("Street");
            row.CreateCell(1).SetCellValue("Number");
            row.CreateCell(2).SetCellValue("Neighborhood");
            row.CreateCell(3).SetCellValue("Postal Code");
            row.CreateCell(4).SetCellValue("State");
            row.CreateCell(5).SetCellValue("City");
            row.CreateCell(6).SetCellValue("Lat");
            row.CreateCell(7).SetCellValue("Lng");

            row.CreateCell(8).SetCellValue("API Street");
            row.CreateCell(9).SetCellValue("API Number");
            row.CreateCell(10).SetCellValue("API Neighborhood");
            row.CreateCell(11).SetCellValue("API Postal Code");
            row.CreateCell(12).SetCellValue("API State");
            row.CreateCell(13).SetCellValue("API City");
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

            ICellStyle apiCellStyle = workbook.CreateCellStyle();
            apiCellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.PaleBlue.Index;
            apiCellStyle.FillPattern = FillPattern.SolidForeground;
            apiCellStyle.BorderBottom = BorderStyle.Medium;

            foreach (var address in addresses)
            {
                row = sheet.CreateRow(rowIndex);
                row.CreateCell(0).SetCellValue(address.Street);
                row.CreateCell(1).SetCellValue(address.Number);
                row.CreateCell(2).SetCellValue(address.Neighborhood);
                row.CreateCell(3).SetCellValue(address.Postalcode);
                row.CreateCell(4).SetCellValue(address.State);
                row.CreateCell(5).SetCellValue(address.City);
                row.CreateCell(6).SetCellValue(address.Lat);
                row.CreateCell(7).SetCellValue(address.Lng);
                
                var apiStreetCell = row.CreateCell(8);
                apiStreetCell.SetCellValue(address.ApiStreet);
                apiStreetCell.CellStyle = apiCellStyle;

                var apiNumberCell = row.CreateCell(9);
                apiNumberCell.SetCellValue(address.ApiNumber);
                apiNumberCell.CellStyle = apiCellStyle;

                var apiNeighborhoodCell = row.CreateCell(10);
                apiNeighborhoodCell.SetCellValue(address.ApiNeighborhood);
                apiNeighborhoodCell.CellStyle = apiCellStyle;

                var apiPostalCodeCell = row.CreateCell(11);
                apiPostalCodeCell.SetCellValue(address.ApiPostalcode);
                apiPostalCodeCell.CellStyle = apiCellStyle;

                var apiStateCell = row.CreateCell(12);
                apiStateCell.SetCellValue(address.ApiState);
                apiStateCell.CellStyle = apiCellStyle;

                var apiCityCell = row.CreateCell(13);
                apiCityCell.SetCellValue(address.ApiCity);
                apiCityCell.CellStyle = apiCellStyle;
                
                rowIndex++;
            }

            row.GetCell(0).CellStyle.Alignment = HorizontalAlignment.Left;
            sheet.SetColumnWidth(0, 14000);
            sheet.SetColumnWidth(1, 4000);
            sheet.SetColumnWidth(2, 8000);
            sheet.SetColumnWidth(3, 4000);
            sheet.SetColumnWidth(4, 4000);
            sheet.SetColumnWidth(5, 4000);
            sheet.SetColumnWidth(6, 4000);
            sheet.SetColumnWidth(7, 4000);

            sheet.SetColumnWidth(8, 14000);
            sheet.SetColumnWidth(9, 4000);
            sheet.SetColumnWidth(10, 8000);
            sheet.SetColumnWidth(11, 4000);
            sheet.SetColumnWidth(12, 4000);
            sheet.SetColumnWidth(13, 4000);

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
                    address.Lat,
                    address.Lng));
            }

            File.WriteAllText(destinationPath, csv.ToString(), Encoding.Default);
        }
    }
}
