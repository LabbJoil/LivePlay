using Android.App;
using Android.Content.PM;
using Android.OS;
using CommunityToolkit.Maui.Core;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Services;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using System.Diagnostics.CodeAnalysis;

namespace LivePlayMAUI;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        if (IPlatformApplication.Current?.Services.GetService<DeviceDesignSettings>() is DeviceDesignSettings appSettings)
            appSettings.ChangeColorStatusBars = ChangeBarsColor;
        base.OnCreate(savedInstanceState);
    }

    [SuppressMessage("Interoperability", "CA1416:Availability")]
    private void ChangeBarsColor(Color colorNavigationBar, StatusBarColor barsColorStatus = StatusBarColor.BarWhite, Color? colorStatusBar = null)
    {
        Android.Graphics.Color androidColorNavigationBar = ((SolidColorBrush)colorNavigationBar).Color.ToAndroid();
        var androidColorStatusBar = barsColorStatus switch
        {
            StatusBarColor.BarWhite => Android.Graphics.Color.White,
            StatusBarColor.DifferentColor when colorStatusBar != null => ((SolidColorBrush)colorStatusBar).Color.ToAndroid(),
            StatusBarColor.BarReplay or _ => androidColorNavigationBar,
        };
        Window!.SetNavigationBarColor(androidColorNavigationBar);
        Window!.SetStatusBarColor(androidColorStatusBar);

        if (DeviceInfo.Version.Major >= 8)
            CommunityToolkit.Maui.Core.Platform.StatusBar.SetStyle(GetBright(androidColorStatusBar) < 0.5 ? StatusBarStyle.LightContent : StatusBarStyle.DarkContent);
    }

    private static double GetBright(Android.Graphics.Color color)
    {
        return (0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B) / 255;
    }
}
