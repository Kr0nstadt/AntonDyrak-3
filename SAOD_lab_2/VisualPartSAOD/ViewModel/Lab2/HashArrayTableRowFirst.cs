using Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class HashArrayTableRowFirst
    {
        public HashArrayTableRowFirst(int mode,int index)
        {
            HashTwoIntArray hashTwoIntArray = new HashTwoIntArray(random,size,mode);
            HashTableIndex = index;
            ArrayValue = hashTwoIntArray.HashTable[index];
        }

        public int HashTableIndex { get; init; }
        public int ArrayValue { get; init; }


        public static RandomIntArray random = new RandomIntArray(10);
        private int size = 24;
        private readonly BaseHashIntArray _randomIntArray;
        private readonly BaseHashIntArray _increasingIntArray;
        private readonly BaseHashIntArray? _decreasingIntArray;
    }
}
