using FileConverter.DatabaseProvider;
using FileConverter.DatabaseProvider.Models;
using FileConverter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FileConverter.Services.Services
{
    public class TripService : ITripService
    {
        private readonly DataContext _dataContext;

        public TripService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(IEnumerable<Trip> trips)
        {
            await _dataContext.BulkInsertAsync(trips);

            await _dataContext.SaveChangesAsync();
        }

        public IEnumerable<Trip> GetDuplicates()
        {
            var duplicateTrips = _dataContext.Trips
                                .ToList()
                                .GroupBy(p => new { p.TpepPickupDatetime, p.TpepDropoffDatetime, p.PassengerCount })
                                .Where(group => group.Count() > 1)
                                .SelectMany(x => x);

            return duplicateTrips;
        }

        public async Task DeleteAsync(IEnumerable<Trip> trips)
        {
            _dataContext.Trips.RemoveRange(trips);

            await _dataContext.SaveChangesAsync();
        }

        public IEnumerable<Trip> Get(
            int? locationId = null,
            bool orderByDistance = false,
            bool orderByTime = false)
        {
            IQueryable<Trip> trips = _dataContext.Trips;

            if (locationId != null)
            {
                trips = trips.Where(t => t.PULocationID == locationId);
            }

            if (orderByDistance)
            {
                trips = trips.OrderByDescending(t => t.TripDistance).Take(100);
            }
            else if (orderByTime)
            {
                trips = trips.OrderByDescending(t => t.TpepDropoffDatetime - t.TpepPickupDatetime).Take(100);
            }
     
            return trips;
        }

        public async Task<int> GetHighestTipAmountByPULocationIdAsync()
        {
            var trips = await _dataContext.Trips.ToListAsync();

            var groupedTrips = trips.GroupBy(trip => trip.PULocationID)
            .Select(group => new
            {
                PULocationID = group.Key,
                AverageTipAmount = group.Average(trip => trip.TipAmount)
            });

            var highestAverageTrip = groupedTrips.OrderByDescending(group => group.AverageTipAmount).FirstOrDefault();

            if (highestAverageTrip != null)
            {
                return highestAverageTrip.PULocationID;
            }
            else
            {
                throw new Exception("No trips found."); // need to hadle if no trips
            }
        }

    }
}
