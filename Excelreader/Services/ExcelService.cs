
using CsvHelper.Configuration;
using CsvHelper;
using Excelreader.Models;
using System.Globalization;

namespace Excelreader.Services
{
    public class ExcelService
    {
        public IEnumerable<ExcelData> GetCsvData(string filePath)
        {
            

            using (var reader = new StreamReader(filePath))


            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.Replace(" ", ""),
                MissingFieldFound = null,
                HeaderValidated = null
            }))
            {
                //csv.Context.RegisterClassMap<CsvDataMap>();
                var records = csv.GetRecords<ExcelData>().ToList();
                return records;
            }
        }
    }
}
