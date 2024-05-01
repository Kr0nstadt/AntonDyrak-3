using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Intersection : MethodBase
    {
        public Intersection(Variety v, Variety f) : base(v, f)
        {

        }
        protected override void Method(Variety A, Variety B)
        {
            string txt = "";
            for(int i = 0; i < A._varieti.Length; i++)
            {
                for(int j = 0; j < B._varieti.Length; j++)
                {
                    if (A._varieti[i] == B._varieti[j])
                    {
                        txt += A._varieti[i];
                    }
                }
            }
            IntersectionRes = new Variety(txt);
        }
        public Variety IntersectionRes;
    }
}
