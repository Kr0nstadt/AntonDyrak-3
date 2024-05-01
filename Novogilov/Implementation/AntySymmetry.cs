using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class AntySymmetry : PropertyBase
    {
        public AntySymmetry(string a, Variety b) : base(a,b) { }
        protected override void Property()
        {
            bool res = true;
            int[,] trancponed = TransposeArray(Attitube);
            F = trancponed;
            int[,] ArrayRes = new int [Attitube.GetLength(0), Attitube.GetLength(1)];
            for(int i = 0; i < Attitube.GetLength(0); i++)
            {
                for(int j = 0; j <  Attitube.GetLength(1); j++)
                {
                    ArrayRes[i, j] = trancponed[i,j] * Attitube[i,j];
                }
            }
            for(int i = 0; i <  ArrayRes.GetLength(0); i++)
            {
                for(int j = 0;j < ArrayRes.GetLength(1); j++)
                {
                    if(i == j) { continue; }
                    else
                    {
                        if (ArrayRes[i,j] != 0)
                        {
                            res = false;
                        }
                    }
                }
            }
            S = ArrayRes;
            AntySymmetryRes = res;
        }
        static int[,] TransposeArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int[,] transposed = new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposed[j, i] = array[i, j];
                }
            }

            return transposed;
        }
        public bool AntySymmetryRes;
        public int[,] F;
        public int[,] S;
    }
}
