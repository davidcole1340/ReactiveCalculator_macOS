using ALA.ProgrammingParagadims;
using ALA.Xamarin.Mac.ProgrammingParagadims;
using AppKit;
using CoreGraphics;

namespace ALA.Xamarin.Mac.DomainAbstractions
{
    public class Text : IXamarinUI, IDataFlow<string>
    {
        // properties
        public string InstanceName = "Default";
        public string Content { set => textField.StringValue = value; }
        public NSColor BackgroundColor { set => textField.BackgroundColor = value; }
        public NSColor TextColor { set => textField.TextColor = value; } 

        // ports

        // private fields
        private NSTextField textField;

        public Text()
        {
            textField = new NSTextField
            {
                Editable = false,
                Bezeled = false,
                AutoresizingMask = NSViewResizingMask.WidthSizable | NSViewResizingMask.MaxYMargin,

                BackgroundColor = NSColor.Black,
                TextColor = NSColor.White,
                StringValue = ""
            };
        }

        // IXamarinUI implementation
        NSView IXamarinUI.GetUIElement()
        {
            return textField;
        }

        void IXamarinUI.SetContainer(CGRect rect)
        {
            textField.Frame = rect;
        }

        // IDataFlow<string> implementation
        string IDataFlow<string>.Data { set => Content = value; }
    }
}