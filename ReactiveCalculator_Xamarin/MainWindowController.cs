using System;
using ALA.Libraries;
using ALA.ProgrammingParagadims;
using ALA.Xamarin.Mac.DomainAbstractions;
using ALA.Xamarin.Mac.ProgrammingParagadims;
using AppKit;
using CoreGraphics;
using Foundation;

namespace ReactiveCalculator_Xamarin
{
    public class MainWindowController : NSWindowController 
    {
        public MainWindowController() : base()
        {
            #region Instantiations
            var mainWindow = new MainWindow() { Title = "Reactive Calculator" };
            var text = new Text() { Content = "Hello, world!", Margin = new Thickness(30) };
            var text2 = new Text() { Content = "Xamarin.Mac ALA" };
            var text3 = new Text() { Content = "Xamarin.Mac ALA" };
            var toolbar = new Toolbar("ReactiveToolbar") {};
            var helloItem = new ToolbarItem("helloItem") { Title = "Print", Label = "Hello" };
            #endregion
            
            #region Wiring
            mainWindow
                .WireTo(text, "children")
                .WireTo(text2, "children")
                .WireTo(text3, "children")
                .WireTo(toolbar
                    .WireTo(helloItem, "children"), "toolbar");
            #endregion
            
            Wiring.PostWiringInitialize();

            base.Window = mainWindow.GetWindow();
            ((IEvent)mainWindow).Execute();
        }

        // public MainWindowController() : base()
        // {
        //     // instantiate
        //     CGRect contentRect = new CGRect(0, 0, 1000, 500);
        //     NSView content = new NSView(contentRect);

        //     NSWindow window = new NSWindow(
        //         contentRect,    
        //         NSWindowStyle.Closable | NSWindowStyle.Miniaturizable |
		//         NSWindowStyle.Resizable | NSWindowStyle.Titled,
        //         NSBackingStore.Buffered,
        //         false
        //     )
        //     {
        //         Title = "Reactive Calculator",
        //         ContentView = content
        //     };

        //     var button = new NSButton(new CGRect(10, 10, 100, 35))
        //     {
        //         AutoresizingMask = NSViewResizingMask.MinYMargin
        //     };

        //     var label = new NSTextField(new CGRect(100, 100, 100, 35))
        //     {
        //         BackgroundColor = NSColor.White,
        //         TextColor = NSColor.Black,
        //         Editable = false,
        //         Bezeled = false,
        //         AutoresizingMask = NSViewResizingMask.WidthSizable | NSViewResizingMask.MinYMargin,
        //         StringValue = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Width.ToString() + "," + Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Height.ToString()
        //     };
            
        //     content.AddSubview(button);
        //     content.AddSubview(label);

        //     int i = 0;
        //     button.Activated += (sender, e) =>
        //     {
        //         ++i;
        //         label.StringValue = $"Button pressed {i} time(s)";
        //         Console.WriteLine("button pressed");
        //     };

        //     base.Window = window;
        //     Window.AwakeFromNib();
        // }
    }
}
