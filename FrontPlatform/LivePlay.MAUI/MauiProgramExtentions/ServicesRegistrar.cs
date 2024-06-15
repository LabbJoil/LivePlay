
using LivePlay.Front.Application.DeviceSettings;
using LivePlay.Front.Application.HttpServices;
using LivePlay.Front.Application.Interfaces;
using LivePlay.Front.Application.Services;
using LivePlay.Front.Core.Models;
using LivePlay.Front.MAUI.Models.ViewModels;
using LivePlay.Front.MAUI.Models.ViewModels.AccountViewModels;
using LivePlay.Front.MAUI.Models.ViewModels.NewsViewModels;
using LivePlay.Front.MAUI.Models.ViewModels.QuestViewModels;
using LivePlay.Front.MAUI.Pages;
using LivePlay.Front.MAUI.Pages.AdminPages;
using LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;
using LivePlay.Front.MAUI.Pages.ReviewPages;
using LivePlay.Front.MAUI.Pages.Reward;
using LivePlay.Front.MAUI.Services.HttpServices;
using LivePlay.Front.MAUI.ViewModels.AccountViewModels;
using LivePlay.Front.MAUI.ViewModels.NewsViewModels;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;
using LivePlay.Front.MAUI.ViewModels.ReviewViewModels;
using LivePlay.Front.MAUI.ViewModels.SettingsViewModels;

namespace LivePlay.Front.MAUI.MauiProgramExtentions;

public static class ServicesRegistrar
{
    public static void RegisterAccountServices(this IServiceCollection services)
    {
        services.AddTransient<EnterPage>();
        services.AddTransient<LoadingPage>();
        services.AddTransient<ProfilePage>();
        services.AddTransient<MyCouponsPage>();
        services.AddTransient<SettingsPage>();
        services.AddTransient<NotificationSettingsPage>();

        services.AddTransient<EnterPageViewModel>();
        services.AddTransient<ProfilePageViewModel>();
        services.AddTransient<SettingsPageViewModel>();

        services.RegisterAdminServices();
        services.RegisterUserServices();
    }

    private static void RegisterAdminServices(this IServiceCollection services)
    {
        services.AddTransient<TapeFeedbackPage>();
        services.AddTransient<CurrentFeedbackPage>();
        services.AddTransient<MainCreationQuestPage>();
        services.AddTransient<QuestionCreationQuestPage>();
        services.AddTransient<QRcodeCreationQuestPage>();
        services.AddTransient<CreativeQuestCreationQuestPage>();
        services.AddTransient<ManageQuestPage>();
        services.AddTransient<ManageRewardPage>();
        services.AddTransient<MainCreationRewardPage>();
        services.AddTransient<AdminProfilePage>();

        services.AddTransient<TapeFeedbackPageViewModel>();
        services.AddTransient<QuestionQuestModel>();
    }

    private static void RegisterUserServices(this IServiceCollection services)
    {
        services.AddTransient<MainPage>();
        services.AddTransient<CurrentNewsPage>();
        services.AddTransient<ReviewPage>(); 
        services.AddTransient<CouponInfoPage>();
        services.AddTransient<TapeQuestPage>();
        services.AddTransient<NotStartedQuestPage>();
        services.AddTransient<InProgressPhotoQuestPage>();
        services.AddTransient<InProgressQRQuestPage>();
        services.AddTransient<InProgressQuizQuestPage>();
        services.AddTransient<GettingStatisticsPage>();

        services.AddTransient<MainPageViewModel>();
        services.AddTransient<CurrentNewsPageViewModel>();
        services.AddTransient<ReviewPageViewModel>();
        services.AddTransient<TapeQuestPageViewModel>();
        services.AddTransient<BaseQuestPageViewModel>();
        services.AddTransient<InProgressPhotoQuestPageViewModel>();
    }

    public static void RegisterDeviceSettingsServices(this IServiceCollection services)
    {
        services.AddSingleton<AppDesign>();
        services.AddSingleton<AppPermissions>();
        services.AddSingleton<AppStorage>();

#if __ANDROID__
        services.AddSingleton<IStoragePermissions, Platforms.PlatformPermitions.StoragePermissions>();
#endif
    }

    public static void RegisterHttpServices(this IServiceCollection services)
    {
        services.AddSingleton<UserHttpService>();
        services.AddSingleton<QuestHttpService>();
        services.AddSingleton<IHttpProvider, HttpProvider>();
    }
}
