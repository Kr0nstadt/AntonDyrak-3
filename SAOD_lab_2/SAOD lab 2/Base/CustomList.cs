using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_lab_2
{
    public class CustomList<T> where T : IComparable<T>
    {
        public CustomList()
        {
            _count = 0;
        }


        public void Add(T value)
        {
            if (_count == 0)
            {
                _list = new Node<T>
                {
                    Value = value,
                    Next = null,
                };
                ++_count;
            }
            else
            {
                Node<T>? head = _list;
                for (int i = 0; i < _count - 1; ++i)
                {
                    head = head.Next;
                }

                head.Next = new Node<T>
                {
                    Value = value,
                    Next = null,
                };
                ++_count;
            }
        }
        public void Sort()
        {
            if (_list == null || _list.Next == null)
            {
                return;
            }

            for (int i = 0; i < _count - 1; ++i)
            {
                Node<T> first = _list;
                Node<T> second = _list.Next;
                int j = 0;
                while (second != null)
                {
                    if (first.Value.CompareTo(second.Value) > 0)
                    {
                        SwapNeighbor(j);
                        (first, second) = (second, first);
                    }

                    ++j;
                    first = first.Next;
                    second = second.Next;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node<T> head = _list;
            for (int i = 0; i < _count; ++i)
            {
                sb.Append(head.Value.ToString());
                sb.Append(" ");
                head = head.Next;
            }

            return sb.ToString();
        }

        private void SwapNeighbor(int index)
        {
            if (_list == null)
            {
                return;
            }

            if (_count < 2)
            {
                return;
            }

            if (index >= _count - 1)
            {
                return;
            }

            if (index == 0)
            {
                Node<T> tmpNode = _list.Next;
                _list.Next = tmpNode.Next;
                tmpNode.Next = _list;
                _list = tmpNode;
            }
            else
            {
                Node<T> tmpNode = _list;
                for (int i = 1; i < index; ++i)
                {
                    tmpNode = tmpNode.Next;
                }

                Node<T> tmpNext = tmpNode.Next;
                tmpNode.Next = tmpNext.Next;
                tmpNext.Next = tmpNode.Next.Next;
                tmpNode.Next.Next = tmpNext;
            }


        }

        private Node<T>? _list;
        private int _count;
    }
}
