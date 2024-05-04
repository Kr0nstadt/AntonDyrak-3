using Hash;
using SAOD_lab_2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class HashBinaryViewModel
    {
        public HashBinaryViewModel( int key)
        {
            _key = key;
        }
        public override string ToString()
        {
            Hash.IncreasingIntArray arrayHash = new Hash.IncreasingIntArray(100);
            SAOD_lab_2.IncreasingIntArray arrayBin = new SAOD_lab_2.IncreasingIntArray(100);

            BaseHashIntArray hash = new BaseHashIntArray(arrayHash, 7,_key);

            ArrayBinarySearchFirstIntArray binarySearchFirst = new ArrayBinarySearchFirstIntArray(arrayBin,_key);

            return $"Массив для поиска : {arrayHash.ToString()}\n" +
                $"Ключ для поиска : {_key}\n\n" +
                $"Результат хеширования :\n{_key%7} : {ListToString(hash.SearchRes)}\n{hash.SearchResIndex}\n" +
                $"Результат бинарного поиска : {binarySearchFirst.SearchArrayRes}\n\n" +
                $"Количество сравнений хеширования : {hash.C}\n" +
                $"Количество сравнений бинарного поиска : {binarySearchFirst.C}";
        }
        private string ListToString(List<int> list)
        {
            string t = " ";
            foreach (int i in list)
            {
                t += i + " ";
            }
            return t;
        }

        private int _key;
    }
}
