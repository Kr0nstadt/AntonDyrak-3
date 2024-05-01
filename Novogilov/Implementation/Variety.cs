using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class Variety 
    {
        public char[] _varieti;
        
        public Variety(string txt)
        {
            _varieti = txt.Where(c => Char.IsLetter(c)).
                Select(c => Char.ToLower(c)).
                Distinct().ToArray();
            Array.Sort(this._varieti);
        }
        
        public override string ToString()
        {
            string txt = "{";
            foreach (char c in _varieti)
            {
                txt += $"{c} ";
            }
            txt += "}";
            return txt;
        }
    }
}
