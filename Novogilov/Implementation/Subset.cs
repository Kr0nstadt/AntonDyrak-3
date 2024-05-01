using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Subset : MethodBase
    {
        public Subset(Variety v, Variety f) : base(v, f)
        {

        }
        protected override void Method(Variety A, Variety B)
        {
            bool res = true;
            if(A._varieti.Length == 0 && B._varieti.Length == 0) { res = true; }
            else if(B._varieti.Length == 0 && A._varieti.Length != 0) { res =  false; }
            else if(A._varieti.Length == 0 && B._varieti.Length != 0) { res = true; }
            else if(A._varieti.Length > B._varieti.Length) { res = false; }
            else
            {
                for(int i = 0; i < A._varieti.Length; i++)
                {
                    int index = Array.IndexOf(B._varieti, A._varieti[i]);
                    if(index == -1) { res = false; break; }
                    res = true;
                }
            }
            
            SubsetRes = res;
        }
        public bool SubsetRes;
    }
}
