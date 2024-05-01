using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public abstract class PropertyBase : Attitude
    {
        public PropertyBase(string a, Variety b) : base(a, b)
        {
            Property();
        }
        protected abstract void Property();
    }
}
