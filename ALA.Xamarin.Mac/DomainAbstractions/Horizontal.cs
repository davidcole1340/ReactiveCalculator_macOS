using System.Collections.Generic;
using ALA.Xamarin.Mac.ProgrammingParagadims;
using AppKit;
using CoreGraphics;

namespace ALA.Xamarin.Mac.DomainAbstractions
{
    public class Horizontal : IXamarinUI
    {
        // properties
        public string InstanceName = "Default";
        public Thickness Margin
        {
            set
            {

            }
        }

        // ports
        private List<IXamarinUI> children = new List<IXamarinUI>();

        // private fields
        private NSView view = new NSView();
        private NSStackView stackView;

        public Horizontal()
        {
            stackView = new NSStackView
            {
                Orientation = NSUserInterfaceLayoutOrientation.Horizontal,
                Alignment = NSLayoutAttribute.NoAttribute
            };
        }

        NSView IXamarinUI.GetUIElement()
        {
            foreach (var child in children)
            {
                stackView.AddArrangedSubview(child.GetUIElement());
            }

            return stackView;
        }

        void IXamarinUI.SetContainer(double x, double y, double width, double height)
        {
        }
    }
}