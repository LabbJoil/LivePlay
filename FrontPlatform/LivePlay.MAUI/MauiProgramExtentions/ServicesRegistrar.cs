
using LivePlay.Front.Infrastructure.HttpServices;
using LivePlay.Front.Infrastructure.HttpServices.QuestHttpServices;
using LivePlay.Front.Infrastructure.Interfaces;
using LivePlay.Front.Infrastructure.Mappings;
using LivePlay.Front.Core.Models.QuestModels;
using LivePlay.Front.Infrastructure;
using LivePlay.Front.MAUI.Abstracts;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.MAUI.Pages.AdminPages.CouponPages.Views;
using LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.ViewModels;
using LivePlay.Front.MAUI.Pages.AdminPages.FeedbackPages.Views;
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.ViewModels;
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Creations.Views;
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Manages.ViewModels;
using LivePlay.Front.MAUI.Pages.AdminPages.QuestPages.Manages.Views;
using LivePlay.Front.MAUI.Pages.AdminPages.StatisticPages.Views;
using LivePlay.Front.MAUI.Pages.EnterPages.ViewModels;
using LivePlay.Front.MAUI.Pages.EnterPages.Views;
using LivePlay.Front.MAUI.Pages.SettingsPages.ViewModels;
using LivePlay.Front.MAUI.Pages.SettingsPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.ViewModels;
using LivePlay.Front.MAUI.Pages.UserPages.AccountPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.CouponPages.ViewModels;
using LivePlay.Front.MAUI.Pages.UserPages.CouponPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.FeedbackPages.ViewModels;
using LivePlay.Front.MAUI.Pages.UserPages.FeedbackPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.NewsPages.Views;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.ViewModels;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.InProgress.Views;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.NotStarted.ViewModels;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.NotStarted.Views;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.Tape.ViewModels;
using LivePlay.Front.MAUI.Pages.UserPages.QuestPages.Tape.Views;
using LivePlay.Front.MAUI.ViewModels.NewsViewModels;

namespace LivePlay.Front.MAUI.MauiProgramExtentions;

public static class ServicesRegistrar
{
    public static void RegisterAccountServices(this IServiceCollection services)
    {
        services.AddTransient<EnterPage>();
        services.AddTransient<LoadingPage>();
        services.AddTransient<SettingsPage>();

        services.AddTransient<EnterViewModel>();
        services.AddTransient<SettingsViewModel>();

        services.RegisterAdminServices();
        services.RegisterUserServices();
    }

    private static void RegisterAdminServices(this IServiceCollection services)
    {
        services.AddTransient<TapeFeedbackPage>();
        services.AddTransient<CurrentFeedbackPage>();
        services.AddTransient<CreationQuestPage>();
        services.AddTransient<CreationQuestionQuestPage>();
        services.AddTransient<CreationQRQuestPage>();
        services.AddTransient<CreationCreativeQuestPage>();
        services.AddTransient<ManageQuestPage>();
        services.AddTransient<ManageCouponPage>();
        services.AddTransient<CreationCouponPage>();
        services.AddTransient<ProfilePage>();
        services.AddTransient<MyCouponsPage>();
        services.AddTransient<NotificationSettingsPage>();

        services.AddTransient<TapeFeedbackViewModel>();
        services.AddTransient<QuestionQuest>();
        services.AddTransient<CreationQuestionQuestViewModel>();
        services.AddTransient<ManageQuestViewModel>();
        services.AddTransient<CreationQuestViewModel>();
        services.AddTransient<ProfileViewModel>();
    }

    private static void RegisterUserServices(this IServiceCollection services)
    {
        services.AddTransient<MainPage>();
        services.AddTransient<CurrentNewsPage>();
        services.AddTransient<FeedbackPage>(); 
        services.AddTransient<CouponInfoPage>();
        services.AddTransient<TapeQuestPage>();
        services.AddTransient<NotStartedQuestPage>();
        services.AddTransient<InProgressDrawingQuestPage>();
        services.AddTransient<InProgressQRQuestPage>();
        services.AddTransient<InProgressQuestionQuestPage>();
        services.AddTransient<GettingStatisticsPage>();
        services.AddTransient<MainCouponPage>();

        services.AddTransient<BaseViewModel>();
        services.AddTransient<CurrentNewsPageViewModel>();
        services.AddTransient<FeedbackViewModel>();
        services.AddTransient<TapeQuestViewModel>();
        services.AddTransient<NotStartedQuestViewModel>();
        services.AddTransient<InProgressQRQuestViewModel>();
        services.AddTransient<InProgressDrawingQuestViewModel>();
        services.AddTransient<InProgressQuestionQuestViewModel>();
        services.AddTransient<CouponInfoViewModel>();
        services.AddTransient<MainRewardViewModel>();
    }

    public static void RegisterDeviceSettingsServices(this IServiceCollection services)
    {
        services.AddSingleton<AppDesign>();
        services.AddSingleton<AppPermissions>();
        services.AddSingleton<AppStorage>();
#if __ANDROID__
        services.AddSingleton<IStoragePermissions, Platforms.PlatformPermissions.StoragePermissions>();
#endif
    }

    public static void RegisterHttpServices(this IServiceCollection services)
    {
        services.AddSingleton<UserHttpService>();
        services.AddSingleton<QuestHttpService>();
        services.AddSingleton<HttpProvider>();
    }

    public static void RegisterMappingServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ErrorMapping));
    }
}
