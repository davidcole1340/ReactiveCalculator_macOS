namespace ProgrammingParagadims
{
    public delegate void EventHappenedDelegate();

    public interface IEvent
    {
        void Execute();
    }

    public interface IEvent_B
    {
        event EventHappenedDelegate EventHappened;
    }
}