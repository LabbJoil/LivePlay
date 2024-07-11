
namespace LivePlay.Server.WebApi.Contracts.Responses.UserResponses;

public class LoginResponse
{
    public required string Token { get; set; }
    public required string[] Roles {get; set; }
}
