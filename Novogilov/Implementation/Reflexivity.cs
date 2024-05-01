using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Reflexivity : PropertyBase
    {
        public Reflexivity(string a, Variety b) : base(a,b) { }
        protected override void Property()
        {
            bool res = true;
            for(int i = 0; i < Attitube.GetLength(0);  i++)
            {
                if (Attitube[i,i] == 0)
                {
                    res = false;
                }
            }
            ReflexivityRes = res;
        }
        public bool ReflexivityRes;
    }
}
