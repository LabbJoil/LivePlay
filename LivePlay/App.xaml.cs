
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
                CloseEyeSVG = "close_eye_dark";
                OpenEyeSVG = "open_eye_dark";
                CloseSVG = "close_dark";

                break;
            default:
                CloseEyeSVG = "close_eye_light";
                OpenEyeSVG = "open_eye_light";
                CloseSVG = "close_light";
                break;
        }
        MainPage = new AppShell();
    }
}
