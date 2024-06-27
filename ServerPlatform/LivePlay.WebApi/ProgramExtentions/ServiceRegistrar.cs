
using LivePlay.Server.Infrastructure.Background;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Application.Services;
using LivePlay.Server.Infrastructure.Providers;
using LivePlay.Server.Persistence.Repositories;
using LivePlay.Server.Application.Facade;
using LivePlay.Server.Application.Mapping;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Infrastructure;
using LivePlay.Server.WebApi.Mapping.User;
using LivePlay.Server.WebApi.Mapping.Quests;

namespace LivePlay.Server.WebApi.ProgramExtentions;

internal static class ServiceRegistrar
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<QuestService>();
        services.AddScoped<FeedbackService>();
        services.AddScoped<NewsService>();
        services.AddScoped<HotelService>();
        services.AddScoped<CouponService>();

        services.AddSingleton<RegistrarUserFacade>();
    }

    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IQuestRepository, QuestRepository>();
        services.AddScoped<PermissionRepository>();
    }

    public static void RegisterBackgrounds(this IServiceCollection services)
    {
        services.AddHostedService<RegistrarUserBackground>();
    }

    public static void RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtProvider, JwtProvider>();
        services.AddSingleton<IQRProvider, QRProvider>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<EmailProvider>();
    }

    public static void RegisterMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserEntityMapping), typeof(QuestAddingMapping), typeof(QRQuestAddingMapping),
            typeof(UserUpdateMapping), typeof(UserRegistrationMapping));
    }
}
