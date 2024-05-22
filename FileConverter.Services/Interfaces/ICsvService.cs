using FileConverter.DatabaseProvider.Models;

namespace FileConverter.Services.Interfaces
{
    public interface ICsvService
    {
        IEnumerable<Trip> ReadCabData();

        void WriteCabData(IEnumerable<Trip> trips);
    }
}
