using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAOD_lab_2;

namespace VisualPartSAOD.ViewModel.Lab2
{

    public class PhonebookViewModel3
    {
        public PhonebookViewModel3(Phonebook2[] array)
        {
            phonebook = array;
        }
        public override string ToString()
        {
            string txt = "Массив структур до сортировки :\n\n";
            for (int i = 0; i < phonebook.Length; i++)
            {
                txt += phonebook[i].ToString() + "\n";
            }
            txt += "\n Массив индексов :\n";
            for (int i = 0; i < phonebook.Length; i++)
            {
                txt += i + ", ";
            }
            IndexArray arr = new IndexArray(phonebook);
            int[] index = arr.BildIndexArray2();
            txt += "\n\nМассив отсортирован по районам :\n\n";
            for (int i = 0; i < phonebook.Length; i++)
            {
                txt += phonebook[index[i]].ToString() + "\n";
            }

            txt += "\nМассив индексов :\n";
            foreach (int i in index)
            {
                txt += i + ", ";
            }
            txt += "\nПоиск человека по району :\n";
            
            return txt;
        }

        private Phonebook2[] phonebook;
    }
}