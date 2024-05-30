
using LivePlay.Core.Enums;

namespace LivePlay.Core.Models;

public class User
{
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role Role { get; set; }
    public DateTime? JoinDate { get; set; }
}
