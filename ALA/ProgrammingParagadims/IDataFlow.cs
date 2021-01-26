namespace ALA.ProgrammingParagadims
{
    /// <summary>
    /// Fired when the data changes in an IDataFlow_B, signalling the receiver
    /// to check the new data.
    /// </summary>
    public delegate void DataChangedDelegate();

    /// <summary>
    /// A dataflow with a single scaler value with a primitive data type and a "OnChanged' event.
    /// OR think of it as an event with data, the receivers are able to read the data at any time.
    /// Or think of it as an implementation of a global variable and an observer pattern, with access to the variable and observer pattern restricted to the line connections on the diagram.
    /// Unidirectional - every line is one direction implying sender(s) and receiver(s).
    /// You can have multiple senders and receivers.
    /// The data is stored in the wire so receivers that don't act on the event can read its value at any time. Receivers cant change the data or send the event. 
    /// </summary>
    /// <typeparam name="T">Generic data type</typeparam>
    public interface IDataFlow<T>
    {
        T Data { set; }
    }

    /// <summary>
    /// A reversed IDataFlow, the IDataFlow pushes data to the destination whereas IDataFlow_B pulls data from source.
    /// However, the DataChanged event will notify the destination when change happens.
    /// </summary>
    /// <typeparam name="T">Generic data type</typeparam>
    public interface IDataFlow_B<T>
    {
        T Data { get; }
        event DataChangedDelegate DataChanged;
    }
}