using Foundation;

namespace ALA.Xamarin.Mac.ProgrammingParagadims
{
    public interface INSObject<T> where T : NSObject
    {
        /// <summary>
        /// Returns an NSObject, the root class of most Objective-C classes.
        /// </summary>
        T GetNSObject();
    }
}