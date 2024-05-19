
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;

namespace LivePlayMAUI.Services;

public class AppSettings(Interfaces.IStoragePermissions storagePermissions)
{
    private readonly Interfaces.IStoragePermissions _storagePermissions = storagePermissions;

    private Action<Color, StatusBarColor, Color?>? ChangeColorStatusBarsAction;
    private Action<string>? ChangeCountCoinsAction;

    public Action<Color, StatusBarColor, Color?>? ChangeColorStatusBars
    {
        get => ChangeColorStatusBarsAction;
        set => ChangeColorStatusBarsAction ??= value;
    }

    public Action<string>? ChangeCountCoins
    {
        get => ChangeCountCoinsAction;
        set => ChangeCountCoinsAction ??= value;
    }

    public AppTheme LoadSettings()
    {
        AppTheme them = AppTheme.Dark; // TODO: загрузка из JSON
        return them;
    }

    public async Task<bool> GetPermission()
    {
        PermissionStatus nowStatus = await _storagePermissions.CheckStatusAsync();
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
                //changeStatus = await Permissions.RequestAsync<StoragePermissions>();
#if __ANDROID__
                changeStatus = await _storagePermissions.RequestAsync();
#else
                changeStatus = nowStatus;
#endif
                break;
            default:
                changeStatus = PermissionStatus.Unknown;
                break;
        }

        return changeStatus switch
        {
            PermissionStatus.Granted => true,
            _ => false,
        };
    }

    public static void OpacityAnimation(IAnimatable owner, VisualElement visualElement, uint rate, uint lengthAnimation, double endOpacity, double? startOpacity = null)
    {
        var animationBackground = new Animation(v => visualElement.Opacity = v, startOpacity ?? visualElement.Opacity, endOpacity);
        animationBackground.Commit(owner, nameof(owner) + "AnimationOpacity", rate, lengthAnimation);
    }
}
