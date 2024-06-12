
using LivePlay.Application.Background;
using LivePlay.Application.Interfaces;
using LivePlay.Infrastructure;
using LivePlay.Infrastructure.Authorization;
using LivePlay.Infrastructure.Other;
using LivePlay.Persistence;
using LivePlay.Persistence.Repositories;

namespace LivePlay.WebApi.ProgramExtentions;

internal static class ServiceRegistor
{
    public static void RegistryAppServices(this IServiceCollection services)
    {

    }

    public static void RegistryRepositories(this IServiceCollection services)
    {
        services.AddScoped<UserRepository>();
        services.AddScoped<PermissionRepository>();
    }

    public static void RegistryBackgrounds(this IServiceCollection services)
    {
        services.AddHostedService<RegistryUserBackground>();
    }

    public static void RegistryInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtProvider, JwtProvider>();
        services.AddSingleton<EmailProvider>();
    }
}
