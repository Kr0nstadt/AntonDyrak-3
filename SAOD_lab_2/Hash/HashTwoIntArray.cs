using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hash
{
    public class HashTwoIntArray : BaseIntArray
    {
        public HashTwoIntArray()
        {
            _cal = 0;
            _hashTableSize = 0;
            _key = 0;
            _SearchResIndex = "";
            _searchRes = 0;
            _hashTable = new int[10];
        }
        public HashTwoIntArray(BaseIntArray array, int m, int mode) : base((uint)array.Length)
        {
            _hashTableSize = m;
            _cal = 0;
            _key = 0;
            _SearchResIndex = "";
            _searchRes = 0;
            array.Data.CopyTo(Data, 0);
            switch (mode)
            {
                case 1:
                    _hashTable = HashTableMakerLineOne(); break;
                case 2:
                    _hashTable = HashTableMakerLineTwo(); break;
            }
            
        }
        public HashTwoIntArray(BaseIntArray array, int m,int mode, int key) : base((uint)array.Length)
        {
            _hashTableSize = m;
            _cal = 0;
            _key = key;
            _searchRes = 0;
            _SearchResIndex = "";
            array.Data.CopyTo(Data, 0);
            switch (mode)
            {
                case 1:
                    _hashTable = HashTableMakerLineOne(); break;
                case 2:
                    _hashTable = HashTableMakerLineTwo(); break;
            }
            SearchHeshArray();
        }

        public override string ToString()
        {
            string t = "";
            for (int i = 0; i < _hashTableSize; i++)
            {
                t += $"{i} : {_hashTable[i]}\n";
            }
            return t;
        }

        public int SearchRes
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

        public int[] HashTable
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

        public string SearchResIndex
        {
            get { return _SearchResIndex; }
            protected set
            {
                _SearchResIndex = value;
            }
        }

        public int C { get; private set; }

        private string ListToString(List<int> list)
        {
            string t = " ";
            foreach (int i in list)
            {
                t += i + " ";
            }
            return t;
        }

        private void SearchHeshArray()
        {
            for(int i = 0; i < _hashTable.Length; i++)
            {
                if (_hashTable[i] == _key) { _searchRes = i; break; }
                else _searchRes = -1;
            }
            
        }
        private int [] HashTableMakerLineOne()
        {
            int[] HashTable = new int[_hashTableSize];
            int h = 0;
            int d = 1;
            for (int i = 0; i < Data.Length; i++)
            {
                h = Data[i] % _hashTableSize;
                if (HashTable[h] == 0)
                {
                    HashTable[h] = Data[i];

                }
                else
                {
                    int tmpH = (h + d) % _hashTableSize;
                    while (tmpH != h && HashTable[tmpH] != 0)
                    {
                        _cal++;
                        tmpH = (tmpH + d) % _hashTableSize;
                    }

                    if(tmpH != h && tmpH < _hashTableSize && HashTable[tmpH] == 0)
                    {
                        HashTable[tmpH] = Data[i];
                    }
                }
            }
            return HashTable;
        }

        private int[] HashTableMakerLineTwo()
        {
            int[] HashTable = new int[_hashTableSize];
            int h = 0;
            int d = 2;
            for (int i = 0; i < Data.Length; i++)
            {
                h = Data[i] % _hashTableSize;
                if (HashTable[h] == 0)
                {
                    HashTable[h] = Data[i];

                }
                else
                {
                    int tmpH = (h + d) % _hashTableSize;

                    while (tmpH != h && HashTable[tmpH] != 0)
                    {
                        _cal++;
                        tmpH = (tmpH + d) % _hashTableSize;
                    }

                    if (tmpH != h && tmpH < _hashTableSize && HashTable[tmpH] == 0)
                    {
                        HashTable[tmpH] = Data[i];
                    }
                }
            }
            return HashTable;
        }

        private string _SearchResIndex;
        private int _searchRes;
        private int _key;
        private int _cal;
        private int[] _hashTable;
        private int _hashTableSize;
    }
}
