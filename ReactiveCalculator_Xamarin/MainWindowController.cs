using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace ReactiveCalculator_Xamarin
{
    public class MainWindowController : NSWindowController 
    {
        public MainWindowController() : base()
        {
            // instantiate
            CGRect contentRect = new CGRect(0, 0, 1000, 500);
            NSView content = new NSView(contentRect);

            NSWindow window = new NSWindow(
                contentRect,    
                NSWindowStyle.Closable | NSWindowStyle.Miniaturizable |
		        NSWindowStyle.Resizable | NSWindowStyle.Titled,
                NSBackingStore.Buffered,
                false
            )
            {
                Title = "Reactive Calculator",
                ContentView = content
            };

            var button = new NSButton(new CGRect(10, 10, 100, 35))
            {
                AutoresizingMask = NSViewResizingMask.MinYMargin
            };

            var label = new NSTextField(new CGRect(100, 100, 100, 35))
            {
                BackgroundColor = NSColor.White,
                TextColor = NSColor.Black,
                Editable = false,
                Bezeled = false,
                AutoresizingMask = NSViewResizingMask.WidthSizable | NSViewResizingMask.MinYMargin,
                StringValue = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Width.ToString() + "," + Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Height.ToString()
            };
            
            content.AddSubview(button);
            content.AddSubview(label);

            int i = 0;
            button.Activated += (sender, e) =>
            {
                ++i;
                label.StringValue = $"Button pressed {i} time(s)";
                Console.WriteLine("button pressed");
            };

            base.Window = window;
            Window.AwakeFromNib();
        }
    }
}
