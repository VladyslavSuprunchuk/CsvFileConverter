using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;


namespace FileConverter.Services.Converters
{
    public class FlagConverter : StringConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text.Equals("N"))
            {
                return "No";
            }

            if (text.Equals("Y"))
            {
                return "Yes";
            }

            return text;
        }
    }
}
