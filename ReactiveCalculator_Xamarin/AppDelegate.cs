using System;
using AppKit;
using Foundation;

namespace ReactiveCalculator_Xamarin
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        MainWindowController windowController;

        public AppDelegate()
        {
            Console.WriteLine($"Hello world {Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Width}");
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            windowController = new MainWindowController();
            windowController.Window.MakeKeyAndOrderFront(this);
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
