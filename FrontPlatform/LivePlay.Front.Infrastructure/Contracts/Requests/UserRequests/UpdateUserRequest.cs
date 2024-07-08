
namespace LivePlay.Front.Infrastructure.Contracts.Requests.UserRequests;

public class UpdateUserRequest
{
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
