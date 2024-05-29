
using CommunityToolkit.Maui;
using LivePlayMAUI.Models.Options;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Models.ViewModels.AccountViewModel;
using LivePlayMAUI.Pages;
using LivePlayMAUI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace LivePlayMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .AddAppSettings();

        var configuration = builder.Configuration;
        var services = builder.Services;

        var y = configuration.GetSection(nameof(QuestFilterOptions));

        services.Configure<QuestFilterOptions>(configuration.GetSection(nameof(QuestFilterOptions)));

        services.AddSingleton<DeviceDesignSettings>();
        services.AddSingleton<DevicePermissions>();
        services.AddSingleton<DeviceStorage>();
        services.AddSingleton<NavigateThrowLoading>();

        services.AddTransient<QuestTapePage>();
        services.AddTransient<NewsTapePage>();
        services.AddTransient<NotStartedQuestPage>();
        services.AddTransient<CurrentNewsPage>();
        services.AddTransient<EnterPage>();
        services.AddTransient<LoadingPage>();

        services.AddTransient<QuestTapePageViewModel>();
        services.AddTransient<NewsTapePageViewModel>();
        services.AddTransient<CurrentNewsPageViewModel>();
        services.AddTransient<EnterPageViewModel>();

#if __ANDROID__
        services.AddSingleton<Interfaces.IStoragePermissions, Platforms.PlatformPermitions.StoragePermissions>();
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif

        Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
        {
            if (view is Entry) {
#if __ANDROID__ || __IOS__
                Platforms.VisualElementsMapper.EntryControlMapper.Map(handler, view);
#endif
            }
        });

        return builder.Build();
    }

    private static void AddAppSettings(this MauiAppBuilder builder)
    {
        using Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LivePlayMAUI.appsettings.json");
        if (stream != null)
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);
        }
    }
}
