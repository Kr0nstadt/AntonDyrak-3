using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public abstract class MethodBase : Variety
    {
        public MethodBase(Variety r, Variety f) : base(r.ToString())
        {
            Method(r,f);
        }
        protected abstract void Method(Variety h, Variety k);
    }
}
