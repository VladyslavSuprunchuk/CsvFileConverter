using FileConverter.DatabaseProvider.Models;

namespace FileConverter.Services.Interfaces
{
    public  interface ITripService
    {
        Task CreateAsync(IEnumerable<Trip> trips);

        IEnumerable<Trip> Get(
           int? locationId = null,
           bool orderByDistance = false,
           bool orderByTime = false);

        IEnumerable<Trip> GetDuplicates();

        Task DeleteAsync(IEnumerable<Trip> trips);

        Task<int> GetHighestTipAmountByPULocationIdAsync();
    }
}
