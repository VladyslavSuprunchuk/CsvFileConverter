using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace FileConverter.Services.Converters
{
    public class StringTrimConverter : StringConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            var trimmedText = text.Trim();

            return trimmedText;
        }
    }
}
