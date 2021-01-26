using AppKit;
using CoreGraphics;

namespace ALA.Xamarin.Mac.ProgrammingParagadims
{
    public interface IXamarinUI
    {
        /// <summary>
        /// Retrieves the underlying Xamarin UI element from the abstraction.
        /// </summary>
        /// <returns>Element</returns>
        NSView GetUIElement();
        
        /// <summary>
        /// Sets the container for the child element.
        /// </summary>
        /// <param name="rect">Container</param>
        void SetContainer(CGRect rect);
    }
}