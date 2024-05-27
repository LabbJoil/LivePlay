using LivePlayWebApi.Models.EntityModels;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace LivePlayWebApi.Interfaces;

public interface IJwtProvider
{
    public string GenerateNewToken(Claim[] claims);
    public Claim[] SetUser(UserEntityModel user);
    public Guid GetUserId(ClaimsPrincipal claimsPrincipal);
}
