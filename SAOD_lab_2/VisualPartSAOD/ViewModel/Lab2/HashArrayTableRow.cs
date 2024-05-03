using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hash;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class HashArrayTableRow
    {
        public HashArrayTableRow(int size)
        {
            HashTableSize = size;
            RandomIntArray random = new RandomIntArray(n);
            ArrayLenght = (int)n;
            BaseHashIntArray hash = new BaseHashIntArray(random,size);
            CollizSum = hash.Cal;
        }

        public int HashTableSize { get; init; }
        public int ArrayLenght { get; init; }
        public int CollizSum {  get; init; }

        private uint n = 500;
        private readonly BaseHashIntArray _randomIntArray;
        private readonly BaseHashIntArray _increasingIntArray;
        private readonly BaseHashIntArray? _decreasingIntArray;
    }
}
