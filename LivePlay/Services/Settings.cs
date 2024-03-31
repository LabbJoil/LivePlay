
using LivePlay.Models.ViewModels;

namespace LivePlay.Services;

internal static class Settings
{
    public static AppTheme LoadSettings()
    {
        AppTheme them = AppTheme.Dark; // TODO: загрузка из JSON
        SettingsModel.SetSettings(them);
        return them;
    }
}
