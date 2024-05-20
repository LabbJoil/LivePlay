using LivePlayWebApi.Interfaces;
using LivePlayWebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LivePlayWebApi.Extentions;

public static class AuthExtention
{
    public static void AddApiuthentication(this IServiceCollection services, IJwtProvider jwtProvider)
    {
        services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        options.TokenValidationParameters = jwtProvider.GetJwtOptions());
    }
}
