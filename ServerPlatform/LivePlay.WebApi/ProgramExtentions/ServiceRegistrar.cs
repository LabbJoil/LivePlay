﻿
using LivePlay.Server.Application.Facade;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Application.Services;
using LivePlay.Server.Application.Services.QuestServices;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Interfaces.QuestInterfaces;
using LivePlay.Server.Infrastructure;
using LivePlay.Server.Infrastructure.Background;
using LivePlay.Server.Infrastructure.Providers;
using LivePlay.Server.Persistence.Mappings;
using LivePlay.Server.Persistence.Repositories;
using LivePlay.Server.Persistence.Repositories.Quests;
using LivePlay.Server.WebApi.Mappings.QuestMappings;
using LivePlay.Server.WebApi.Mappings.UserMappings;

namespace LivePlay.Server.WebApi.ProgramExtentions;

internal static class ServiceRegistrar
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<QuestService>();
        services.AddScoped<QRQuestService>();
        services.AddScoped<CreativeQuestService>();
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
        services.AddScoped<IQRQuestRepository, QRQuestRepository>();
        services.AddScoped<ICreativeQuestRepository, CreativeQuestRepository>();
        services.AddScoped<ICouponRepository, CouponRepository>();
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
