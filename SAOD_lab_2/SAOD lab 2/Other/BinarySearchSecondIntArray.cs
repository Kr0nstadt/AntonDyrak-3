using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{

    public class BinarySearchSecondIntArray : BaseSearchIntArray
    {
        public BinarySearchSecondIntArray() : base() { }
        public BinarySearchSecondIntArray(BaseIntArray array, int x) : base(array, x) { }


        //второй на один индекс
        protected override void Search(int x)
        {
            int L = 0;
            int R = Data.Length - 1;
            while (L < R)
            {
                var m = (L + R) / 2;
                C++;
                if (Data[m] < x)
                {
                    L = m + 1;
                }
                else
                {
                    R = m;
                }
            }
            C++;
            if (Data[R] == x)
            {
                SearchRes = R;
            }

        }
    }
}
