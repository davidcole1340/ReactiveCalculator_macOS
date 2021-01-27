using System.Collections.Generic;
using ALA.ProgrammingParagadims;

namespace ALA.DomainAbstractions
{
    /// <summary>
    /// Acts as a pipe to fan out incoming by creating a list and assign the data to the element in the list.
    /// Moreover, any IDataFlow and IDataFlow_B (listens for when data changed within this DataFlowConnector or acts as an IDataFlow<B> adapter) can be transferred bidirectionally.
    /// ----------------------------------------------------------------------------------------------
    /// Ports:
    /// 1. IDataFlow<T> input: incoming data which wants to be fanned out
    /// 2. IDataFlow_B<T> output_B: the 'b port' which listens for when data changed within this DataFlowConnector or acts as an IDataFlow<B> adapter. Note: this happens after the fanoutList
    /// 3. List<IDataFlow<T>> fanoutList: output port that fans out to every abstraction connected in order of wiring
    /// 4. IDataFlow<T> last: output port that will output after the fanoutList and IDataFlow_B data changed event. This enables chaining of data flow and explicit execution of last to push the data flow.
    /// </summary>
    /// <typeparam name="T">Generic data type</typeparam>
    public class DataFlowConnector<T> : IDataFlow<T>, IDataFlow_B<T> // input, output_B
    {
        // properties
        public string InstanceName = "Default";

        // ports
        private List<IDataFlow<T>> fanoutList = new List<IDataFlow<T>>();
        private IDataFlow<T> last;

        // private fields
        private T data = default;

        // IDataFlow implementation
        T IDataFlow<T>.Data
        {
            set
            {
                data = value;
                foreach (var df in fanoutList) df.Data = data;
                DataChanged?.Invoke();
                if (last != null) last.Data = data;
            }
        }

        // IDataFlow_B implementation
        T IDataFlow_B<T>.Data => data;
        public event DataChangedDelegate DataChanged;
    }
}