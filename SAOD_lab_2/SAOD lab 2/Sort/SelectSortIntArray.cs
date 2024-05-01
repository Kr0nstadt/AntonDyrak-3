using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{

    public class SelectSortIntArray : BaseSortedIntArray
    {
        public SelectSortIntArray() : base() { }
        public SelectSortIntArray(BaseIntArray array) : base(array) { }

        public override int TM => (Data.Length * Data.Length - Data.Length) / 2;

        public override int TC => 3 * (Data.Length * Data.Length - Data.Length) / 4;

        protected override void Sort()
        {
            int n = Data.Length;
            C = 0;
            for (int i = 0; i < n; i++)
            {
                int maiVal = i;

                for (int j = i + 1; j < n; j++)
                {
                    C++;
                    if (Data[j] < Data[maiVal])
                    {
                        maiVal = j;

                    }
                }

                if (maiVal != i)
                {
                    int temp = Data[i];
                    Data[i] = Data[maiVal];
                    Data[maiVal] = temp;

                    M += 3;
                }
            }
        }
        public int first => Data[0];
        public int end => Data[Data.Length - 1];
    }
}
