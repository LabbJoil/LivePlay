
using Android.App;
using Android.Runtime;

[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage, MaxSdkVersion = 32)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadMediaAudio)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadMediaImages)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadMediaVideo)]

namespace LivePlay.Front.MAUI
{
    [Application]
    //[MetaData("com.google.android.geo.API_KEY",
    //        Value = "AIzaSyCcbSVcMi5YyxR99VXy-qyNcZVBkClwJI0")]

    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
