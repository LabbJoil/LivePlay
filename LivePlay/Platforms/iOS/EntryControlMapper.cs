
using CoreAnimation;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace LivePlay.Platforms;

class EntryControlMapper
{
    public static void Map(IElementHandler handler, IElement view) {
        if (view is Entry)
        {
            var casted = (EntryHandler)handler;
           // var viewData = entry;
            var backgroundLayer = new CALayer
            {
                BackgroundColor = UIColor.Clear.CGColor
            };
            casted.PlatformView.Layer.InsertSublayer(backgroundLayer, 0);
        }
    }
}
