
using LivePlay.Front.MAUI.OverApplicationSettings;
using LivePlay.Front.Application.DeviceSettings;

namespace LivePlay.Front.MAUI;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App(AppDesign designSettings, NavigateThrowLoading navigateThrowLoading)
    {
        InitializeComponent();
        MainPage = new AppShell(designSettings, navigateThrowLoading);
        UserAppTheme = designSettings.LoadSettings();
    }
}
