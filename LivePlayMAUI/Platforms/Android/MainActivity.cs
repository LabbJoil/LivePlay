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

        public void ChangeBarsColor(Color color)
        {
            Android.Graphics.Color barsColor = ((SolidColorBrush)color).Color.ToAndroid();
            Window!.SetStatusBarColor(barsColor);
            Window.SetNavigationBarColor(barsColor);
        }
    }
}
