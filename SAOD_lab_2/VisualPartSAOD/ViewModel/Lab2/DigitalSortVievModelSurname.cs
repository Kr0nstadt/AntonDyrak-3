using Digital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class DigitSortViewModelSurname
    {
        public DigitSortViewModelSurname(string[] array)
        {
            _array = array;
        }
        public override string ToString()
        {
            string[] arr = Digital_Sort.StringArrayMake(
                Digital_Sort.DigitalSort(Digital_Sort.QueueMake(_array), (Digital_Sort.QueueMake(_array).Peek().Length)));
            arr.Reverse();
            return $"Изначальный список фамилий :\n{StringArray(_array)}\n" +
                $"\nПосле сортировки :\n{StringArray(Digital_Sort.StringArrayMake(
                Digital_Sort.DigitalSort(Digital_Sort.QueueMake(_array), (Digital_Sort.QueueMake(_array).Peek().Length))))} " +
                $"\nВ обратном порядке : {StringArray(arr)}";
        }
        private string[] _array;
        private string StringArray(string[] array)
        {
            string res = "";
            for(int i = 0; i < array.Length; i++)
            {
                res += array[i] + "\n";
            }
            return res;
        }
    }
}
