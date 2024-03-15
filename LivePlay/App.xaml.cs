
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using LivePlay.PersonalElements;
using Microsoft.Maui.ApplicationModel;

namespace LivePlay;

public partial class App : Application
{
    public string CloseEyeSVG;
    public string OpenEyeSVG;
    public string CloseSVG;

    public App()
    {
        InitializeComponent();
        switch (RequestedTheme)
        {
            case AppTheme.Unspecified or AppTheme.Dark:
                CloseEyeSVG = "close_eye_dark.svg";
                OpenEyeSVG = "open_eye_dark.svg";
                CloseSVG = "close_dark.svg";

                break;
            default:
                CloseEyeSVG = "close_eye_light.svg";
                OpenEyeSVG = "open_eye_light.svg";
                CloseSVG = "close_light.svg";
                break;
        }
        MainPage = new AppShell();
    }
}
