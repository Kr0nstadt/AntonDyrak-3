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
            Stopwatch TimeHash = new Stopwatch();
            Stopwatch TimeBin = new Stopwatch();

            TimeHash.Start();
            BaseHashIntArray hash = new BaseHashIntArray(arrayHash, 7,_key);
            TimeHash.Stop();

            TimeBin.Start();
            ArrayBinarySearchFirstIntArray binarySearchFirst = new ArrayBinarySearchFirstIntArray(arrayBin,_key);
            TimeBin.Stop();

            return $"Массив для поиска : {arrayHash.ToString()}\n" +
                $"Ключ для поиска : {_key}\n\n" +
                $"Результат хеширования :\n{_key%7} : {ListToString(hash.SearchRes)}\n{hash.SearchResIndex}\n" +
                $"Результат бинарного поиска : {binarySearchFirst.SearchArrayRes}\n\n" +
                $"Время работы хеширования : {TimeHash.ElapsedMilliseconds.ToString()}\n" +
                $"Время работы бинарного поиска : {TimeBin.ElapsedMilliseconds.ToString()}";
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
