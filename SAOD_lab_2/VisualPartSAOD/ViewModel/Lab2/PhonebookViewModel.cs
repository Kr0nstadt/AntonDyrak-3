using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAOD_lab_2;

namespace VisualPartSAOD.ViewModel.Lab2
{

    public class PhonebookViewModel
    {
        public PhonebookViewModel(Phonebook[] array )
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
            for(int i = 0; i < phonebook.Length; i++)
            {
                txt += i + ", ";
            }
            IndexArray arr = new IndexArray(phonebook);
            int[] index = arr.BildIndexArray();
            txt += "\n\nМассив отсортирован по фамилии :\n\n";
            foreach(int ind in index)
            {
                txt += phonebook[ind].ToString() + "\n";
            }
            txt += "\n\n Массив индексов :\n";
            foreach(int i  in index)
            {
                txt += i + ", ";
            }
            
            return txt;
        }

        private Phonebook[] phonebook;
    }
}