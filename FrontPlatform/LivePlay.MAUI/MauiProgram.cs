
using CommunityToolkit.Maui;
using LivePlayMAUI.MauiProgramExtentions;
using LivePlayMAUI.Models.Options;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Models.ViewModels.AccountViewModels;
using LivePlayMAUI.Models.ViewModels.NewsViewModels;
using LivePlayMAUI.Pages;
using LivePlayMAUI.PersonalElements;
using LivePlayMAUI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using The49.Maui.BottomSheet;

namespace LivePlayMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBottomSheet()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Raleway-Regular.ttf", "RalewayRegular");
                fonts.AddFont("Raleway-Semibold.ttf", "RalewaySemibold");
            })
            .AddAppSettings();

        var configuration = builder.Configuration;
        var services = builder.Services;

        services.RegistOverApplicationSettingsServises();
        services.RegistAccountServises();
        services.RegistQuestServises();
        services.RegistNewsServises();

        services.Configure<QuestFilterOptions>(configuration.GetSection(nameof(QuestFilterOptions)));


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
