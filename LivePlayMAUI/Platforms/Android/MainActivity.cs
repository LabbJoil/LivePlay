using Android.App;
using Android.Content.PM;
using Android.OS;
using LivePlayMAUI.Models.ViewModels;
using LivePlayMAUI.Services;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace LivePlayMAUI
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            SettingsModel.ChangeColorStatusBars = ChangeBarsColor;
            base.OnCreate(savedInstanceState);
        }

        public void ChangeBarsColor(string colorName)
        {
            Android.Graphics.Color barsColor = ((SolidColorBrush)(SettingsModel.ColorResourceDictionary?[colorName] as Color ?? Color.FromArgb("#415A77"))).Color.ToAndroid();
            Window!.SetStatusBarColor(barsColor);
            Window.SetNavigationBarColor(barsColor);
        }
    }
}
