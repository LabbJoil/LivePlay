namespace LivePlayApplication.Contracts;

public class LoginUserRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
}
