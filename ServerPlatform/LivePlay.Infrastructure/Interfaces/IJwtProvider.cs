
using System.Security.Claims;

namespace LivePlay.Application.Interfaces;

public interface IJwtProvider
{
    public string GenerateNewToken(Claim[] claims);
    public Claim[] SetUserId(string userId);
    public Guid GetUserId(ClaimsPrincipal claimsPrincipal);
}
