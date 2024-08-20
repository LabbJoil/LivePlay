
using Camera.MAUI;
using CommunityToolkit.Maui;
using LivePlay.Front.MAUI.MauiProgramExtentions;
using Microsoft.Extensions.Logging;
using The49.Maui.BottomSheet;
using UraniumUI;
using ZXing.Net.Maui.Controls;

namespace LivePlay.Front.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBottomSheet()       //Maybe no
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .UseMauiCameraView()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Raleway-Regular.ttf", "RalewayRegular");
                fonts.AddFont("Raleway-Bold.ttf", "RalewayBold");
            })
            .UseBarcodeReader()
            .UseMauiMaps()
            .AddAppConfigurations();

        builder.RegisterConfiguration();

        var services = builder.Services;

        services.RegisterDeviceSettingsServices();
        services.RegisterAccountServices();
        services.RegisterHttpServices();
        services.RegisterMappingServices();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
        {
            if (view is Entry)
            {
#if __ANDROID__ || __IOS__
                Platforms.VisualElementsMapper.EntryControlMapper.Map(handler, view);
#endif
            }
            else if (view is WebView)
            {
#if __ANDROID__
                Platforms.VisualElementsMapper.WebViewControlMapper.Map(handler, view);
#endif
            }
        });

        return builder.Build();
    }
}
