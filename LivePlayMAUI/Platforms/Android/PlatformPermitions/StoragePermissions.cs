
using Android.OS;
using System.Diagnostics.CodeAnalysis;

namespace LivePlayMAUI.Platforms.PlatformPermitions;

public class StoragePermissions : Permissions.BasePlatformPermission, Interfaces.IStoragePermissions
{
    //[SuppressMessage("Interoperability", "CA1416:Availability")]
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions 
    { 
        get
        {
#if ANDROID33_0_OR_GREATER
            return [
                (Android.Manifest.Permission.ReadExternalStorage, true),
                (Android.Manifest.Permission.WriteExternalStorage, true)
            ];
#else
            return [
                (Android.Manifest.Permission.ReadMediaImages, true)
            ];
#endif
        }
    }
        //=> Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu
        //? [
        //    (Android.Manifest.Permission.ReadMediaImages, true)
        //    ]
        //: [
        //    (Android.Manifest.Permission.ReadExternalStorage, true),
        //    (Android.Manifest.Permission.WriteExternalStorage, true)
        //    ];
}
