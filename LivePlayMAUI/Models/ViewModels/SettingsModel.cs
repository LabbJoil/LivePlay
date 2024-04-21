using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlayMAUI.Models.ViewModels;

internal class SettingsModel
{
    public static string CloseEyeSVG { get; private set; } = "close_eye_dark.svg";
    public static string OpenEyeSVG { get; private set; } = "open_eye_dark.svg";
    public static string CloseSVG { get; private set; } = "close_dark.svg";
    public static AppTheme AppTheme { get; private set; }

    private static ResourceDictionary? ColorsRD;                                        // Пока в нём нет смысла
    public static ResourceDictionary? ColorResourceDictionary
    {
        get => ColorsRD;
        set => ColorsRD ??= value;
    }

    private static Action<Color>? ChangeColorSB;
    public static Action<Color>? ChangeColorStatusBars
    {
        get => ChangeColorSB;
        set => ChangeColorSB ??= value;
    }

    public static void SetSettings(AppTheme them)
    {
        AppTheme = them;
        if (them == AppTheme.Light)
        {
            CloseEyeSVG = "close_eye_light.svg";
            OpenEyeSVG = "open_eye_light.svg";
            CloseSVG = "close_light.svg";
        }
    }
}
