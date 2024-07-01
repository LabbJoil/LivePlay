
using LivePlay.Front.Infrastructure.Interfaces;

namespace LivePlay.Front.MAUI.DeviceSettings;

public class AppPermissions (IStoragePermissions storagePermissions)
{
    private readonly IStoragePermissions StoragePermissions = storagePermissions;

    public async Task<bool> GetPermission()
    {
        PermissionStatus nowStatus = await StoragePermissions.CheckStatusAsync();
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
                changeStatus = await StoragePermissions.RequestAsync();
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
}
