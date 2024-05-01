using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class DigitalSortTableRow
    {
        public DigitalSortTableRow()
        {
            TheorMCInt = 0;
            RandomCMInt = 0;
            IncreaseCMInt = 0;
            DecreaseCMInt = 0;
        }

        public DigitalSortTableRow(int size)
        {
            _n = size;
            IntArrayMade array = new IntArrayMade(size);
            int[] Inc = array.IncIntArray;
            int[] Dec = array.DecIntArray;
            int[] Rand = array.RandIntArray;
            TheorMCInt = 4 * (size + 256);
            Queue<byte[]> res = Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Inc), Digital_Sort.QueueMake(Inc).Peek().Length);
            IncreaseCMInt = Digital_Sort.M;
            Queue<byte[]> res2 = Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Dec), Digital_Sort.QueueMake(Dec).Peek().Length);
            DecreaseCMInt = Digital_Sort.M;
            Queue<byte[]> res3 = Digital_Sort.DigitalSort(Digital_Sort.QueueMake(Rand), Digital_Sort.QueueMake(Rand).Peek().Length);
            RandomCMInt = Digital_Sort.M;
        }
        public int N => _n;
        public int TheorMCInt { get; init; }
        public int RandomCMInt { get; init; }
        public int IncreaseCMInt { get; init; }
        public int DecreaseCMInt { get; init; }
        private int _n;
    }
}
