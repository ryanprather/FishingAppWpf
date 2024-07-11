using FishingApp.Storage.Datasets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingApp.Storage.Context
{
    public class FishingAppContext : DbContext
    {
        public DbSet<PersonalGPSLocation> PersonalGPSLocations { get; set; }
        public DbSet<MonitoredNOAALocation> MonitoredNOAALocations { get; set; }
        public DbSet<PersonalGPSLocationNote> PersonalGPSLocationNotes { get; set; }

        public FishingAppContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=PersonalGPSDatabase.db");
        }

        public FishingAppContext(DbContextOptions options):base(options) 
        {
        }
    }
}
