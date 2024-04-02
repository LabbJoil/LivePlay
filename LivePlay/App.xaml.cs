
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using LivePlayMAUI.PersonalElements;
using Microsoft.Maui.ApplicationModel;
using LivePlayMAUI.Services;

namespace LivePlayMAUI;

public partial class App : Application
{
    public App()
    {
        UserAppTheme = Settings.LoadSettings();
        InitializeComponent();
        MainPage = new AppShell();
    }
}
