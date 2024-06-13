
using LivePlay.Front.Core.Models.Domain;
using LivePlay.Front.MAUI.Models.ViewModels;
using LivePlay.Front.MAUI.Models.ViewModels.AccountViewModels;
using LivePlay.Front.MAUI.Models.ViewModels.NewsViewModels;
using LivePlay.Front.MAUI.Models.ViewModels.QuestViewModels;
using LivePlay.Front.MAUI.OverApplicationSettings;
using LivePlay.Front.MAUI.Pages;
using LivePlay.Front.MAUI.Pages.AdminPages;
using LivePlay.Front.MAUI.Pages.QuestPages.CreationQuestPages;
using LivePlay.Front.MAUI.Pages.ReviewPages;
using LivePlay.Front.MAUI.Pages.Reward;
using LivePlay.Front.MAUI.PersonalElements;
using LivePlay.Front.MAUI.Services;
using LivePlay.Front.MAUI.ViewModels.AccountViewModels;
using LivePlay.Front.MAUI.ViewModels.NewsViewModels;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;
using LivePlay.Front.MAUI.ViewModels.ReviewViewModels;
using LivePlay.Front.MAUI.ViewModels.SettingsViewModels;

namespace LivePlay.Front.MAUI.MauiProgramExtentions;

public static class RegisterServices
{
    public static void RegistAccountServices(this IServiceCollection services)
    {
        services.AddTransient<EnterPage>();
        services.AddTransient<LoadingPage>();
        services.AddTransient<ProfilePage>();
        services.AddTransient<MyCouponsPage>();
        services.AddTransient<SettingsPage>();
        services.AddTransient<NotificationSettingsPage>();

        services.AddTransient<EnterViewModel>();
        services.AddTransient<ProfileViewModel>();
        services.AddTransient<SettingsViewModel>();

        services.RegistAdminServices();
        services.RegistUserServices();
    }

    private static void RegistAdminServices(this IServiceCollection services)
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

        services.AddTransient<TapeFeedbackViewModel>();
        services.AddTransient<QuestionQuestModel>();
    }

    private static void RegistUserServices(this IServiceCollection services)
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

        services.AddTransient<MainViewModel>();
        services.AddTransient<CurrentNewsViewModel>();
        services.AddTransient<ReviewViewModel>();
        services.AddTransient<TapeQuestViewModel>();
        services.AddTransient<BaseQuestViewModel>();
        services.AddTransient<InProgressPhotoQuestViewModel>();
    }

    public static void RegistOverApplicationSettingsServices(this IServiceCollection services)
    {
        services.AddSingleton<DeviceDesignSettings>();
        services.AddSingleton<DevicePermissions>();
        services.AddSingleton<DeviceStorage>();
        services.AddSingleton<NavigateThrowLoading>();
    }
}
