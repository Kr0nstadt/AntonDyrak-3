using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_lab_2
{
    public class DecreasingIntArray : BaseIntArray
    {
        public DecreasingIntArray() : this(1) {}
        public DecreasingIntArray(uint size) : base(size)
        {
            FillDec();
        }
        private void FillDec()
        {
            for (int i = 0, val = Data.Length; i < Data.Length; ++i)
            {
                Data[i] = val;
                val--;
            }
        }
    }
}
