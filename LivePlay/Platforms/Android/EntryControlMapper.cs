
using Android.Graphics.Drawables;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;

namespace LivePlay.Platforms;

public static class EntryControlMapper
{
    public static void Map(IElementHandler handler, IElement view) {
        if (view is Entry)
        {
            var casted = (EntryHandler)handler;
            var gd = new GradientDrawable();
            gd.SetStroke(0, Android.Graphics.Color.Transparent);
            casted.PlatformView?.SetBackground(gd);
        }
    }
}
