using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Implementation;

namespace Novogilov
{
    public class VarietyInfo
    {
        public Variety _varietyA;
        public Variety _varietyB;

        public Union _Union;
        public Difference _Difference;
        public Intersection _Intersection;
        public Subset _Subset;

        public VarietyInfo(string a, string b)
        {
            _varietyA = new Variety(a.Replace(" ",""));
            _varietyB = new Variety(b.Replace(" ",""));   
        }

        public string UnionInfo => UInf();
        public string IntersectionInfo => IInf();
        public string SubsetInfo => SInf();
        public string DifferenceInfo => DInf();

        public string UInf()
        {
            Union U = new Union(_varietyA, _varietyB);
            return $"Множество А : {_varietyA.ToString()}\n" +
                $"Множество B : {_varietyB.ToString()}\n\n" +
                $"Объединение :\n {U.UnionRes.ToString()}";
        }
        public string IInf()
        {
            Intersection U = new Intersection(_varietyA, _varietyB);
            return $"Множество А : {_varietyA.ToString()}\n" +
                $"Множество B : {_varietyB.ToString()}\n\n" +
                $"Пересечение :\n {U.IntersectionRes.ToString()}";
        }
        public string SInf()
        {
            Subset U = new Subset(_varietyA, _varietyB);
            return $"Множество А : {_varietyA.ToString()}\n" +
                $"Множество B : {_varietyB.ToString()}\n\n" +
                $"Подмножество :\n {U.SubsetRes.ToString()}";
        }
        public string DInf()
        {
            Difference U = new Difference(_varietyA, _varietyB);
            return $"Множество А : {_varietyA.ToString()}\n" +
                $"Множество B : {_varietyB.ToString()}\n\n" +
                $"Разность :\n {U.DifferenceRes.ToString()}";
        }

    }
}
