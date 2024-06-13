using CsvHelper.Configuration.Attributes;

namespace Excelreader.Models
{
    public class ExcelData
    {
        public string Segment { get; set; }
        public string Country { get; set; }
        public string Product { get; set; }
        [Name("Discount Band")]
        public string DiscountBand { get; set; }
        [Name("Units Sold")]
        public string UnitsSold { get; set; }
        [Name("Manufacturing Price")]
        public string ManufacturingPrice { get; set; }
        [Name("Sale Price")]
        public string SalePrice { get; set; }
        public DateTime Date { get; set; }

        

    }
}
