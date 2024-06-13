using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace Excelreader.Models
{
    public class CsvDataMap : ClassMap<ExcelData>
    {
        public CsvDataMap()
        {
            Map(m => m.Segment).Name("Segment");
            Map(m => m.Country).Name("Country");
            Map(m => m.Product).Name("Product");
            Map(m => m.DiscountBand).Name("Discount Band");
            Map(m => m.UnitsSold).Name("Units Sold");
            

            Map(m => m.ManufacturingPrice).Name("Manufacturing Price (£)").TypeConverter<CurrencyConverter>()
                .TypeConverterOption.CultureInfo(new CultureInfo("en-GB"));
            Map(m => m.SalePrice).Name("Sale Price (£)").TypeConverter<CurrencyConverter>()
                .TypeConverterOption.CultureInfo(new CultureInfo("en-GB"));
            Map(m => m.Date).Name("Date");
        }

        public class CurrencyConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                if (decimal.TryParse(text, NumberStyles.Currency, memberMapData.TypeConverterOptions.CultureInfo, out var currencyValue))
                {
                    return currencyValue;
                }
                return base.ConvertFromString(text, row, memberMapData);
            }
        }
    }
}
