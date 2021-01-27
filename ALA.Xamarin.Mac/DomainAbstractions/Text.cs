using ALA.ProgrammingParagadims;
using ALA.Xamarin.Mac.ProgrammingParagadims;
using AppKit;
using CoreGraphics;

namespace ALA.Xamarin.Mac.DomainAbstractions
{
    /// <summary>
    /// A text label on the UI. The content can be set through the Content property
    /// or passed in through the IDataFlow<string>.
    /// 
    /// Ports:
    /// 1. IXamarinUI ui: Returns the Objective-C UI element.
    /// 2. IDataFlow<string> content: Sets the content of the text.
    /// </summary>
    public class Text : IXamarinUI, IDataFlow<string> // ui, content
    {
        // properties
        public string InstanceName = "Default";
        public string Content { set => textField.Value = value; }
        public NSColor BackgroundColor { set => textField.BackgroundColor = value; }
        public NSColor TextColor { set => textField.TextColor = value; }

        // ports

        // private fields
        private NSView container;
        private NSTextView textField;

        public Text(string text = "")
        {
            textField = new NSTextView
            {
                BackgroundColor = NSColor.Clear,
                Editable = false,
                Selectable = false,
                AutoresizingMask = NSViewResizingMask.WidthSizable | NSViewResizingMask.MinYMargin,
                Value = text
            };
        }

        // IXamarinUI implementation
        NSView IXamarinUI.GetUIElement()
        {
            return textField;
        }

        void IXamarinUI.SetContainer(double x, double y, double width, double height)
        {
            textField.Frame = new CGRect(x, y, width, height);
        }

        // IDataFlow<string> implementation
        string IDataFlow<string>.Data { set => Content = value; }
    }
}