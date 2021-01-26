using System.Collections.Generic;
using ALA.Xamarin.Mac.ProgrammingParagadims;
using AppKit;
using Foundation;

namespace ALA.Xamarin.Mac.DomainAbstractions
{
    /// <summary>
    /// An object that manages the space immediately below a window's title bar and above your app's custom content.
    /// 
    /// Ports:
    /// 1. INSObject<NSToolbar> toolbar: The Objective-C toolbar item.
    /// 2. List<INSObject<NSToolbarItem>> children: Toolbar items to add to the toolbar.
    /// </summary>
    public class Toolbar : INSObject<NSToolbar> // toolbar
    {
        // properties
        public string InstanceName = "Default";

        // ports
        private List<INSObject<NSToolbarItem>> children = new List<INSObject<NSToolbarItem>>();
        
        // private fields
        private NSToolbar toolbar = new NSToolbar();

        /// <summary>
        /// An object that manages the space immediately below a window's title bar and above your app's custom content.
        /// </summary>
        /// <param name="identifier">An identifier to pass to the toolbar. Must be unique.</param>
        public Toolbar(string identifier)
        {
            toolbar = new NSToolbar(identifier);
        }

        // INSObject<NSToolbar> implementation
        NSToolbar INSObject<NSToolbar>.GetNSObject()
        {
            for (int i = 0; i < children.Count; i++)
            {
                toolbar.InsertItem((children[i].GetNSObject()).Identifier, i);
            }

            return toolbar;
        }
    }
}