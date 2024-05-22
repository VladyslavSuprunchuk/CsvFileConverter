using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace FileConverter.Services.Converters
{
    public class DoubleConverterWithDefaultValue : DoubleConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (!double.TryParse(text, out double value))
            {
                return 0;
            }

            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
