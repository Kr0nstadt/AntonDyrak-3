using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
     class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }
    }
}
