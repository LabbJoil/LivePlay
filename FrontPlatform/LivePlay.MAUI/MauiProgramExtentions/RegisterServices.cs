
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Models.ViewModels.AccountViewModels;
using LivePlayMAUI.Models.ViewModels.NewsViewModels;
using LivePlayMAUI.Models.ViewModels.QuestViewModels;
using LivePlayMAUI.Models.ViewModels.ReviewViewModels;
using LivePlayMAUI.Pages;
using LivePlayMAUI.Pages.AdminPages;
using LivePlayMAUI.Pages.QuestPages.CreationQuestPages;
using LivePlayMAUI.Pages.ReviewPages;
using LivePlayMAUI.Pages.Reward;
using LivePlayMAUI.PersonalElements;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.MauiProgramExtentions;

public static class RegisterServices
{
    public static void RegistAccountServices(this IServiceCollection services)
    {
        services.AddTransient<EnterPage>();
        services.AddTransient<LoadingPage>();
        services.AddTransient<ProfilePage>();

        services.AddTransient<EnterViewModel>();
        services.AddTransient<ProfileViewModel>();

        services.RegistAdminServices();
        services.RegistUserServices();
    }

    private static void RegistAdminServices(this IServiceCollection services)
    {
        services.AddTransient<TapeFeedbackPage>();
        services.AddTransient<CurrentFeedbackPage>();
        services.AddTransient<MainCreationQuestPage>();
        services.AddTransient<QuestionCreationQuestPage>();
        services.AddTransient<ManageQuestPage>();

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
