using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace FileConverter.Services.Converters
{
    public class DecimalConverterWithDefaultValue : DecimalConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (!decimal.TryParse(text, out decimal value))
            {
                return 0;
            }

            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
