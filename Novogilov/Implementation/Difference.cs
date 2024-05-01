using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Difference : MethodBase
    {
        public Difference(Variety v, Variety f) : base(v, f)
        {

        }
        protected override void Method(Variety A, Variety B)
        {
            string txt = "";
            string inter = "";
            for (int i = 0; i < A._varieti.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < B._varieti.Length; j++)
                {
                    
                    if (A._varieti[i] == B._varieti[j])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    txt += A._varieti[i];
                }
            }
            
            DifferenceRes = new Variety(txt);
        }
        public Variety DifferenceRes;
    }
}
