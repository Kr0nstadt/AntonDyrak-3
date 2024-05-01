using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Union : MethodBase
    {
        public Union(Variety v, Variety f) : base(v,f)
        {

        }
        protected override void Method(Variety A,Variety B)
        {
            string txt = "";
            for(int i = 0; i < A._varieti.Length; i++)
            {
                txt += A._varieti[i];
            }
            for(int i = 0;i < B._varieti.Length; i++)
            {
                txt += B._varieti[i];
            }
            
            UnionRes = new Variety(txt);
            
        }
        public Variety UnionRes;
    }
}
