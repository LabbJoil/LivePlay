using Android.App;
using Android.Runtime;

namespace LivePlay.Front.MAUI
{
    [Application]
    [MetaData("com.google.android.geo.API_KEY",
            Value = "AIzaSyCcbSVcMi5YyxR99VXy-qyNcZVBkClwJI0")]

    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
