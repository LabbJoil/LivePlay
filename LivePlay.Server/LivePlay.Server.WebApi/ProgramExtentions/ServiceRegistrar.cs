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
using LivePlay.Server.Persistence.Repositories;
using LivePlay.Server.Persistence.Repositories.Quests;
using Microsoft.Extensions.DependencyInjection;

namespace LivePlay.Server.WebApi.ProgramExtentions;

internal static class ServiceRegistrar
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<QuestService>();
        services.AddScoped<QRQuestService>();
        services.AddScoped<CreativeQuestService>();
        services.AddScoped<QuestionQuestService>();
        services.AddScoped<FeedbackService>();
        services.AddScoped<NewsService>();
        services.AddScoped<HotelService>();
        services.AddScoped<CouponService>();

        services.AddSingleton<BackgroundFacade>();
    }

    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IQuestRepository, QuestRepository>();
        services.AddScoped<IQRQuestRepository, QRQuestRepository>();
        services.AddScoped<ICreativeQuestRepository, CreativeQuestRepository>();
        services.AddScoped<IQuestionQuestRepository, QuestionQuestRepository>();
        services.AddScoped<ICouponRepository, CouponRepository>();
        services.AddScoped<INewsRepository, NewsRepository>();
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
        services.AddSingleton<IEmailProvider, EmailProvider>();
    }

    public static void RegisterMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Mappings.UserMapping), typeof(Mappings.NewsMapping), typeof(Mappings.QuestMappings.QuestMapping),
            typeof(Mappings.QuestMappings.QRQuestMapping), typeof(Mappings.QuestMappings.QuestionQuestMapping), typeof(Mappings.QuestMappings.CreativeQuestMapping));
        
        services.AddAutoMapper(typeof(Persistence.Mappings.UserMapping), typeof(Persistence.Mappings.CouponMapping), typeof(Persistence.Mappings.NewsMapping),
            typeof(Persistence.Mappings.QuestMapping), typeof(Persistence.Mappings.QuestionQuestMapping), typeof(Persistence.Mappings.QRQuestMapping), typeof(Persistence.Mappings.CreativeQuestMapping),
            typeof(Persistence.Mappings.HotelMapping), typeof(Persistence.Mappings.FeedbackMapping));
    }
}
