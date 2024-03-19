using Microsoft.EntityFrameworkCore;
using workspace.Models;

namespace workspace.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ParkingSpot>? ParkingSpots { get; set; }
        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<Booking>? Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ParkingSpot>()
            .HasData(
                new { Id = 1, Name = "A1" }, // No need to specify Id, it will be auto-generated
                new { Id = 2, Name = "A2" },
                new { Id = 3, Name = "A3" },
                new { Id = 4, Name = "A4" },
                new { Id = 5, Name = "B1" },
                new { Id = 6, Name = "B2" },
                new { Id = 7, Name = "B3" },
                new { Id = 8, Name = "B4" },
                new { Id = 9, Name = "C1" },
                new { Id = 10, Name = "C2" },
                new { Id = 11, Name = "C3" },   
                new { Id = 12, Name = "C4" }  // No Id provided here as well
                
            );
        }

    }
}