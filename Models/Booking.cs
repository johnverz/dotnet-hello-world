using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workspace.Models;
public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    //public int VehicleId { get; set; }
    public int ParkingSpotId { get; set; }
    public DateTime BookingTime { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime CheckOutTime { get; set; }
    public decimal TotalPrice { get; set; }
    public string PlateNo {get; set;}
}
