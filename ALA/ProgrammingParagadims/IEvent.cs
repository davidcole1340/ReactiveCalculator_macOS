namespace ALA.ProgrammingParagadims
{
    /// <summary>
    /// Fired when an IEvent_B is fired, signalling any listeners to execute their respective events.
    /// </summary>
    public delegate void EventHappenedDelegate();

    /// <summary>
    /// Events or observer pattern (publish/subscibe without data.
    /// Can be asynchronous or synchronous
    /// No data, can be bidirectional.
    /// Analogous to Reactive Extensions without the duality with Iteration - the flow only uses hot observables, and never completes.
    /// </summary>
    public interface IEvent
    {
        void Execute();
    }

    /// <summary>
    /// A reversed IEvent. The IEvent pushes event to the destination whereas the IEventB pulls data from source.
    /// However, the destination will be notified when event happens at source.
    /// </summary>
    public interface IEvent_B
    {
        event EventHappenedDelegate EventHappened;
    }
}