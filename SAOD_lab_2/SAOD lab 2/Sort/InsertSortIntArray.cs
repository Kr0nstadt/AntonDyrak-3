using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_lab_2
{
    public class InsertSortIntArray : BaseSortedIntArray
    {
        public InsertSortIntArray() : base() { }

        public InsertSortIntArray(BaseIntArray array) : base(array) { }

        public override int TM => (Data.Length * Data.Length - Data.Length) / 2 + Data.Length * 2 - 2;

        public override int TC => (Data.Length * Data.Length - Data.Length) / 2;

        protected override void Sort()
        {
            int n = Data.Length;
            M++;
            C++;
            for (int i = 1; i < n; i++)
            {
                
                int key = Data[i];int j = i - 1;
                M++;
                while(j >= 0 && Data[j] > key)
                {
                    Data[j+1] = Data[j];
                    j--;
                    M++;
                    C++;
                }
                M++;
                Data[j + 1] = key;
                
            }
        }
    }
}
