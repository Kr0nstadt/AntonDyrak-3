using System.Collections;

namespace DynamicDataStructure;

public class MyListEnumerator<T> : IEnumerator<T> where T : IComparable<T>
{
    public MyListEnumerator(MyNode<T>? head)
    {
        _head = head;
    }

    public bool MoveNext()
    {
        if (_current == null)
        {
            _current = _head;
        }
        else
        {
            _current = _current.Next;
        }

        return _current is not null;
    }

    public void Reset()
    {
        _current = _head;
    }

    public T Current
    {
        get
        {
            if (_current is not null && _current.Value is not null)
            {
                return _current.Value;
            }

            throw new InvalidOperationException();
        }
    } 

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    private MyNode<T>? _head;
    private MyNode<T>? _current;
}