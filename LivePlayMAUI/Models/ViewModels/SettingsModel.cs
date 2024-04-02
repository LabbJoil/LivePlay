using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.ViewModels;

internal static class SettingsModel
{
    static public string CloseEyeSVG { get; private set; }
    static public string OpenEyeSVG { get; private set; }
    static public string CloseSVG { get; private set; }

    public static void SetSettings(AppTheme them)
    {
        switch (them)
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
    }
}
