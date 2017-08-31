using System.Collections.Generic;
using System.IO;
using System.Text;
using Geocodeonthefly.Domain;

namespace Geocodeonthefly.Application
{
    public class SpreadsheetApplication
    {
        public ICollection<Address> ReadFromCsv(string path, char csvSeparator = ';')
        {
            var addresses = new List<Address>();
            
            using (var reader = new StreamReader(path))
            {
                //skip header
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(csvSeparator);

                    var address = new Address();

                    address.Country = "Brazil";
                    address.State = values[4];
                    address.City = values[5];
                    address.Neighborhood = values[2];
                    address.Street = values[0];
                    address.Number = values[1];
                    address.Postalcode = values[3];

                    if(!string.IsNullOrWhiteSpace(address.Street.Trim()))
                        addresses.Add(address);

                    reader.ReadLine();
                }
            }

            return addresses;
        }

        public void WriteCsv(ICollection<Address> addresses, string destinationPath, char csvSeparator = ';')
        {
            var csv = new StringBuilder();

            csv.AppendLine(string.Format("Endereço{0}Número{0}Bairro{0}Cep{0}Estado{0}Cidade{0}Lat{0}Lng", csvSeparator));

            foreach (var address in addresses)
            {
                csv.AppendLine(string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}", csvSeparator,
                    address.Street,
                    address.Number,
                    address.Neighborhood,
                    address.Postalcode,
                    address.State,
                    address.City,
                    address.Lat,
                    address.Lng));
            }
            
            File.WriteAllText(destinationPath, csv.ToString());
        }

    }
}
