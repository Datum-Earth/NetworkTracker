using Microsoft.EntityFrameworkCore;
using NetworkTracker.Database.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.Database.Context
{
    public class NetworkTrackerContext : DbContext
    {
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<NetworkEvent> NetworkEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var path = ConfigurationManager.AppSettings["sqlitePath"];
                optionsBuilder.UseSqlite(path);
            }
        }

        public NetworkTrackerContext()
        {
            Database.EnsureCreated();
        }

        public NetworkTrackerContext(DbContextOptions<NetworkTrackerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
