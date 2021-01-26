using System.Collections.Generic;
using ProgrammingParagadims;

namespace DomainAbstractions
{
    class DataFlowConnector<T> : IDataFlow<T>, IDataFlow_B<T>
    {
        // properties
        public string InstanceName = "Default";

        // ports
        private List<IDataFlow<T>> fanoutList = new List<IDataFlow<T>>();

        // private fields
        private T data = default;

        // IDataFlow implementation
        T IDataFlow<T>.Data
        {
            set
            {
                data = value;
                foreach (var df in fanoutList) df.Data = value;
                DataChanged.Invoke();
            }
        }

        // IDataFlow_B implementation
        T IDataFlow_B<T>.Data => data;
        public event DataChangedDelegate DataChanged;
    }
}