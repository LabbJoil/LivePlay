
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Options;
using LivePlay.Server.Infrastructure.Providers;
using LivePlay.Server.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace LivePlay.Server.WebApi.Extentions;

public static class AuthExtention
{
    public static void AddApiAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        JwtOptions jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>() ??
            throw new Exception();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = JwtProvider.GetJwtOptions(jwtOptions);

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["tok-cookies"];
                        return Task.CompletedTask;
                    }
                };
            });

        services.AddSingleton<IAuthorizationHandler, PermissionAuthHandler>();
    }

    public static void AddApiPolitics(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy(nameof(Politic.EditQuest), policy =>
                 policy.AddRequirements(new PermissionProvider(Politic.EditQuest)))
            .AddPolicy(nameof(Politic.EditCoupon), policy =>
                 policy.AddRequirements(new PermissionProvider(Politic.EditCoupon)))
            .AddPolicy(nameof(Politic.PersonalInfo), policy =>
                 policy.AddRequirements(new PermissionProvider(Politic.PersonalInfo)));
    }
}
