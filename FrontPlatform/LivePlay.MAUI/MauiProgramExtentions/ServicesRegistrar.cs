
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Application.HttpServices;
using LivePlay.Front.Application.Interfaces;
using LivePlay.Front.Application.Mapping;
using LivePlay.Front.MAUI.Services;
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
using LivePlay.Front.MAUI.ViewModels.AdminViewModels;
using LivePlay.Front.MAUI.ViewModels.NewsViewModels;
using LivePlay.Front.MAUI.ViewModels.QuestViewModels;
using LivePlay.Front.MAUI.ViewModels.SettingsViewModels;
using LivePlay.Front.MAUI.ViewModels.Reward;
using LivePlay.Front.MAUI.ViewModels.Users.Feedbacks;

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

        services.AddTransient<EnterViewModel>();
        services.AddTransient<ProfileViewModel>();
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
        services.AddTransient<ManageRewardPage>();
        services.AddTransient<MainCreationRewardPage>();

        services.AddTransient<TapeFeedbackPageViewModel>();
        services.AddTransient<QuestionQuest>();
        services.AddTransient<CreationQuestionQuestPageViewModel>();
        services.AddTransient<ManageQuestViewModel>();
        services.AddTransient<CreationQuestPageViewModel>();
    }

    private static void RegisterUserServices(this IServiceCollection services)
    {
        services.AddTransient<MainPage>();
        services.AddTransient<CurrentNewsPage>();
        services.AddTransient<ReviewPage>(); 
        services.AddTransient<CouponInfoPage>();
        services.AddTransient<TapeQuestPage>();
        services.AddTransient<NotStartedQuestPage>();
        services.AddTransient<InProgressDrawingQuestPage>();
        services.AddTransient<InProgressQRQuestPage>();
        services.AddTransient<InProgressQuestionQuestPage>();
        services.AddTransient<GettingStatisticsPage>();
        services.AddTransient<MainRewardPage>();

        services.AddTransient<MainViewModel>();
        services.AddTransient<CurrentNewsPageViewModel>();
        services.AddTransient<FeedbackViewModel>();
        services.AddTransient<TapeQuestPageViewModel>();
        services.AddTransient<BaseQuestPageViewModel>();
        services.AddTransient<InProgressPhotoQuestPageViewModel>();
        services.AddTransient<InProgressQuestionQuestPageViewModel>();
        services.AddTransient<CouponInfoPageViewModel>();
        services.AddTransient<MainRewardPageViewModel>();
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

    public static void RegisterMappingServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ErrorMapping));
    }
}
