using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{
    public class QuickSortFirst : BaseSortedIntArray
    {
        public QuickSortFirst() : base() { }
        public QuickSortFirst(BaseIntArray array) : base(array) { }

        public override int TM => (int)Data.Length*((int)Math.Log2(Data.Length))+6;

        public override int TC => (int)Data.Length * ((int)Math.Log2(Data.Length)) + 6;

        protected override void Sort()
        {

            QuickSort(0, Data.Length - 1);
            //Step++;
        }
        
        private void QuickSort(int L,int R)
        {
            var i = L;
            var j = R;
            var pivot = Data[L];
            while (i <= j)
            {
                C++;
                while (Data[i] < pivot)
                {
                    C++;
                    i++;
                }
                C++;
                while (Data[j] > pivot)
                {
                    C++;
                    j--;
                }
                if (i <= j)
                {
                    int temp = Data[i];
                    Data[i] = Data[j];
                    Data[j] = temp;
                    M += 3;
                    i++;
                    j--;
                }
            }

            if (L < j)
            {
                Step++;
                QuickSort(L, j);
            }
            if (i < R)
            {
                Step++;
                QuickSort(i, R);
            }
        }
    }
}
