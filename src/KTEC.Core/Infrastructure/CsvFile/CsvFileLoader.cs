using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using KTEC.Core.Domain;

namespace KTEC.Core.Infrastructure
{
    public class CsvFileLoader : ICsvFileLoader
    {
        private const string CsvFileLocation = "../../../../../data/cameras-defb.csv";

        public static IEnumerable<Camera> LoadFile()
        {
            using (var reader = new StreamReader(CsvFileLocation))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var isBadRecord = false;

                csv.Configuration.Delimiter = ";";
                csv.Configuration.MissingFieldFound = (headerNames, index, context) => {
                    isBadRecord = true;
                };
                csv.Read();
                csv.ReadHeader();

                var records = new List<Camera>();

                while (csv.Read())
                {
                    var name = csv.GetField<string>("Camera");
                    var location = new Location(csv.GetField<double>("Latitude"), csv.GetField<double>("Longitude"));

                    if (!isBadRecord)
                    {
                        var record = new Camera(name, location);
                        records.Add(record);
                    }

                    isBadRecord = false;
                }

                return records;
            }
        }
    }
}
