using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.BearerToken;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using LivePlayWebApi.Models.CoreModels;
using LivePlayWebApi.Interfaces;
using LivePlayWebApi.Models.EntityModels;
using LivePlayWebApi.Enums;

namespace LivePlayWebApi.Services;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private const string ISSUER = "LivePlayServer";
    private const string AUDIENCE = "ManagersLivePlay";

    private readonly JwtOptions _jwtOptions = options.Value;

    public SymmetricSecurityKey GetSigningCredentials()
        => new(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));

    public string GenerateNewToken(Claim[] claims)
    {
        var signingCredentials = new SigningCredentials(GetSigningCredentials(), SecurityAlgorithms.HmacSha384);

        var newToken = new JwtSecurityToken(
            issuer: ISSUER,
            audience: AUDIENCE,
            claims: claims ?? throw new Exception("Claim has not been transferred"),
            expires: DateTime.UtcNow.Add(TimeSpan.FromHours(_jwtOptions.ExpitersHours)),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(newToken);
    }

    public Claim[] SetUser(UserEntityModel user)
    {
        var claims = new Claim[]
        {
            new("userId", user.Id.ToString())
        };
        return claims;
    }

    public (int, Role) GetUserIdRole(ClaimsPrincipal claimsPrincipal)
    {
        var sidClaim = claimsPrincipal.FindFirst(ClaimTypes.Sid);
        var roleClaim = claimsPrincipal.FindFirst(ClaimTypes.Role);
        if (sidClaim == null || !int.TryParse(sidClaim.Value, out int id))
            throw new Exception("ID user not transferred");
        if (roleClaim == null || !Enum.TryParse(roleClaim.Value, out Role role))
            throw new Exception("Role user not transferred");
        return (id, role);
    }

    public TokenValidationParameters GetJwtOptions()
        => new()
        {
            ValidateIssuer = true,
            ValidIssuer = ISSUER,
            ValidateAudience = true,
            ValidAudience = AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = GetSigningCredentials(),
            ValidateIssuerSigningKey = true,
        };
}
