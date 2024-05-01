using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Implementation;

namespace LAB_2
{
    internal class AttitubeInfo
    {
        public Attitude _attitude;

        public Symmetry _symmetry;
        public AntySymmetry _antySymmetry;
        public Reflexivity _reflexivity;
        public Transitivity _transensitivity;
        public List<char> _chars;
        public AttitubeInfo(string s, string set)
        {
            _attitude = new Attitude(s, new Variety(set));
            _reflexivity = new Reflexivity(s, new Variety(set));
            _symmetry = new Symmetry(s, new Variety(set));
            _antySymmetry = new AntySymmetry(s, new Variety(set));
            _transensitivity = new Transitivity(s, new Variety(set));
            _chars = _attitude.Chars;
        }
        private string ListString (List<char> C)
        {
            string txt = "";
            foreach (var item in C)
            {
                txt += item+" ";
            }
            return txt;
        }
        public string Info => Text();
        public string Item => ListString(_chars);
        public string Text()
        {
            return $"Матрица \n{Item}\n{_attitude.ToString()}\n"+
                $"Рефлексивность {_reflexivity.ReflexivityRes}\n" +
                $"Симметричность {_symmetry.Symmetryres} \n" +
                $"Антисимметричность {_antySymmetry.AntySymmetryRes} \n" +
                $"Транзитивность {_transensitivity.TransivityRes}";
        }
    }
}
