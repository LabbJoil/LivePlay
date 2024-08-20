
using Android.Webkit;
using Microsoft.Maui.Handlers;

namespace LivePlay.Front.MAUI.Platforms.VisualElementsMapper;

public class WebViewControlMapper
{
    public async static void Map(IElementHandler handler, IElement view)
    {
        if (handler is IWebViewHandler webHandler && view is IWebView webView)
        {
            webHandler.PlatformView.Settings.SetGeolocationEnabled(true);
            webHandler.PlatformView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
            webHandler.PlatformView.Settings.JavaScriptEnabled = true;
            webHandler.PlatformView.SetWebChromeClient(new CustomWebChromeClient());
            await CustomWebChromeClient.CheckAndRequestLocationPermission().ContinueWith(action =>
            {
                MainThread.BeginInvokeOnMainThread(() => {
                    webView.Reload();
                });
            });
        }
    }

    private class CustomWebChromeClient : WebChromeClient
    {
        public static async Task<bool> CheckAndRequestLocationPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted)
                return true;
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            return status == PermissionStatus.Granted;
        }

        public override async void OnGeolocationPermissionsShowPrompt(string? origin, GeolocationPermissions.ICallback? callback)
        {
            await CheckAndRequestLocationPermission();
            base.OnGeolocationPermissionsShowPrompt(origin, callback);
            callback?.Invoke(origin, true, false);
        }
    }
}
