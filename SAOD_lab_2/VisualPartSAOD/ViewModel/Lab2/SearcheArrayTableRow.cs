using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAOD_lab_2;

namespace VisualPartSAOD.ViewModel.Lab2
{
    public class SearchArrayTableRow
    {
        public SearchArrayTableRow()
        {

            RandomCM = 0;

        }
        public SearchArrayTableRow(int size, Func<BaseSortedIntArray, BaseSearchIntArray> creator)
        {
            _n = size;

            RandomIntArray randomIntArray = new RandomIntArray((uint)size);
            SelectSortIntArray array = new SelectSortIntArray(randomIntArray);

            _randomSearchArray = creator(array);

            RandomCM = _randomSearchArray.C;
            
        }

        public int N => _n;
        public int RandomCM { get; init; }
      
        private int _n;
        private readonly BaseSearchIntArray? _randomSearchArray;
       
    }
}
