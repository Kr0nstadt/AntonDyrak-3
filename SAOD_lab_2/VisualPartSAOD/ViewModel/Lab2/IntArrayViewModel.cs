using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAOD_lab_2;

namespace VisualPartSAOD.ViewModel.Lab2
{
    public delegate int Complexity(int n);
    public class IntArrayViewModel
    {
        public IntArrayViewModel(BaseIntArray customIntArray, BaseSortedIntArray sortedArray, Complexity m, Complexity c)
        {
            _customIntArray = customIntArray;
            _sortedArray = sortedArray;
            _m = m;
            _c = c;
        }
        public override string ToString()
        {
            int n = _customIntArray.Length;

            if (_sortedArray is BaseIntArray custom)
            {
                return $"Исходный массив: {_customIntArray}\n\n" +
                       $"Количество серий до сортировки: {_customIntArray.RunNumber()}\n" +
                       $"Контрольная сумма: {_customIntArray.CheckSum()}\n\n" +
                       $"Массив после сортировки: {_sortedArray}\n\n" +
                       $"Количество серий после сортировки: {custom.RunNumber()}\n" +
                       $"Контрольная сумма: {custom.CheckSum()}\n" +
                       $"Теоритические пересылки: {_sortedArray.TM}\n" +
                       $"Фактические пересылки: {_sortedArray.M -1}\n" +
                       $"Теоритические сравнения: {_sortedArray.TC}\n" +
                       $"Фактические сравнения: {_sortedArray.C-1}\n\n";
            }

            return String.Empty;
        }

        private BaseIntArray _customIntArray;
        private BaseSortedIntArray _sortedArray;
        private Complexity _m;
        private Complexity _c;
    }
}
