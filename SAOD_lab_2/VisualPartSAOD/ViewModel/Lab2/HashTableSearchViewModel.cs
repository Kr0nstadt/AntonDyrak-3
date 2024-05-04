using Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class HashTableSearchViewModel
    {
        public HashTableSearchViewModel(BaseIntArray array, int m, int key)
        {
            _key = key;
            _array = array;
            _m = m;
        }
        public override string ToString()
        {
            BaseHashIntArray hash = new BaseHashIntArray(_array, _m, _key);
            return $"Изначальный массив : {_array.ToString()}\n" +
                $"Количество элементов массива : {_array.Length}\n" +
                $"Количество очередей : {_m}\n" +
                $"Очереди : \n{hash.ToString()}\n" +
                $"Количество коллизий : {hash.Cal}\n\n" +
                $"Ключ для поиска : {hash.Key}\n" +
                $"Очередь : \n{_key%_m} : {ListToString(hash.SearchRes)}\n" +
                $"Позиции найденных элементов : {hash.SearchResIndex}";
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
        private int _m;
        private BaseIntArray _array;
    }
}
