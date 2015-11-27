using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace SleepTitle.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    X = table.Column<float>(nullable: false),
                    Y = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "RouteSegment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EndId = table.Column<Guid>(nullable: false),
                    StartId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteSegment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteSegment_Location_EndId",
                        column: x => x.EndId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteSegment_Location_StartId",
                        column: x => x.StartId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EndId = table.Column<Guid>(nullable: false),
                    LastRouteStatId = table.Column<Guid>(nullable: true),
                    StartId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_Location_EndId",
                        column: x => x.EndId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Route_Location_StartId",
                        column: x => x.StartId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "RouteStat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CaptureTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    RouteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteStat_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "WakeUpRoutine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RouteId = table.Column<Guid>(nullable: false),
                    ShouldArriveAt = table.Column<DateTime>(nullable: false),
                    TimeNeededAfterWakeUp = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WakeUpRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WakeUpRoutine_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_Route_RouteStat_LastRouteStatId",
                table: "Route",
                column: "LastRouteStatId",
                principalTable: "RouteStat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Route_Location_EndId", table: "Route");
            migrationBuilder.DropForeignKey(name: "FK_Route_Location_StartId", table: "Route");
            migrationBuilder.DropForeignKey(name: "FK_RouteStat_Route_RouteId", table: "RouteStat");
            migrationBuilder.DropTable("User");
            migrationBuilder.DropTable("RouteSegment");
            migrationBuilder.DropTable("WakeUpRoutine");
            migrationBuilder.DropTable("Location");
            migrationBuilder.DropTable("Route");
            migrationBuilder.DropTable("RouteStat");
        }
    }
}
