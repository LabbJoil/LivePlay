
using Android.OS;
using System.Diagnostics.CodeAnalysis;
using LivePlay.Front.Infrastructure.Interfaces;

namespace LivePlay.Front.MAUI.Platforms.PlatformPermissions;

public class StoragePermissions : Permissions.BasePlatformPermission, IStoragePermissions
{
    [SuppressMessage("Interoperability", "CA1416:Availability")]
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions
        => Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu
        ? [
            (Android.Manifest.Permission.ReadMediaImages, true)
            ]
        : [
            (Android.Manifest.Permission.ReadExternalStorage, true),
            (Android.Manifest.Permission.WriteExternalStorage, true)
            ];
}
