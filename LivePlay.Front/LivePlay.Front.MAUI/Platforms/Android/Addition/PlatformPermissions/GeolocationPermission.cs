
using LivePlay.Front.MAUI.Interfaces;

namespace LivePlay.Front.MAUI.Platforms.PlatformPermissions;

public class GeolocationPermission : Permissions.BasePlatformPermission, IGeolocationPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions
        => [(Android.Manifest.Permission.AccessFineLocation, true),
        (Android.Manifest.Permission.AccessCoarseLocation, true)];
}
