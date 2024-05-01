using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{
    public class QuickSortSecond : BaseSortedIntArray
    {
        public QuickSortSecond() : base() { }
        public QuickSortSecond(BaseIntArray array) : base(array) { }

        public override int TM => (int)(Data.Length-1) * ((int)Math.Log2(Data.Length-1))+6;

        public override int TC => (int)(Data.Length-1) * ((int)Math.Log2(Data.Length-1))+6;

        protected override void Sort()
        {
            
            QuickSort(0, Data.Length - 1);
        }
        public int leftIndex;
        public int rightIndex;
        private void QuickSort(int low, int high)
        {
            
            if (low < high)
            {
                int pivotIndex = Partition( low, high);
                Step++;
                QuickSort(low, pivotIndex);
                QuickSort( pivotIndex + 1, high);

            }

        }
        private int Partition( int low, int high)
        {
            int pivot = Data[low];
            int i = low - 1;
            int j = high + 1;


            while (true)
            {
                do
                {
                    i++;
                    C++;
                } while (Data[i] < pivot);

                do
                {
                    j--;
                    C++;
                    
                } while (Data[j] > pivot);

                if (i >= j)
                    return j;
                
                int temp = Data[i];
                Data[i] = Data[j];
                Data[j] = temp;
                M += 3;
            }
        }
    }
}
