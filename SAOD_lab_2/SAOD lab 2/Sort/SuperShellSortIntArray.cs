using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{

    public class SuperShellSortIntArray : BaseSortedIntArray
    {
        public SuperShellSortIntArray() : base() { }
        public SuperShellSortIntArray(BaseIntArray array) : base(array) { }

        public override int TM => (Data.Length * Data.Length - Data.Length) / 2;

        public override int TC => 3 * (Data.Length * Data.Length - Data.Length) / 4;

        protected override void Sort()
        {
            int n = Data.Length;
            int gap = 1;
            int steps = 0;

            while (gap <= n / 3)
            {
                gap = gap * 2 + 1;
            }
            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = Data[i];
                    int j = i;
                    C++;
                    while (j >= gap && Data[j - gap] > temp)
                    {
                        Data[j] = Data[j - gap];
                        j -= gap;
                        M += 3;
                        steps++;
                    }
                    Data[j] = temp;
                }
                Gep += gap;
                Step++;
                gap = (gap - 14) / 3;
            }
        }
    }
}