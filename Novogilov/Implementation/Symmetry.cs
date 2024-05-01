using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Symmetry : PropertyBase
    {
        public Symmetry(string a, Variety b) : base(a, b) { }
        protected override void Property ()
        {
            bool res = true;
            for(int i = 0;i < Attitube.GetLength(0); i++)
            {
                for(int j = 0; j <  Attitube.GetLength(1); j++)
                {
                    if (Attitube[i,j] != Attitube[j, i])
                    {
                        res = false;
                    }
                }
            }
            Symmetryres = res;
        }
        public bool Symmetryres;
    }
}
