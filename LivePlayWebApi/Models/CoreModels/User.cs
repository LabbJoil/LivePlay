using LivePlayWebApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace LivePlayWebApi.Models.CoreModels;

public class User
{
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role Role { get; set; }
    public DateTime? JoinDate { get; set; }
}
