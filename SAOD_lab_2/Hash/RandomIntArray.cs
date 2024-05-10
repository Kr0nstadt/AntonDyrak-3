using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    public class RandomIntArray : BaseIntArray
    {
        public RandomIntArray() : this(1) { }
        public RandomIntArray(uint size) : base(size)
        {
            FillRand();
        }
        private void FillRand()
        {
            Random rnd = new Random();
            for (int i = 0; i < Data.Length; ++i)
            {
                Data[i] = rnd.Next(1,100);
            }
        }

    }
}
