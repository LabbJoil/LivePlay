
using CoreAnimation;
using Microsoft.Maui.Handlers;
using UIKit;

namespace LivePlay.Front.MAUI.Platforms.VisualElementsMapper;

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
