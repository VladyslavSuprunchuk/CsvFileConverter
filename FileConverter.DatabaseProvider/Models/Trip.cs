namespace FileConverter.DatabaseProvider.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public DateTime TpepPickupDatetime { get; set; }
        public DateTime TpepDropoffDatetime { get; set; }

        public int PULocationID { get; set; }
        public int DOLocationID { get; set; }

        public decimal FareAmount { get; set; }
        public decimal TipAmount { get; set; }

        public int PassengerCount { get; set; }

        public double TripDistance { get; set; }

        public string StoreAndFwdFlag { get; set; } = string.Empty;
    }
}
