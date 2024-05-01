using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAOD_lab_2;

namespace VisualPartSAOD.ViewModel.Lab2
{
    
    public class ShellIntArrayViewModel
    {
        public ShellIntArrayViewModel(BaseIntArray customIntArray, BaseSortedIntArray sortedArray, Complexity m, Complexity c)
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
                       $"Контрольная сумма до сортировки: {_customIntArray.CheckSum()}\n\n" +
                       $"Массив после сортировки: {_sortedArray}\n\n" +
                       $"Количество серий после сортировки: {custom.RunNumber()}\n" +
                       $"Контрольная сумма после сортировки: {custom.CheckSum()}\n\n" +
                       $"Фактические пересылки: {_sortedArray.M}\n" +
                       $"Фактические сравнения: {_sortedArray.C}\n\n" +
                       $"Количество шагов: {_sortedArray.Step}\n" +
                       $"Шаги:{_sortedArray.Gep}\n\n";
            }

            return String.Empty;
        }

        private BaseIntArray _customIntArray;
        private BaseSortedIntArray _sortedArray;
        private Complexity _m;
        private Complexity _c;
        
    }
}
