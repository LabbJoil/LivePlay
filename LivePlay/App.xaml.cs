
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using LivePlay.PersonalElements;
using Microsoft.Maui.ApplicationModel;
using LivePlay.Services;

namespace LivePlay;

public partial class App : Application
{
    public App()
    {
        UserAppTheme = Settings.LoadSettings();
        InitializeComponent();
        MainPage = new AppShell();
    }
}
