namespace LivePlay.Server.WebApi.Contracts.Requests;

public class LoginUserRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
