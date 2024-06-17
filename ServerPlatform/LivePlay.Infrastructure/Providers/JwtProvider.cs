
using LivePlay.Server.Application.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivePlay.Server.Infrastructure.Providers;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private JwtOptions JwtOptions { get; } = options.Value;

    public static SymmetricSecurityKey GetSigningCredentials(string secretKey)
        => new(Encoding.UTF8.GetBytes(secretKey));

    public string GenerateNewToken(Claim[] claims)
    {
        var signingCredentials = new SigningCredentials(GetSigningCredentials(JwtOptions.SecretKey), SecurityAlgorithms.HmacSha384);

        var newToken = new JwtSecurityToken(
            issuer: JwtOptions.ISSUER,
            audience: JwtOptions.AUDIENCE,
            claims: claims ?? throw new Exception("Claim has not been transferred"),
            expires: DateTime.UtcNow.Add(TimeSpan.FromHours(JwtOptions.ExpitersHours)),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(newToken);
    }

    public Claim[] SetUserId(string userId)
    {
        var claims = new Claim[]
        {
            new("userId", userId)
        };
        return claims;
    }

    public Guid GetUserId(ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirst(c => c.Type == "userId");
        if (userId == null || !Guid.TryParse(userId.Value, out var id))
            throw new Exception("ID user not transferred");
        return id;
    }

    public static TokenValidationParameters GetJwtOptions(JwtOptions options)
        => new()
        {
            ValidateIssuer = true,
            ValidIssuer = options.ISSUER,
            ValidateAudience = true,
            ValidAudience = options.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = GetSigningCredentials(options.SecretKey),
            ValidateIssuerSigningKey = true,
        };
}
