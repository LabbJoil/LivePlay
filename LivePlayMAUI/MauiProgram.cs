
using CommunityToolkit.Maui;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Pages;
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

        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<NewsTapePage>();
        builder.Services.AddTransient<NewsTapeViewModel>();

        builder.Services.AddTransient<QuestTapePage>();
        builder.Services.AddTransient<QuestTapeViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
        {
            if (view is Entry) {
#if __ANDROID__ || __IOS__
                Platforms.EntryControlMapper.Map(handler, view);
#endif
            }
        });

        return builder.Build();
    }
}
