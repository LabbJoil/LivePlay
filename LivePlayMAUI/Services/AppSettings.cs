
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI.Services;

internal static class AppSettings
{

    private static Action<Color, StatusBarColor, Color?>? ChangeColorStatusBarsAction;
    private static Action<string>? ChangeCountCoinsAction;

    public static PermissionStatus PermissionStorageRead { get; private set; }
    public static PermissionStatus PermissionStorageWrite { get; private set; }

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

    //public static bool CheckPermissions()
    //{
    //    if (PermissionStorageRead != PermissionStatus.Granted)  // add PermissionStorageWrite
    //    {
    //        PermissionStorageRead = GetPermission().Result;
    //    }
    //}

    public static async Task<bool> GetPermission()
    {
        PermissionStatus nowStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
        PermissionStatus changeStatus;
        switch (nowStatus)
        {
            case PermissionStatus.Granted:
                return true;
            case PermissionStatus.Disabled:
                return false;

            case PermissionStatus.Denied:
            case PermissionStatus.Unknown:
            case PermissionStatus.Limited:
            case PermissionStatus.Restricted:
                changeStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
                break;
            default:
                changeStatus = PermissionStatus.Unknown;
                break;
        }

        switch (changeStatus)
        {
            case PermissionStatus.Granted:
                return true;
            default:
                return false;
        }
    }

    public static void OpacityAnimation(IAnimatable owner, VisualElement visualElement, uint rate, uint lengthAnimation, double endOpacity, double? startOpacity = null)
    {
        var animationBackground = new Animation(v => visualElement.Opacity = v, startOpacity ?? visualElement.Opacity, endOpacity);
        animationBackground.Commit(owner, nameof(owner) + "AnimationOpacity", rate, lengthAnimation);
    }
}
