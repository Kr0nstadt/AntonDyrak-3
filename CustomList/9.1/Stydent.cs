using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._1
{
    internal class Stydent : IComparable<Stydent>
    {
        public string Surname;
        public int First;
        public int Second;
        public int Third;
        public int Fourth;
        public Stydent(string surname, int first, int second, int third, int fourth)
        {
            Surname = surname;
            First = first;
            Second = second;
            Third = third;
            Fourth = fourth;
        }
        public override string ToString()
        {
            string txt = $"{Surname} {First} {Second} {Third} {Fourth}\n";
            return txt ;
        }
        public int CompareTo(Stydent A)
        {
            if (this.Surname.CompareTo(A.Surname) > 0)
                return 1;
            if (this.Surname.CompareTo(A.Surname) < 0)
                return -1;
            else
                return 0;
        }
    }
}
