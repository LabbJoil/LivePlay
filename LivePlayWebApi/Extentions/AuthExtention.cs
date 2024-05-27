using LivePlayWebApi.Enums;
using LivePlayWebApi.Interfaces;
using LivePlayWebApi.Models.EntityModels;
using LivePlayWebApi.Services;
using LivePlayWebApi.Services.Auth;
using LivePlayWebApi.Services.Authorization;
using LivePlayWebApi.Services.ConfigurationOptions;
using LivePlayWebApi.Services.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace LivePlayWebApi.Extentions;

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
        //services.AddAuthorization();
    }

    public static void AddApiPolitics(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(nameof(Politic.OnlyRead), policy =>
                 policy.AddRequirements(new PermissionProvider(Politic.OnlyRead)));

            options.AddPolicy(nameof(Politic.Edit), policy =>
                 policy.AddRequirements(new PermissionProvider(Politic.Edit)));
        });
        //services.AddAuthorizationBuilder()
        //    .AddPolicy(nameof(Politic.OnlyRead), policy =>
        //         policy.Requirements.Add(new PermissionProvider(Politic.OnlyRead)));

        //services.AddAuthorizationBuilder()
        //    .AddPolicy(nameof(Politic.Edit), policy =>
        //         policy.AddRequirements(new PermissionProvider(Politic.Edit)));
    }
}
