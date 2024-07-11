using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingApp.Storage.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonitoredNOAALocations",
                columns: table => new
                {
                    MonitoredNOAALocationID = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StationId = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoredNOAALocations", x => x.MonitoredNOAALocationID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalGPSLocationNotes",
                columns: table => new
                {
                    PersonalGPSLocationNoteID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonalGPSLocationID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    FishingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalGPSLocationNotes", x => x.PersonalGPSLocationNoteID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalGPSLocations",
                columns: table => new
                {
                    PersonalGPSLocationID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    WaterDepth = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalGPSLocations", x => x.PersonalGPSLocationID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonitoredNOAALocations");

            migrationBuilder.DropTable(
                name: "PersonalGPSLocationNotes");

            migrationBuilder.DropTable(
                name: "PersonalGPSLocations");
        }
    }
}
