using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{

    public class BinarySearchFirstIntArray : BaseSearchIntArray
    {
        public BinarySearchFirstIntArray() : base() { }
        public BinarySearchFirstIntArray(BaseIntArray array, int x) : base(array, x) { }


        //первая на один индекс
        protected override void Search(int x)
        {
            int L = 0;
            int R = Data.Length - 1;
            while( L <= R)
            {
                var m = (L + R) / 2;
                C+=2;
                if( x == Data[m])
                {
                    SearchRes = m;
                    break;
                }
                else if (Data[m] < x)
                {
                    L = m + 1;
                    
                }
                else
                {
                    R = m - 1;
                }
            }
             
        }
    }
}
