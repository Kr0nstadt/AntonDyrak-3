using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_lab_2
{
    public class IncreasingIntArray : BaseIntArray
    {
        public IncreasingIntArray() : this(1) {}
        public IncreasingIntArray(uint size) : base(size)
        {
            FillInc();
        }
        private void FillInc()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = i;
            }
        }
    }
}
