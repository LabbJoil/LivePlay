
using LivePlay.Server.Application.Background;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Application.Services;
using LivePlay.Server.Infrastructure.Authorization;
using LivePlay.Server.Infrastructure.Other;
using LivePlay.Server.Persistence.Repositories;

namespace LivePlay.Server.WebApi.ProgramExtentions;

internal static class ServiceRegistor
{
    public static void RegistryAppServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<QuestService>();
        services.AddScoped<FeedbackService>();
        services.AddScoped<NewsService>();
        services.AddScoped<HotelService>();
        services.AddScoped<CouponService>();
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
