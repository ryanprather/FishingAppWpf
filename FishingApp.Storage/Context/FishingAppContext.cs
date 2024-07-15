using FishingApp.Storage.Datasets;
using Microsoft.EntityFrameworkCore;

namespace FishingApp.Storage.Context
{
    public class FishingAppContext : DbContext
    {
        /// <summary>
        /// TODO: add management and UI for fishing locations 
        /// </summary>
        public DbSet<PersonalGPSLocation> PersonalGPSLocations { get; set; }

        /// <summary>
        /// TODO: add management and UI for stored noaa bouys/location
        /// </summary>
        public DbSet<MonitoredNOAALocation> MonitoredNOAALocations { get; set; }

        /// <summary>
        /// TODO: add management and UI for fishing locations notes 
        /// </summary>
        public DbSet<PersonalGPSLocationNote> PersonalGPSLocationNotes { get; set; }

        /// <summary>
        /// used for creating migrations
        /// </summary>
        public FishingAppContext()
        {
        }

        /// <summary>
        /// used for creating migrations
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=PersonalGPSDatabase.db");
        }

        /// <summary>
        /// used when app is started
        /// </summary>
        /// <param name="options"></param>
        public FishingAppContext(DbContextOptions options):base(options) 
        { }
    }
}
