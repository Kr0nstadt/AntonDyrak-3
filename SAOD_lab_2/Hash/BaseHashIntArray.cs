using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hash
{
    public class BaseHashIntArray : BaseIntArray
    {
        public BaseHashIntArray()
        {
            _cal = 0;
            _hashTableSize = 0;
            _key = 0;
            _searchRes = new List<int>();
            _hashTable = new List<int>[1];
        }
        public BaseHashIntArray(BaseIntArray array, int m) : base((uint)array.Length)
        {
            _hashTableSize = m;
            _cal = 0;
            _key = 0;
            _searchRes = new List<int>();
            array.Data.CopyTo(Data, 0);
            _hashTable = HashTableMaker();
        }
        public BaseHashIntArray(BaseIntArray array, int m, int key) : base((uint)array.Length)
        {
            _hashTableSize = m;
            _cal = 0;
            _key = key;
            _searchRes = new List<int>();
            array.Data.CopyTo(Data, 0);
            _hashTable = HashTableMaker();
            SearchHeshArray();
        }

        public override string ToString()
        {
            string t = "";
            for(int i = 0; i < _hashTableSize; i++)
            {
                t += $"{i} : {ListToString(_hashTable[i])}\n";
            }
            return t;
        }

        public List<int> SearchRes
        {
            get { return _searchRes; }
            protected set
            {
                _searchRes = value;
            }
        }

        public int Key
        {
            get { return _key; }
            protected set
            {
                _key = value;
            }
        }

        public int Cal
        {
            get { return _cal; }
            protected set
            {
                _cal = value;
            }
        }

        public List<int>[] HashTable
        {
            get { return _hashTable; }
            protected set
            {
                _hashTable = value;
            }
        }

        public int HeshTableSize
        {
            get { return (int)_hashTableSize; }
            protected set
            {
                _hashTableSize = value;
            }
        }

        private string ListToString(List<int> list)
        {
            string t = " ";
            foreach(int i in list)
            {
                t += i + " ";
            }
            return t;
        }

        private void SearchHeshArray ()
        {
            _searchRes = _hashTable[IntToHash(_key)];
        }
        private List<int>[] HashTableMaker()
        {
            List<int>[] HashTable = new List<int>[_hashTableSize];
            List<int> Callision = new List<int>();
            for(int i = 0; i < Data.Length; i++)
            {
                if (HashTable[IntToHash(Data[i])] is null)
                {
                    HashTable[IntToHash(Data[i])] = new List<int>();
                    
                }
                HashTable[IntToHash(Data[i])].Add(Data[i]);
                if (!Callision.Contains(IntToHash(Data[i])))
                {
                    Callision.Add(IntToHash(Data[i]));
                }
            }
            Cal = Data.Length - Callision.Count;
            return HashTable;
        }

        private int IntToHash(int val)
        {
            return val % _hashTableSize;
        }

        private List<int> _searchRes;
        private int _key;
        private int _cal;
        private List<int> [] _hashTable;
        private int _hashTableSize;
    }
}
