using Microsoft.EntityFrameworkCore;
using WebAppToModifyRecordsInDB.Models;

namespace WebAppToModifyRecordsInDB.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        
        public DbSet<Location> Locations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Accreditation> Accreditations { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<TrackType> TrackTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Full" },
                new Status { Id = 2, Name = "Suspended" }
            );

            modelBuilder.Entity<TrackType>().HasData(
                new TrackType { Id = 1, Name = "Racetrack" },
                new TrackType { Id = 2, Name = "Trainingtrack" }
            );
        }
    }
}
