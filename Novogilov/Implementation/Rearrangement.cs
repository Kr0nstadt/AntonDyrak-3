using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Rearrangement : Variety
    {
        public Rearrangement(Variety g) : base( g.ToString())
        {
            result = GetPermutations(g._varieti);
        }
        public List<char[]> result;
        int GetJ(char[] array)
        {
            int j = array.Length - 2;
            while (j >= 0 && array[j].CompareTo(array[j + 1]) >= 0)
            { --j; }

            return j;
        }


        int GetL(char[] array, int j)
        {
            int l = array.Length - 1;
            while (j < l && array[j].CompareTo(array[l]) > 0)
            {
                --l;
            }

            return l;
        }

        List<char[]> GetPermutations(char[] array) 
        {
            List<char[]> permutations = new List<char[]>();

            char[] tmpArray = new char[array.Length];
            array.CopyTo(tmpArray, 0);
            permutations.Add(tmpArray);

            int fact = Fact(tmpArray.Length);

            for (int i = 0; i < fact - 1; ++i)
            {
                int j = GetJ(array);
                int l = GetL(array, j);

                (array[j], array[l]) = (array[l], array[j]);

                Array.Reverse(array, j + 1, array.Length - (j + 1));

                tmpArray = new char[array.Length];
                array.CopyTo(tmpArray, 0);
                permutations.Add(tmpArray);
            }

            return permutations;
        }


        int Fact(int n)
        {
            int result = 1;
            for (int i = 2; i <= n; ++i)
            {
                result *= i;
            }

            return result;
        }
    }
}
