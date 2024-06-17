
using LivePlay.Front.MAUI.DeviceSettings;

namespace LivePlay.Front.MAUI;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App(AppDesign designSettings)
    {
        InitializeComponent();
        MainPage = new AppShell(designSettings);
        UserAppTheme = designSettings.LoadSettings();
    }
}
