using Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class HashArrayTableRowTwo
    {
        public HashArrayTableRowTwo(int size)
        {
            HashTableSize = size;
            ArrayLenght = 100;
            HashTwoIntArray hash = new HashTwoIntArray(random, size, 1);
            CollizSumFirst = hash.Cal;
            HashTwoIntArray hash2 = new HashTwoIntArray(random,size, 2);
            CollizSumSecond = hash2.Cal;
        }

        public int HashTableSize { get; init; }
        public int ArrayLenght { get; init; }
        public int CollizSumFirst { get; init; }
        public int CollizSumSecond { get; init; }

        private static RandomIntArray random = new RandomIntArray(100);

        private readonly BaseHashIntArray _randomIntArray;
        private readonly BaseHashIntArray _increasingIntArray;
        private readonly BaseHashIntArray? _decreasingIntArray;
    }
}
