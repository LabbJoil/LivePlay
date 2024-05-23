using LivePlayWebApi.Interfaces;
using LivePlayWebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace LivePlayWebApi.Extentions;

public static class AuthExtention
{
    public static void AddApiuthentication(this IServiceCollection services, IJwtProvider jwtProvider)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = jwtProvider.GetJwtOptions();

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["tok-cookies"];
                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization();
    }
}
