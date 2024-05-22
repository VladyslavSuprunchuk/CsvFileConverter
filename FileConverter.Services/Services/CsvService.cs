using CsvHelper;
using FileConverter.Core.Const;
using FileConverter.DatabaseProvider.Models;
using FileConverter.Services.Extensions;
using FileConverter.Services.Interfaces;
using System.Globalization;

namespace FileConverter.Services.Services
{
    public class CsvService : ICsvService
    {
        public IEnumerable<Trip> ReadCabData()
        {
            using var reader = new StreamReader(FileKeywords.InputPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<TripMap>();
            var records = csv.GetRecords<Trip>().ToList(); // * to improve responsiveness can create async Task *

            return records;
        }

        public void WriteCabData(IEnumerable<Trip> trips)
        {
            using var writer = new StreamWriter(FileKeywords.OutputPath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteField("Id");
            csv.WriteField("TpepPickupDatetime");
            csv.WriteField("TpepDropoffDatetime");
            csv.WriteField("PULocationID");
            csv.WriteField("DOLocationID");
            csv.WriteField("FareAmount");
            csv.WriteField("TipAmount");
            csv.WriteField("PassengerCount");
            csv.WriteField("TripDistance");
            csv.WriteField("StoreAndFwdFlag");

            foreach (var trip in trips)
            {
                csv.WriteField(trip.Id);
                csv.WriteField(trip.TpepPickupDatetime);
                csv.WriteField(trip.TpepDropoffDatetime);
                csv.WriteField(trip.PULocationID);
                csv.WriteField(trip.DOLocationID);
                csv.WriteField(trip.FareAmount);
                csv.WriteField(trip.TipAmount);
                csv.WriteField(trip.PassengerCount);
                csv.WriteField(trip.TripDistance);
                csv.WriteField(trip.StoreAndFwdFlag);

                csv.NextRecord();
            }
        }
    }
}
