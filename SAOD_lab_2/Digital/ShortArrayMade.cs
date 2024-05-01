using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Digital
{
    public class ShortArrayMade
    {
        public short[] array;
        public ShortArrayMade(int n)
        {
            array = new short[n];
        }
        public short[] IncShortArray => Inc();
        public short[] DecShortArray => Dec();
        public short[] RandShortArray => Ran();
        private short[] Inc()
        {
            short val = 10000;
            short[] arr = new short[array.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (short)val;
                val++;
            }
            return arr;
        }
        private short[] Dec()
        {
            short val = 19999;
            short[] arr = new short[array.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (short)val;
                val--;
            }
            return arr;
        }
        private short[] Ran()
        {
            short[] arr = new short[array.Length];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (short)rnd.Next(10000,19999);
            }
            return arr;
        }
    }
}
