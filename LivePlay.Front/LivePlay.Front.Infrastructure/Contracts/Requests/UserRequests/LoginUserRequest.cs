
namespace LivePlay.Front.Infrastructure.Contracts.Requests.UserRequests;

public class LoginUserRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
