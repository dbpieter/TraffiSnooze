using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TraffiSnooze.Data.EF;

namespace SleepTitle.Data.Migrations
{
    [DbContext(typeof(TraffiSnoozeContext))]
    [Migration("20151127150116_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("SleepTitle.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TraffiSnooze.Domain.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<float>("X");

                    b.Property<float>("Y");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TraffiSnooze.Domain.Models.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EndId");

                    b.Property<Guid?>("LastRouteStatId");

                    b.Property<Guid>("StartId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TraffiSnooze.Domain.Models.RouteSegment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EndId");

                    b.Property<Guid>("StartId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TraffiSnooze.Domain.Models.RouteStat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CaptureTime");

                    b.Property<TimeSpan>("Duration");

                    b.Property<Guid>("RouteId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TraffiSnooze.Domain.Models.WakeUpRoutine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("RouteId");

                    b.Property<DateTime>("ShouldArriveAt");

                    b.Property<TimeSpan>("TimeNeededAfterWakeUp");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TraffiSnooze.Domain.Models.Route", b =>
                {
                    b.HasOne("TraffiSnooze.Domain.Models.Location")
                        .WithMany()
                        .HasForeignKey("EndId");

                    b.HasOne("TraffiSnooze.Domain.Models.RouteStat")
                        .WithMany()
                        .HasForeignKey("LastRouteStatId");

                    b.HasOne("TraffiSnooze.Domain.Models.Location")
                        .WithMany()
                        .HasForeignKey("StartId");
                });

            modelBuilder.Entity("TraffiSnooze.Domain.Models.RouteSegment", b =>
                {
                    b.HasOne("TraffiSnooze.Domain.Models.Location")
                        .WithMany()
                        .HasForeignKey("EndId");

                    b.HasOne("TraffiSnooze.Domain.Models.Location")
                        .WithMany()
                        .HasForeignKey("StartId");
                });

            modelBuilder.Entity("TraffiSnooze.Domain.Models.RouteStat", b =>
                {
                    b.HasOne("TraffiSnooze.Domain.Models.Route")
                        .WithMany()
                        .HasForeignKey("RouteId");
                });

            modelBuilder.Entity("TraffiSnooze.Domain.Models.WakeUpRoutine", b =>
                {
                    b.HasOne("TraffiSnooze.Domain.Models.Route")
                        .WithMany()
                        .HasForeignKey("RouteId");
                });
        }
    }
}
