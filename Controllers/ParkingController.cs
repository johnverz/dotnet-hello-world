using Microsoft.AspNetCore.Mvc;
using workspace.Models;
using System.Collections.Generic;
using System.Linq;
using workspace.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace workspace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParkingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Parking
        [HttpGet]
        public IEnumerable<ParkingSpot> GetParkingSpots()
        {
            return _context.ParkingSpots;
        }

        // GET: api/Parking/5
        [HttpGet("{id}")]
        public IActionResult GetParkingSpot(int id)
        {
            var parkingSpot = _context.ParkingSpots.FirstOrDefault(p => p.Id == id);

            if (parkingSpot == null)
            {
                return NotFound();
            }

            return Ok(parkingSpot);
        }

        // POST: api/Parking/New
        [HttpPost("New")]
        public IActionResult SaveParkingSpot([FromBody] ParkingSpot parkingSpot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check for existing parking spot with the same name
            if (_context.ParkingSpots.Any(p => p.Name == parkingSpot.Name))
            {
                return BadRequest("Parking spot already exists.");
            }

            _context.ParkingSpots.Add(parkingSpot);
            _context.SaveChanges();

            return Ok(); // Return 200 status code on success
        }

        [HttpDelete("/api/Parking/Delete/{name}")]
        public async Task<IActionResult> DeleteParkingSpot(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return bad request if model state is invalid
            }

            try
            {
                var parkingSpot = await _context.ParkingSpots.FirstOrDefaultAsync(p => p.Name == name);
                if (parkingSpot == null)
                {
                    return NotFound(); // Return Not Found (404) if the parking spot with the specified name is not found
                }

                _context.ParkingSpots.Remove(parkingSpot);
                await _context.SaveChangesAsync();
                
                return NoContent(); // Return No Content (204) on successful deletion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting parking spot with name {name}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting parking spot");
            }
        }

        // Helper method to find an available parking spot at the given time range
        private async Task<ParkingSpot> FindAvailableParkingSpot(DateTime startTime, DateTime endTime)
        {
            var bookedSpots = await _context.Bookings
                .Where(b => (b.CheckInTime <= startTime && b.CheckOutTime > startTime) || (b.CheckInTime < endTime && b.CheckOutTime >= endTime))
                .Select(b => b.ParkingSpotId)
                .ToListAsync();

            var availableSpot = await _context.ParkingSpots.FirstOrDefaultAsync(p => !bookedSpots.Contains(p.Id));

            return availableSpot;
        }

        // POST: api/Parking/Book
        [HttpPost("Book")]
        public async Task<IActionResult> BookParkingSpot([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // Check if the parking spot is available at the given time
            var availableSpot = await FindAvailableParkingSpot(booking.CheckInTime, booking.CheckOutTime);

            if (availableSpot == null)
            {
                return BadRequest("No available parking spot for the given time range.");
            }
            // Console.WriteLine(booking.CheckInTime.ToString("yyyy-MM-dd HH:mm:ss"));
            // Console.WriteLine(booking.CheckOutTime.ToString("yyyy-MM-dd HH:mm:ss"));



            booking.ParkingSpotId = availableSpot.Id;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }

        public class GetBookingsByDateRequest
        {
            public string DateStr { get; set; }
        }

        [HttpPost("Bookings")]
        public IActionResult GetBookingsByDate([FromBody] GetBookingsByDateRequest request)
        {
            try
            {
                DateTime date;
                if (!DateTime.TryParseExact(request.DateStr, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out date))
                {
                    return BadRequest("Invalid date format. Please use yyyy-MM-ddTHH:mm:ss.fffZ");
                }

                var bookings = _context.Bookings
                    .Where(b => date.Date >= b.CheckInTime.Date && date.Date <= b.CheckOutTime.Date)
                    .ToList();

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching bookings: {ex.Message}");
                return StatusCode(500, "Error fetching bookings");
            }
        }

        // ... Add additional API endpoints for functionalities like booking, etc. 
    }
}