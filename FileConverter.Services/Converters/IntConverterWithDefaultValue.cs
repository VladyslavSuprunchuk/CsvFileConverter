using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace FileConverter.Services.Converters
{
    public class IntConverterWithDefaultValue : Int32Converter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
