using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

            return addresses;
        }

        public void Write(IList<Address> addresses, string path)
        {
            var workbook = new XSSFWorkbook();
            var sheet = (XSSFSheet)workbook.CreateSheet("Endereços Geolocalizados");

            var rowIndex = 0;
            var row = sheet.CreateRow(rowIndex);

            row.CreateCell(0).SetCellValue("Endereço");
            row.CreateCell(1).SetCellValue("Número");
            row.CreateCell(2).SetCellValue("Bairro");
            row.CreateCell(3).SetCellValue("CEP");
            row.CreateCell(4).SetCellValue("Estado");
            row.CreateCell(5).SetCellValue("Cidade");
            row.CreateCell(6).SetCellValue("Lat");
            row.CreateCell(7).SetCellValue("Lng");
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

            csv.AppendLine(string.Format("Endereço{0}Número{0}Bairro{0}Cep{0}Estado{0}Cidade{0}Lat{0}Lng", _csvDelimiter));

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
