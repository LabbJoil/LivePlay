
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("Hotel")]
public class HotelEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public int Name { get; set;}
    [Required]
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
}
