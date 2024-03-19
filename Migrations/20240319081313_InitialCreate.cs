using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workspace.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParkingSpotId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    PlateNo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlateNo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "A1" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "A2" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "A3" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "A4" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "B1" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "B2" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "B3" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "B4" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "C1" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "C2" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "C3" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "C4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
