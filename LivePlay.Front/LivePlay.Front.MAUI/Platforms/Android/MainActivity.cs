
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using CommunityToolkit.Maui.Core;
using LivePlay.Front.MAUI.DeviceSettings;
using LivePlay.Front.Core.Enums;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using System.Diagnostics.CodeAnalysis;

namespace LivePlay.Front.MAUI;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        if (IPlatformApplication.Current?.Services.GetService<AppDesign>() is AppDesign appSettings)
            appSettings.ChangeColorStatusBars = ChangeBarsColor;
        base.OnCreate(savedInstanceState);
        Window?.SetSoftInputMode(SoftInput.AdjustResize);
        ChangeBarsColor(Colors.Black);
    }

    [SuppressMessage("Interoperability", "CA1416:Availability")]
    private void ChangeBarsColor(Color? colorNavigationBar = null, Color? colorStatusBar = null, bool barReplay = true)
    {
        if (barReplay && colorStatusBar == null)
            colorStatusBar = colorNavigationBar;
        if (colorNavigationBar != null)
        {
            Android.Graphics.Color androidColorNavigationBar = ((SolidColorBrush)colorNavigationBar).Color.ToAndroid();
            Window!.SetNavigationBarColor(androidColorNavigationBar);
        }
        if (colorStatusBar != null)
        {
            Android.Graphics.Color androidColorStatusBar = ((SolidColorBrush)colorStatusBar).Color.ToAndroid();
            Window!.SetStatusBarColor(androidColorStatusBar);
            if (DeviceInfo.Version.Major >= 8)
                CommunityToolkit.Maui.Core.Platform.StatusBar.SetStyle(GetBright(androidColorStatusBar) < 0.5 ? StatusBarStyle.LightContent : StatusBarStyle.DarkContent);
        }
    }

    private static double GetBright(Android.Graphics.Color color)
        => (0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B) / 255;
}
