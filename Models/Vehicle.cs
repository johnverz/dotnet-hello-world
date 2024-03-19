using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace workspace.Models;
using System.ComponentModel.DataAnnotations;

public class Vehicle
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string PlateNo { get; set; }
    // public string? FirstName { get; set; }
    // public string? LastName { get; set; }
    // public string? Phone { get; set; }
}
