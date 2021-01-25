using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace ReactiveCalculator_Xamarin
{
    public class MainWindowController : NSWindowController 
    {
        public MainWindowController()
        {
            // instantiate
            CGRect contentRect = new CGRect(0, 0, 1000, 500);
            NSWindow window = new NSWindow(
                contentRect,
                NSWindowStyle.Closable | NSWindowStyle.Miniaturizable |
		        NSWindowStyle.Resizable | NSWindowStyle.Titled,
                NSBackingStore.Buffered,
                false
            )
            {
                Title = "Reactive Calculator",
                ContentView = new NSView(contentRect)
            };

            Window = window;
            Window.AwakeFromNib();

            // post wiring initialize
        }
    }
}
