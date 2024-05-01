using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_lab_2
{
    public class Phonebook2 : IComparable<Phonebook2>
    {
        public string name;
        public string surname;
        public string petronymic;
        public long namber;
        public string adres;
        public string area;

        public Phonebook2(string name, string surname, string petronymic, long namber, string adres, string area)
        {
            this.name = surname;
            this.surname = name;
            this.petronymic = petronymic;
            this.namber = namber;
            this.adres = adres;
            this.area = area;
        }

       
        public int CompareTo(Phonebook2? A)
        {
            
            return area.CompareTo(A.area);

        }
        public static int Search(Phonebook2[] Data,string x)
        {
            int low = 0;
            int high = Data.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int compareResult = string.Compare(Data[mid].area, x);
                if (compareResult == 0)
                {
                    return mid;
                }
                else if (compareResult < 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return 0;
            
        }
        public override string ToString()
        {
            return $" {surname} {name} {petronymic} {namber} {adres} {area}";
        }
        public static void Sort2(Phonebook2[] Data)
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
                        Phonebook2 tmp = Data[j];
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
                        Phonebook2 tmp = Data[j];
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