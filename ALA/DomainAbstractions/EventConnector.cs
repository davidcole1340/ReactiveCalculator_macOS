using System.Collections.Generic;
using ALA.ProgrammingParagadims;

namespace ALA.DomainAbstractions
{
    /// <summary>
    /// It fans out IEvent by creating a list and assign the event to the element in the list.
    /// Moreover, any IEvent and IEventB can be transferred bidirectionally.
    /// ----------------------------------------------------------------------------------------------
    /// Ports:
    /// 1. IEvent input: incoming event which wants to be fanned out
    /// 2. IEventB output_B: the 'b port' which listens for when event happens again within this EventConnector or acts as an IEvent_B adapter
    /// 3. List<IEvent> fanoutList: output port that fans out to every abstraction connected in order of wiring
    /// 4. IEvent last: output port that will execute after the fanoutList and IEvent_B data changed event. This enables chaining of events and explicit execution of last to execute the event.
    /// </summary>
    public class EventConnector : IEvent, IEvent_B // input, output_B
    {
        // properties
        public string InstanceName = "Default";

        // ports
        private List<IEvent> fanoutList = new List<IEvent>();
        private IEvent last;

        // IEvent implementation
        void IEvent.Execute()
        {
            foreach (var df in fanoutList) df.Execute();
            EventHappened?.Invoke();
            last?.Execute();
        }

        // IEvent_B implementation
        public event EventHappenedDelegate EventHappened;
    }
}