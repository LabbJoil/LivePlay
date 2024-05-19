
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using LivePlayMAUI.PersonalElements;
using Microsoft.Maui.ApplicationModel;
using LivePlayMAUI.Services;
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI;

public partial class App : Application
{
    public App(AppSettings appSettings)
    {
        InitializeComponent();
        MainPage = new AppShell(appSettings);
        UserAppTheme = appSettings.LoadSettings();
    }
}
