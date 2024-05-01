using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAOD_lab_2;

namespace VisualPartSAOD.ViewModel.Lab2
{

    public class BinarySearchViewModel
    {
        public BinarySearchViewModel(BaseSortedIntArray customIntArray, BaseSearchIntArray sortedArray)
        {
            _sortedArray = customIntArray;
            _binarySearch = sortedArray;
           
        }
        public override string ToString()
        {
            int n = _sortedArray.Length;

            if (_sortedArray is BaseIntArray custom)
            {
                return $"Масиив для поиска {_sortedArray.ToString()}\n" +
                    $"Элемент для поиска {_binarySearch.x}\n" +
                    $"Найденный индекс {_binarySearch.SearchRes}\n\n" +
                    $"Фактическая трудоемкость {_binarySearch.C}\n" +
                    $"Теоритическая трудоемкость <= {Math.Log2(n) + 1}\n\n";
            }

            return String.Empty;
        }

        private BaseSortedIntArray _sortedArray;
        private BaseSearchIntArray _binarySearch;
        

    }
}
