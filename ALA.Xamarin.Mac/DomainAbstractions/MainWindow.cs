using AppKit;
using CoreGraphics;
using ALA.ProgrammingParagadims;
using Xamarin.Essentials;
using System.Collections.Generic;
using ALA.Xamarin.Mac.ProgrammingParagadims;
using System;
using Foundation;

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
        public Thickness Margin
        {
            set
            {
                stackView.EdgeInsets = value.ToNSObject();
            }
        }

        // ports
        private INSObject<NSToolbar> toolbar;
        private List<IXamarinUI> children = new List<IXamarinUI>();

        // private fields
        private CGRect frame;
        private NSStackView stackView;
        private NSWindow window;

        public MainWindow()
        {
            frame = new CGRect();
            Width = DeviceDisplay.MainDisplayInfo.Width * 0.65;
            Height = DeviceDisplay.MainDisplayInfo.Height * 0.6;

            stackView = new NSStackView(frame)
            {
                Alignment = NSLayoutAttribute.CenterX,
                Distribution = NSStackViewDistribution.FillEqually,
                Spacing = 5,
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            window = new NSWindow(
                frame,
                NSWindowStyle.Closable | NSWindowStyle.Miniaturizable |
                NSWindowStyle.Resizable | NSWindowStyle.Titled,
                NSBackingStore.Buffered,
                false
            );
            window.ContentView = stackView;
        }

        /// <summary>
        /// Returns the underlying AppKit window.
        /// </summary>
        public NSWindow GetWindow()
        {
            return window;
        }

        // IEvent implementation
        void IEvent.Execute()
        {
            foreach (var child in children)
            {
                stackView.AddArrangedSubview(child.GetUIElement());
            }

            if (toolbar != null) window.Toolbar = toolbar.GetNSObject();

            // CalculateChildrenSize();
            window.AwakeFromNib();
        }
    }
}