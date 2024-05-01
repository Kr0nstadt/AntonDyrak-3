using System.Collections;
using System.Text;

namespace DynamicDataStructure;

public class MyList<T> : IEnumerable<T> where T : IComparable<T>
{
    public MyList()
    {
        _count = 0;
    }

    public MyList(IEnumerable<T> enumerable)
    {
        foreach (T item in enumerable)
        {
            Add(item);
        }
    }

    public MyList(MyNode<T> head)
    {
        _head = head;
        MyNode<T>? tmp = _head;
        
        while (tmp != null)
        {
            tmp = tmp.Next;
            ++_count;
        }
    }

    public MyList(MyNode<T> head, int count)
    {
        _head = head;
        _count = count;
    }

    public void Add(T item)
    {
        if (_head == null)
        {
            _head = new MyNode<T>()
            {
                Value = item, Next = null,
            };

            _tail = _head;
        }
        else
        {
            _tail.Next = new MyNode<T>()
            {
                Value = item, Next = null
            };

            _tail = _tail.Next;
        }

        ++_count;
    }

    public int GetCheckSum()
    {
        int sum = 0;

        if (_head != null)
        {
            MyNode<T>? tmp = _head;

            while (tmp != null)
            {
                sum += tmp.Value?.GetHashCode() ?? 0;
                tmp = tmp.Next;
            }
        }

        return sum;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyListEnumerator<T>(_head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int GetIncreaseSeries()
    {
        int series = 0;
        if (_head != null)
        {
            series = 1;
            MyNode<T>? cur = _head;
            MyNode<T>? next = _head.Next;

            while (next != null)
            {
                if (cur.Value?.CompareTo(next.Value) > 0)
                {
                    ++series;
                }
                cur = next;
                next = next.Next;
            }
        }

        return series;
    }

    public T? Peek()
    {
        if (_head is not null)
        {
            return _head.Value;
        }

        return default;
    }

    public T? Pop()
    {
        if (_head is not null)
        {
            MyNode<T> tmp = _head;

            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _head = _head.Next;
            }

            --_count;

            return tmp.Value;
        }

        throw new InvalidOperationException();
    }
    
    public void Push(T item)
    {
        if (_head == null)
        {
            Add(item);
        }
        else
        {
            MyNode<T> tmp = new MyNode<T>()
            {
                Value = item,
                Next = _head,
            };

            _head = tmp;

            ++_count;
        }
    }

    public void RemoveAll()
    {
        if (_head != null)
        {
            while (_head != null)
            {
                MyNode<T>? tmp = _head.Next;
                _head.Next = null;
                _head = tmp;
            }

            _head = null;
        }

        _count = 0;
    }

    public static void MergeSort(ref MyList<T> list)
    {
        if (list.Count <= 1)
        {
            return;
        }

        Queue<MyList<T>> partitionQueue = new Queue<MyList<T>>();
        Queue<MyList<T>> mergingQueue = new Queue<MyList<T>>();

        partitionQueue.Enqueue(list);

        //Разбиение
        while (partitionQueue.Count > 0)
        {
            MyList<T> tmpList = partitionQueue.Dequeue();
            Tuple<MyList<T>, MyList<T>> tuple = Partitioning(tmpList);
            tmpList.RemoveAll();

            if (tuple.Item1.Count > 1)
            {
                partitionQueue.Enqueue(tuple.Item1);
            }
            else
            {
                mergingQueue.Enqueue(tuple.Item1);
            }

            if (tuple.Item2.Count > 1)
            {
                partitionQueue.Enqueue(tuple.Item2);
            }
            else
            {
                mergingQueue.Enqueue(tuple.Item2);
            }
        }

        //Слияние
        while (mergingQueue.Count > 1)
        {
            MyList<T> leftList = mergingQueue.Dequeue();
            MyList<T> rightList = mergingQueue.Dequeue();
            mergingQueue.Enqueue(Merging(leftList, rightList));
            leftList.RemoveAll();
            rightList.RemoveAll();
        }

        list = mergingQueue.Dequeue();
    }

    public static Tuple<MyList<T>, MyList<T>> Partitioning(MyList<T> list)
    {
        int lm = 0;
        int rm = 0;
        if (list.Count <= 1)
        {
            throw new InvalidOperationException();
        }

        MyNode<T> tmp = list._head.Next.Next;
        MyNode<T> leftHead = list._head.Clone() as MyNode<T>;
        MyNode<T> leftPointer = leftHead;
        int leftCount = 1;
        MyNode<T> rightHead = list._head.Next.Clone() as MyNode<T>;
        MyNode<T> rightPointer = rightHead;
        int rightCount = 1;

        while (leftCount + rightCount < list.Count)
        {
            if (leftCount == rightCount)
            {
                leftPointer.Next = tmp.Clone() as MyNode<T>;
                leftPointer = leftPointer.Next;
                tmp = tmp.Next;
                ++leftCount;
                ++lm;
            }
            else
            {
                rightPointer.Next = tmp.Clone() as MyNode<T>;
                rightPointer = rightPointer.Next;
                tmp = tmp.Next;
                ++rightCount;
                ++rm;
            }
        }

        leftPointer.Next = null;
        rightPointer.Next = null;
        
        MyList<T> leftList = new MyList<T>(leftHead, leftCount);
        leftList.M = lm;

        MyList<T> rightList = new MyList<T>(rightHead, rightCount);
        rightList.M = rm;

        return new Tuple<MyList<T>, MyList<T>>(leftList, rightList);

    }

    public static MyList<T> Merging(MyList<T> leftList, MyList<T> rightList)
    {
        int c = 0;
        int m = 0;

        if (leftList.Count == 0 && rightList.Count == 0)
        {
            return new MyList<T>();
        }

        if (leftList.Count == 0)
        {
            MyNode<T> head = rightList._head.Clone() as MyNode<T>;
            MyNode<T> pointer = head;
            MyNode<T> tmp = rightList._head.Next;

            while (tmp != null)
            {
                pointer.Next = tmp.Clone() as MyNode<T>;
                tmp = tmp.Next;
                pointer = pointer.Next;
                ++m;
            }

            pointer.Next = null;
            MyList<T> t = new MyList<T>(head, rightList.Count);
            t.C = leftList.C + rightList.C + c;
            t.M = leftList.M + rightList.M + m;

            return t;
        }

        if (rightList.Count == 0)
        {
            MyNode<T> head = leftList._head.Clone() as MyNode<T>;
            MyNode<T> pointer = head;
            MyNode<T> tmp = leftList._head.Next;

            while (tmp != null)
            {
                pointer.Next = tmp.Clone() as MyNode<T>;
                tmp = tmp.Next;
                pointer = pointer.Next;
                ++m;
            }

            pointer.Next = null;

            MyList<T> t = new MyList<T>(head, leftList.Count);
            t.C = leftList.C + rightList.C + c;
            t.M = leftList.M + rightList.M + m;

            return t;
        }

        //Если оба списка не пустые
        MyNode<T> leftHead = leftList._head;
        MyNode<T> rightHead = rightList._head;
        MyNode<T> newListHead;

        if (leftHead.Value.CompareTo(rightHead.Value) <= 0)
        {
            newListHead = leftHead.Clone() as MyNode<T>;
            leftHead = leftHead.Next;
        }
        else
        {
            newListHead = rightHead.Clone() as MyNode<T>;
            rightHead = rightHead.Next;
        }

        ++c;
        ++m;

        MyNode<T> newListPointer = newListHead;

        while (leftHead != null && rightHead != null)
        {
            if (leftHead.Value.CompareTo(rightHead.Value) <= 0)
            {
                newListPointer.Next = leftHead.Clone() as MyNode<T>;
                leftHead = leftHead.Next;
            }
            else
            {
                newListPointer.Next = rightHead.Clone() as MyNode<T>;
                rightHead = rightHead.Next;
            }

            ++c;
            ++m;

            newListPointer = newListPointer.Next;
        }

        //Докидываем хвосты
        if (leftHead != null)
        {
            while (leftHead != null)
            {
                newListPointer.Next = leftHead.Clone() as MyNode<T>;
                newListPointer = newListPointer.Next;
                leftHead = leftHead.Next;
                ++m;
            }
            
        }

        if (rightHead != null)
        {
            while (rightHead != null)
            {
                newListPointer.Next = rightHead.Clone() as MyNode<T>;
                newListPointer = newListPointer.Next;
                rightHead = rightHead.Next;
                ++m;
            }
        }

        MyList<T> lst = new MyList<T>(newListHead, rightList.Count + leftList.Count);
        lst.C = leftList.C + rightList.C + c;
        lst.M = leftList.M + rightList.M + m;
        return lst;
    }

    /*
    public static void Sort(MyList<T> list)
    {
        if (list._head != null)
        {
            list._head = Partition(list._head, list.Count);
        }
    }

    private static MyNode<T> Partition(MyNode<T> head, int size)
    {
        if (size <= 1)
        {
            head.Next = null;
            return head;
        }

        MyNode<T> tmp = head;
        int leftSize = size / 2;

        while (leftSize > 0)
        {
            tmp = tmp.Next;
            --leftSize;
        }

        leftSize = size / 2;

        int rightSize = size % 2 == 0 ? size / 2 : size / 2 + 1;

        MyNode<T> left = Partition(head, size / 2);
        MyNode<T> right = Partition(tmp, rightSize);

        return Merge(left, leftSize, right, rightSize);
    }

    private static MyNode<T> Merge(MyNode<T>? left, int leftSize, MyNode<T>? right, int rightSize)
    {
        if (left is null)
        {
            return right;
        }

        if (right is null)
        {
            return left;
        }

        MyNode<T>? tmp = null;
        MyNode<T>? tmpHead = null;

        if (left.Value.CompareTo(right.Value) <= 0)
        {
            tmp = left;
            tmpHead = tmp;
            left = left.Next;
            --leftSize;
        }
        else
        {
            tmp = right;
            tmpHead = tmp;
            right = right.Next;
            --rightSize;
        }

        while (leftSize > 0 && rightSize > 0)
        {
            if (left.Value.CompareTo(right.Value) <= 0)
            {
                tmp.Next = left;
                left = left.Next;
                --leftSize;
            }
            else
            {
                tmp.Next = right;
                right = right.Next;
                --rightSize;
            }

            tmp = tmp.Next;
        }

        if (leftSize == 0 && rightSize > 0)
        {
            tmp.Next = right;
        }
        else if (rightSize == 0 && leftSize > 0)
        {
            tmp.Next = left;
        }

        return tmpHead;
    }
    */
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        
        MyNode<T>? tmp = _head;

        while (tmp != null)
        {
            sb.Append($"{tmp.Value} ");
            tmp = tmp.Next;
        }

        return sb.ToString();
    }

    public string ToStringForward()
    {
        if (_head == null)
        {
            return String.Empty;
        }

        return ToStringRecursiveForward(_head);
    }

    public string ToStringBackward()
    {
        if (_head == null)
        {
            return String.Empty;
        }

        return ToStringRecursiveBackward(_head);
    }

    private string ToStringRecursiveForward(MyNode<T> node)
    {
        if (node.Next == null)
        {
            return node.Value?.ToString() ?? String.Empty;
        }

        return (node.Value?.ToString() ?? String.Empty) + " " + ToStringRecursiveForward(node.Next);
    }

    private string ToStringRecursiveBackward(MyNode<T> node)
    {
        if (node.Next == null)
        {
            return node.Value?.ToString() ?? String.Empty;
        }

        return ToStringRecursiveBackward(node.Next) + " " + (node.Value?.ToString() ?? String.Empty);
    }

    public int Count => _count;

    public int C { get; private set; } = 1;
    public int M { get; private set; } = 1;

    private int _count;
    private MyNode<T>? _head;
    private MyNode<T>? _tail;
}