
using Android.OS;
using System.Diagnostics.CodeAnalysis;

namespace LivePlayMAUI.Platforms.PlatformPermitions;

public class StoragePermissions : Permissions.BasePlatformPermission, Interfaces.IStoragePermissions
{
    [SuppressMessage("Interoperability", "CA1416:Availability")]
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions 
        => Build.VERSION.SdkInt >= BuildVersionCodes.R
        ? [
            (Android.Manifest.Permission.ReadMediaImages, true)]
        : [
            (Android.Manifest.Permission.ReadExternalStorage, true),
            (Android.Manifest.Permission.WriteExternalStorage, true)
            ];
}
