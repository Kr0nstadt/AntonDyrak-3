using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{
    public class BaseIntArray
    {
        public BaseIntArray() : this(1) {}

        public BaseIntArray(uint size)
        {
            _data = new int[size];
        }

        public virtual int RunNumber()
        {
            int res = 1;
            for (int i = 0; i < _data.Length - 1; i++)
            {
                if (_data[i] > _data[i + 1])
                {
                    res++;
                }
            }
            return res;
        }

        public virtual int CheckSum()
        {
            int sum = 0;
            for (int i = 0; i < _data.Length; ++i)
            {
                sum += _data[i];
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (int item in Data)
            {
                sb.Append(item);
                sb.Append(' ');
            }

            return sb.ToString();
        }

        public int[] Data => _data;
        public int Length => _data.Length;

        private int[] _data;
        
    }
}
