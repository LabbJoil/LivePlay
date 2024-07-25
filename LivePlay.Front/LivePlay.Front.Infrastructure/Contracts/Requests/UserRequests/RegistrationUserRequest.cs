
namespace LivePlay.Front.Infrastructure.Contracts.Requests.UserRequests;

public class RegistrationUserRequest
{
    public required string FirstName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public required string Password { get; set; }
}
