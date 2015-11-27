using TraffiSnooze.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using SleepTitle.Domain.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using Microsoft.Data.Entity.Metadata;
using SleepTitle.Data.Common;

namespace TraffiSnooze.Data.EF
{
    public class TraffiSnoozeContext : DbContext
    {
        public TraffiSnoozeContext()
        {
            Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = Constants.DbLocation };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        

        public DbSet<Route> Routes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RouteSegment> RouteSegments { get; set; }
        public DbSet<RouteStat> RouteStats { get; set; }
        public DbSet<WakeUpRoutine> RouteTriggers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var route = modelBuilder.Entity<Route>();
            var routeStat = modelBuilder.Entity<RouteStat>();
            var location = modelBuilder.Entity<Location>();
            var routeSegment = modelBuilder.Entity<RouteSegment>();
            var wakeuproutine = modelBuilder.Entity<WakeUpRoutine>();
            var user = modelBuilder.Entity<User>();

            route.HasKey(x => x.Id);
            routeStat.HasKey(x => x.Id);
            location.HasKey(x => x.Id);
            routeSegment.HasKey(x => x.Id);
            wakeuproutine.HasKey(x => x.Id);
            user.HasKey(x => x.Id);

            route.HasOne(x => x.Start);
            route.HasOne(x => x.End);

            routeSegment.HasOne(x => x.Start);
            routeSegment.HasOne(x => x.End);

            route.HasOne(x => x.LastRouteStat);
            route.HasMany(x => x.RouteStats).WithOne(x => x.Route);

            base.OnModelCreating(modelBuilder);
        }
    }
}
