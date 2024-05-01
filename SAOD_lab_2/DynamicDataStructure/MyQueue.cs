using System.Collections;

namespace DynamicDataStructure;

public class MyQueue<T> : IEnumerable<T> where T : IComparable<T>
{
    public MyQueue()
    {
        _list = new MyList<T>();
    }

    public T? Peek()
    {
        return _list.Peek();
    }

    public T? Dequeue()
    {
        return _list.Pop();
    }

    public void Enqueue(T item)
    {
        _list.Add(item);
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