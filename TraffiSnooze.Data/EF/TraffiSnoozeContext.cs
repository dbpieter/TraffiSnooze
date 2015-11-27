using TraffiSnooze.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using SleepTitle.Domain.Models;

namespace TraffiSnooze.Data.EF
{
    public class TraffiSnoozeContext : DbContext
    {
        public TraffiSnoozeContext() : base("SqlLiteContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TraffiSnoozeContext>());
        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RouteSegment> RouteSegments { get; set; }
        public DbSet<RouteStat> RouteStats { get; set; }
        public DbSet<WakeUpRoutine> RouteTriggers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var route = modelBuilder.Entity<Route>();
            var routeStat = modelBuilder.Entity<RouteStat>();
            var location = modelBuilder.Entity<Location>();
            var routeSegment = modelBuilder.Entity<RouteSegment>();
            var wakeuproutine = modelBuilder.Entity<WakeUpRoutine>();
            var user = modelBuilder.Entity<User>();

            route.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            routeStat.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            location.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            routeSegment.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            wakeuproutine.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            user.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            route.HasRequired(x => x.Start).WithMany().WillCascadeOnDelete(false);
            route.HasRequired(x => x.End).WithMany().WillCascadeOnDelete(false);

            routeSegment.HasRequired(x => x.Start).WithMany().WillCascadeOnDelete(false);
            routeSegment.HasRequired(x => x.End).WithMany().WillCascadeOnDelete(false);



        }
    }
}
