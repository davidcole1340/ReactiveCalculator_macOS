namespace ProgrammingParagadims
{
    public delegate void DataChangedDelegate();

    public interface IDataFlow<T>
    {
        T Data { set; }
    }

    public interface IDataFlow_B<T>
    {
        T Data { get; }
        event DataChangedDelegate DataChanged;
    }
}