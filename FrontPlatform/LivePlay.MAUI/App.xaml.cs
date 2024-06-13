
using LivePlay.Front.MAUI.OverApplicationSettings;
using LivePlay.Front.MAUI.Services;

namespace LivePlay.Front.MAUI;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App(DeviceDesignSettings designSettings, NavigateThrowLoading navigateThrowLoading)
    {
        InitializeComponent();
        MainPage = new AppShell(designSettings, navigateThrowLoading);
        UserAppTheme = designSettings.LoadSettings();
    }
}
