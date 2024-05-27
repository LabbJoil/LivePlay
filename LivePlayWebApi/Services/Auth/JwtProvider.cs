
using LivePlayWebApi.Interfaces;
using LivePlayWebApi.Models.EntityModels;
using LivePlayWebApi.Services.ConfigurationOptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivePlayWebApi.Services.Authorization;

public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
{
    private readonly JwtOptions _jwtOptions = options.Value;

    public  static SymmetricSecurityKey GetSigningCredentials(string secretKey)
        => new(Encoding.UTF8.GetBytes(secretKey));

    public string GenerateNewToken(Claim[] claims)
    {
        var signingCredentials = new SigningCredentials(GetSigningCredentials(_jwtOptions.SecretKey), SecurityAlgorithms.HmacSha384);

        var newToken = new JwtSecurityToken(
            issuer: _jwtOptions.ISSUER,
            audience: _jwtOptions.AUDIENCE,
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
