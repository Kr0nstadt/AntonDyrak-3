using System.Collections;

namespace DynamicDataStructure;

public class MyStack<T> : IEnumerable<T> where T : IComparable<T>
{
    public MyStack()
    {
        _list = new MyList<T>();
    }

    public T? Peek()
    {
        return _list.Peek();
    }

    public T? Pop()
    {
        return _list.Pop();
    }

    public void Push(T item)
    {
        _list.Push(item);
    }
    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        return _list.ToString();
    }

    private readonly MyList<T> _list;
}