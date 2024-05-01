
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI.Services;

internal static class Settings
{

    private static Action<Color, StatusBarColor, Color?>? ChangeColorStatusBarsAction;
    private static Action<string>? ChangeCountCoinsAction;

    public static Action<Color, StatusBarColor, Color?>? ChangeColorStatusBars
    {
        get => ChangeColorStatusBarsAction;
        set => ChangeColorStatusBarsAction ??= value;
    }

    public static Action<string>? ChangeCountCoins
    {
        get => ChangeCountCoinsAction;
        set => ChangeCountCoinsAction ??= value;
    }

    public static AppTheme LoadSettings()
    {
        AppTheme them = AppTheme.Dark; // TODO: загрузка из JSON
        SettingsModel.SetSettings(them);
        return them;
    }
}
