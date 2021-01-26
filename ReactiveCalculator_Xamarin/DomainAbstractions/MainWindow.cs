using AppKit;
using CoreGraphics;
using ProgrammingParagadims;

namespace DomainAbstractions
{
    public class MainWindow : IEvent
    {
        // properties
        public string InstanceName = "Default";
        public string Title { set => window.Title = value; }

        // ports

        // private fields
        private CGRect frame;
        private NSView content;
        private NSWindow window = new NSWindow();

        public MainWindow(string title)
        {
        }

        void IEvent.Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}