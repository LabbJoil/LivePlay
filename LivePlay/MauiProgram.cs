
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
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<TapePage>();
        builder.Services.AddSingleton<LoginViewModel>();

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
