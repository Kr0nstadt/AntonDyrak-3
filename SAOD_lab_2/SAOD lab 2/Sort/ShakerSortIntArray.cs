using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{

    public class ShakerSortIntArray : BaseSortedIntArray
    {
        public ShakerSortIntArray() : base() { }
        public ShakerSortIntArray(BaseIntArray array) : base(array) { }

        public override int TM => (Data.Length * Data.Length - Data.Length) / 2;

        public override int TC => 3 * (Data.Length * Data.Length - Data.Length) / 4;

        protected override void Sort()
        {
            int l = 0;
            int r = Data.Length - 1;
            int k = Data.Length - 1;

            while (l < r)
            {
                for (int j = r; j > l; j--)
                {
                    ++C;
                    if (Data[j] < Data[j - 1])
                    {
                        int tmp = Data[j];
                        Data[j] = Data[j - 1];
                        Data[j - 1] = tmp;

                        k = j;

                        M += 3;
                    }
                }

                l = k;

                for (int j = l; j < r; j++)
                {
                    ++C;
                    if (Data[j] > Data[j + 1])
                    {
                        int tmp = Data[j];
                        Data[j] = Data[j + 1];
                        Data[j + 1] = tmp;

                        k = j;

                        M += 3;
                    }
                }

                r = k;
            }
        }
    }
}
