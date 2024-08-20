
using LivePlay.Front.MAUI.Interfaces;

namespace LivePlay.Front.MAUI.DeviceSettings;

public class AppPermissions (IStoragePermission storagePermissions, IGeolocationPermission geolocationPermission)
{
    private readonly IStoragePermission _storagePermission = storagePermissions;
    private readonly IGeolocationPermission _geolocationPermission = geolocationPermission;

    public async Task<bool> GetPermission()
    {
        List<bool> isAccess = [ await CheckPermissions(_storagePermission), await CheckPermissions(_geolocationPermission)];
        if (isAccess.All(a => a == true))
            return true;
        return false;
    }

    private static async Task<bool> CheckPermissions(IAccessPermission accessPermission)
    {
        PermissionStatus nowStatus = await accessPermission.CheckStatusAsync();
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
                changeStatus = await accessPermission.RequestAsync();
#else
                changeStatus = nowStatus;
#endif
                break;
            default:
                changeStatus = PermissionStatus.Unknown;
                break;
        }

        if (changeStatus == PermissionStatus.Granted)
            return true;
        return false;
    }
}
