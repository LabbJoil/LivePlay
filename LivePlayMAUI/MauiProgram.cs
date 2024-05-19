
using CommunityToolkit.Maui;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Pages;
using LivePlayMAUI.Services;
using Microsoft.Extensions.Logging;

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
            });


        builder.Services.AddSingleton<AppSettings>();

        builder.Services.AddTransient<QuestTapePage>();
        builder.Services.AddTransient<NewsTapePage>();
        builder.Services.AddTransient<CurrentQuestPage>();
        builder.Services.AddTransient<CurrentNewsPage>();
        builder.Services.AddTransient<EnterPage>();

        builder.Services.AddTransient<QuestTapePageViewModel>();
        builder.Services.AddTransient<NewsTapePageViewModel>();
        builder.Services.AddTransient<CurrentNewsPageViewModel>();
        builder.Services.AddTransient<EnterPageViewModel>();

#if __ANDROID__
        builder.Services.AddSingleton<Interfaces.IStoragePermissions, Platforms.PlatformPermitions.StoragePermissions>();
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
}
