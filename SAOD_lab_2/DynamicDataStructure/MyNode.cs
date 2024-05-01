namespace DynamicDataStructure;

public class MyNode<T> : ICloneable
{
    public T? Value { get; set; }
    public MyNode<T>? Next { get; set; }
    public object Clone()
    {
        return new MyNode<T>
        {
            Value = Value,
            Next = Next,
        };
    }
}