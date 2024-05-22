using CsvHelper.Configuration;
using FileConverter.DatabaseProvider.Models;
using FileConverter.Services.Converters;

namespace FileConverter.Services.Extensions
{
    public class TripMap : ClassMap<Trip>
    {
        public TripMap()
        {
            Map(m => m.TpepPickupDatetime).Name("tpep_pickup_datetime").TypeConverter<DateTimeConverterWithDefaultValue>();

            Map(m => m.TpepDropoffDatetime).Name("tpep_dropoff_datetime").TypeConverter<DateTimeConverterWithDefaultValue>();

            Map(m => m.PassengerCount).Name("passenger_count").TypeConverter<IntConverterWithDefaultValue>();

            Map(m => m.TripDistance).Name("trip_distance").TypeConverter<DoubleConverterWithDefaultValue>();

            Map(m => m.StoreAndFwdFlag).Name("store_and_fwd_flag").TypeConverter<StringTrimConverter>()
                                                                  .TypeConverter<FlagConverter>();

            Map(m => m.PULocationID).Name("PULocationID").TypeConverter<IntConverterWithDefaultValue>();

            Map(m => m.DOLocationID).Name("DOLocationID").TypeConverter<IntConverterWithDefaultValue>();

            Map(m => m.FareAmount).Name("fare_amount").TypeConverter<DecimalConverterWithDefaultValue>();

            Map(m => m.TipAmount).Name("tip_amount").TypeConverter<DecimalConverterWithDefaultValue>();
        }
    }
}
