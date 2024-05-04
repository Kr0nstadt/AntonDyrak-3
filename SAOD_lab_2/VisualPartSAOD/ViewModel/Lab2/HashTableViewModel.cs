using Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class HashTableViewModel
    {
        public HashTableViewModel( BaseIntArray array, int m)
        {
            _array = array;
            _m = m;
        }
        public override string ToString()
        {
            BaseHashIntArray hash = new BaseHashIntArray(_array, _m);
            return $"Изначальный массив : {_array.ToString()}\n" +
                $"Количество элементов массива : {_array.Length}\n" +
                $"Количество очередей : {_m}\n" +
                $"Очереди : \n{hash.ToString()}\n\n" +
                $"Количество коллизий : {hash.Cal}";
        }


        private int _m;
        private BaseIntArray _array;
    }
}
