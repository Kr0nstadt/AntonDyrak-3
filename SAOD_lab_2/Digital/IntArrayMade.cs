using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital
{
    public class IntArrayMade
    {
        public IntArrayMade(int n)
        {
            array = new int[n];
        }
        public int[] array;

        public int[] IncIntArray => Inc();
        public int[] DecIntArray => Dec();
        public int[] RandIntArray => Ran();
        public override string ToString()
        {
            string res = "";
            for(int i = 0; i < array.Length; i++)
            {
                res += array[i].ToString() + " ";
            }
            return res;
        }
        private int[] Inc()
        {
            int val = 1000000000;
            int[] arr = new int[array.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = val;
                val++;
            }
            return arr;
        }
        private int[] Dec()
        {
            int val = 1999999999;
            int[] arr = new int[array.Length];
            for(int i = 0;i < arr.Length; i++)
            {
                arr[i] = val;
                val--;
            }
            return arr;
        }
        private int[] Ran()
        {
            int[] arr = new int[array.Length];
            Random rnd = new Random();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1000,9999);
            }
            return arr;
        }
    }
}
