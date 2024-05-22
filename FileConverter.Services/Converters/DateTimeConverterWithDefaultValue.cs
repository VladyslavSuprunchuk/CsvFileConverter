using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace FileConverter.Services.Converters
{
    public class DateTimeConverterWithDefaultValue : DateTimeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (DateTime.TryParse(text, out var dateTime))
            {
                return dateTime.ToUniversalTime();
            }

            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}
