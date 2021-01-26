using AppKit;
using CoreGraphics;
using ALA.ProgrammingParagadims;
using Xamarin.Essentials;
using System.Collections.Generic;
using ALA.Xamarin.Mac.ProgrammingParagadims;
using System;

namespace ALA.Xamarin.Mac.DomainAbstractions
{
    public class MainWindow : IEvent
    {
        // properties
        public string InstanceName = "Default";
        public string Title { set => window.Title = value; }
        public double Width
        {
            set
            {
                frame.Width = (nfloat)value;
                frame.X = (nfloat)(DeviceDisplay.MainDisplayInfo.Width - value) / 2;
            }
        }
        public double Height 
        {
            set
            {
                frame.Height = (nfloat)value;
                frame.Y = (nfloat)(DeviceDisplay.MainDisplayInfo.Height - value) / 2;
            }
        }

        // ports
        private INSObject<NSToolbar> toolbar;
        private List<IXamarinUI> children = new List<IXamarinUI>();

        // private fields
        private CGRect frame;
        private NSView content;
        private NSWindow window;

        public MainWindow()
        {
            frame = new CGRect();
            Width = DeviceDisplay.MainDisplayInfo.Width * 0.65;
            Height = DeviceDisplay.MainDisplayInfo.Height * 0.6;

            content = new NSView(frame);
            window = new NSWindow(
                frame,
                NSWindowStyle.Closable | NSWindowStyle.Miniaturizable |
                NSWindowStyle.Resizable | NSWindowStyle.Titled,
                NSBackingStore.Buffered,
                false
            );
            window.ContentView = content;

            window.DidResize += (sender, args) =>
            {
                CalculateChildrenSize();
            };
        }

        /// <summary>
        /// Returns the underlying AppKit window.
        /// </summary>
        public NSWindow GetWindow()
        {
            return window;
        }

        private void CalculateChildrenSize()
        {
            double x = 0;
            double width = content.Frame.Width / children.Count;

            foreach (var child in children)
            {
                // delegate sizes to children
                // any children with grandchildren should also delegate their size
                child.SetContainer(x, 0, width, content.Frame.Height);
                x += width;
            }
        }

        // IEvent implementation
        void IEvent.Execute()
        {
            foreach (var child in children)
            {
                content.AddSubview(child.GetUIElement());
            }

            if (toolbar != null) window.Toolbar = toolbar.GetNSObject() as NSToolbar;

            CalculateChildrenSize();
            window.AwakeFromNib();
        }
    }
}