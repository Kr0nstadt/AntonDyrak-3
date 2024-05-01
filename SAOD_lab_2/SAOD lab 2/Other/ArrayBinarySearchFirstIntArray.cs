using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{

    public class ArrayBinarySearchFirstIntArray : BaseSearchIntArray
    {
        public ArrayBinarySearchFirstIntArray() : base() { }
        public ArrayBinarySearchFirstIntArray(BaseIntArray array, int x) : base(array, x) { }


        //первая на много индексов
        protected override void Search(int x)
        {
            int L = 0;
            string res = "";
            int R = Data.Length - 1;
            while (L <= R)
            {
                var m = (L + R) / 2;
                C+=2;
                if (x == Data[m])
                {
                    
                    while( x == Data[m] && x < Data.Length)
                    {
                        res += m.ToString() + " ";
                        Data[m] = -1;
                        Array.Sort(Data);
                        Search(x);
                        
                    }
                    SearchArrayRes = res;
                    return;
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

        private int FirstSearch(int x)
        {
            int L = 0;
            int R = Data.Length - 1;
            int res = 0;
            while (L <= R)
            {
                var m = (L + R) / 2;
                C += 2;
                if (x == Data[m])
                {
                    res = m;
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
            return res;
        }
    }
}
