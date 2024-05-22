using FileConverter.DatabaseProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace FileConverter.DatabaseProvider
{
    public class DataContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
