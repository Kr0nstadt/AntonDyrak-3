using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_lab_2
{
    public class BubbleSortIntArray : BaseSortedIntArray
    {
        public BubbleSortIntArray() : base() { }
        public BubbleSortIntArray(BaseIntArray array) : base(array) { }

        public override int TM => (Data.Length * Data.Length - Data.Length) / 2;

        public override int TC => 3 * (Data.Length * Data.Length - Data.Length) / 4;

        protected override void Sort()
        {
            for (int i = 0; i < Data.Length - 1; i++)
            {
                for (int j = 0; j < Data.Length - i - 1; j++)
                {
                    C++;
                    if (Data[j] > Data[j + 1])
                    {
                        int temp = Data[j];
                        Data[j] = Data[j + 1];
                        Data[j + 1] = temp;
                        M += 3;
                    }
                }
            }
        }
    }
}
