using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAOD_lab_2
{
    public class Phonebook : IComparable<Phonebook>
    {
        public string name;
        public string surname;
        public string petronymic;
        public long namber;
        public string adres;
        public string area;
        
        public Phonebook(string name, string surname, string petronymic, long namber, string adres,string area)
        {
            this.name = surname ;
            this.surname = name;
            this.petronymic = petronymic;
            this.namber = namber;
            this.adres = adres ;
            this.area = area ;
        }
        
        public int CompareTo(Phonebook? A)
        {
            
            return surname.CompareTo(A.surname);
                
        }
       
        public override string ToString()
        {
            return $" {surname} {name} {petronymic} {namber} {adres} {area}";
        }
        public static int Search(Phonebook[]Data,long x)
        {
            int L = 0;
            int R = Data.Length - 1;
            int res = 0;
            while (L <= R)
            {
                var m = (L + R) / 2;
                
                if (Data[m].namber == x)
                {
                    res = m;
                    break;
                }
                else if (Data[m].namber < x)
                {
                    L = m + 1;
                }
                else
                {
                    R = m - 1;
                }
            }
            return res;
        }
        public static void Sort(Phonebook[] Data)
        {
            int l = 0;
            int r = Data.Length - 1;
            int k = Data.Length - 1;

            while (l < r)
            {
                for (int j = r; j > l; j--)
                {
                    if (Data[j].CompareTo(Data[j - 1]) < 0)
                    {
                        Phonebook tmp = Data[j];
                        Data[j] = Data[j - 1];
                        Data[j - 1] = tmp;

                        k = j;
                    }
                }
                l = k;

                for (int j = l; j < r; j++)
                {
                    
                    if (Data[j].CompareTo(Data[j + 1]) > 0)
                    {
                        Phonebook tmp = Data[j];
                        Data[j] = Data[j + 1];
                        Data[j + 1] = tmp;

                        k = j;    
                    }
                }
                r = k;
            }
        }
    }
}
