using ALA.ProgrammingParagadims;
using ALA.Xamarin.Mac.ProgrammingParagadims;
using AppKit;

namespace ALA.Xamarin.Mac.DomainAbstractions
{
    /// <summary>
    /// An item in a window’s toolbar.
    /// 
    /// Ports:
    /// 1. INSObject<NSToolbarItem> item: The toolbar item.
    /// 2. IDataFlow<bool> enabled: Whether the toolbar item should be enabled.
    /// 3. IEvent clicked: Fired when the toolbar item is clicked.
    /// </summary>
    public class ToolbarItem : INSObject<NSToolbarItem>, IDataFlow<bool> // item, enabled
    {
        // properties
        public string InstanceName = "Default";
        public string Title { set => toolbarItem.Title = value; }
        public string Label { set => toolbarItem.Label = value; }
        public bool Enabled { set => toolbarItem.Enabled = value; }

        // ports
        private IEvent clicked;

        // private fields
        private NSToolbarItem toolbarItem;

        /// <summary>
        /// An item in a window’s toolbar.
        /// </summary>
        /// <param name="identifier">An identifier to pass to the toolbar item. Must be unique.</param>
        public ToolbarItem(string identifier)
        {
            toolbarItem = new NSToolbarItem(identifier)
            {
                Enabled = true
            };

            toolbarItem.Activated += (sender, args) =>
            {
                clicked?.Execute();
            };
        }

        // INSObject<NSToolbarItem> implementation
        NSToolbarItem INSObject<NSToolbarItem>.GetNSObject()
        {
            return toolbarItem;
        }

        // IDataFlow<bool> implementation
        bool IDataFlow<bool>.Data { set => Enabled = value; }
    }
}