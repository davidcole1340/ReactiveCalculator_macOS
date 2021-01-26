using System.Collections.Generic;
using ProgrammingParagadims;

namespace DomainAbstractions
{
    public class EventConnector : IEvent, IEvent_B
    {
        // properties
        public string InstanceName = "Default";

        // ports
        private List<IEvent> fanoutList = new List<IEvent>();

        // IEvent implementation
        void IEvent.Execute()
        {
            foreach (var df in fanoutList) df.Execute();
            EventHappened?.Invoke();
        }

        // IEvent_B implementation
        public event EventHappenedDelegate EventHappened;
    }
}