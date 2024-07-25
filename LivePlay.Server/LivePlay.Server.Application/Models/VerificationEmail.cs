
namespace LivePlay.Server.Infrastructure.Background;

public class VerificationEmail
{
    public required string Email { get; set; }
    public required string Code { get; set; }
    public DateTime StartValidation { get; } = DateTime.Now;
    public bool IsApproveEmailCode { get; set; } = false;
}
