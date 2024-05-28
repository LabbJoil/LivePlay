
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using LivePlayMAUI.Models.Enum;
using LivePlayMAUI.Models.ViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LivePlayMAUI.Services;

public class OverApplicationSettings(Interfaces.IStoragePermissions storagePermissions)
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

    public async Task GetSelectItemsStorage()
    {
        var fileSaveResult = await FilePicker.Default.PickMultipleAsync();
        if (fileSaveResult != null)
        {
            await Toast.Make($"File is get").Show();
        }
        else
        {
            await Toast.Make($"File is not get").Show();
        }
    }

    [SuppressMessage("Interoperability", "CA1416:Availability")]
    public async void SaveFile(string nameFile, byte[] writeBytes)
    {
        using var stream = new MemoryStream(writeBytes);

#if IOS14_0_OR_GREATER || __ANDROID__
        var fileSaveResult = await FileSaver.Default.SaveAsync(nameFile, stream);
        if (fileSaveResult.IsSuccessful)
        {
            await Toast.Make($"File is saved: {fileSaveResult.FilePath.Split('0')[1]}").Show();
        }
        else
        {
            await Toast.Make($"File is not saved, {fileSaveResult.Exception.Message}").Show();
        }
#endif
    }
}
