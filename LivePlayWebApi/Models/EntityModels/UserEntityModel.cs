
using LivePlayWebApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivePlayWebApi.Models.EntityModels;

[Table("User")]
public class UserEntityModel
{
    [Key, Required]
    public int Id { get; set; }
    [Required]
    public string? PasswordHash { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [Required]
    public UserRole Role { get; set; }
    [Required]
    public DateTime? JoinDate { get; set; }
}
