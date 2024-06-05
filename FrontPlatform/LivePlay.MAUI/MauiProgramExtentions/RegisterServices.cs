
using LivePlayMAUI.Models.Domain;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Models.ViewModels.AccountViewModels;
using LivePlayMAUI.Models.ViewModels.NewsViewModels;
using LivePlayMAUI.Models.ViewModels.QuestViewModels;
using LivePlayMAUI.Pages;
using LivePlayMAUI.Pages.QuestPages.CreationQuestPages;
using LivePlayMAUI.PersonalElements;
using LivePlayMAUI.Services;

namespace LivePlayMAUI.MauiProgramExtentions;

public static class RegisterServices
{
    public static void RegistQuestServises(this IServiceCollection services)
    {
        services.AddTransient<TapeQuestPage>();
        services.AddTransient<NotStartedQuestPage>();
        services.AddTransient<InProgressPhotoQuestPage>();
        services.AddTransient<InProgressQRQuestPage>();
        services.AddTransient<InProgressQuizQuestPage>();

        services.AddTransient<MainCreationQuestPage>();
        services.AddTransient<QuestionCreationQuestPage>();
        services.AddTransient<QuestionQuestModel>();

        services.AddTransient<TapeQuestViewModel>();
        services.AddTransient<BaseQuestViewModel>();
        services.AddTransient<InProgressPhotoQuestViewModel>();
    }

    public static void RegistAccountServises(this IServiceCollection services)
    {
        services.AddTransient<EnterPage>();
        services.AddTransient<LoadingPage>();
        services.AddTransient<ProfilePage>();

        services.AddTransient<EnterViewModel>();
        services.AddTransient<ProfileViewModel>();
    }

    public static void RegistNewsServises(this IServiceCollection services)
    {
        services.AddTransient<MainPage>();
        services.AddTransient<CurrentNewsPage>();

        services.AddTransient<MainViewModel>();
        services.AddTransient<CurrentNewsViewModel>();
    }

    public static void RegistOverApplicationSettingsServises(this IServiceCollection services)
    {
        services.AddSingleton<DeviceDesignSettings>();
        services.AddSingleton<DevicePermissions>();
        services.AddSingleton<DeviceStorage>();
        services.AddSingleton<NavigateThrowLoading>();
    }
}
