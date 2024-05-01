using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Transitivity : PropertyBase
    {
        public Transitivity(string attitude, Variety b) : base(attitude, b) { }
        protected override void Property()
        {
            bool res = true;
            int[,] Copy = Attitube;
            int[,] Multiply = MultiplyMatrices(Attitube, Copy);
            t = Multiply;
            int SumMultiply = 0, SumRef = 0;
            for(int i = 0; i < Copy.GetLength(0); i++)
            {
                for(int j = 0; j < Copy.GetLength(1); j++)
                {
                    if (Multiply[i, j] > Copy[i, j])
                    {
                        res= false;
                        break;
                    }
                }
            }
            
            TransivityRes = res;
        }
        public static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int n = matrix1.GetLength(0);
            int[,] result = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                        if (result[i, j] > 1)
                        {
                            result[i, j] = 1;
                        }
                    }
                }
            }

            return result;
        }
        public int[,] t;
        public bool TransivityRes;
    }
}
