using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hash;
using Tmds.DBus.Protocol;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class HashTableInfo
    {
        public HashTableInfo()
        {
            RandomIntArray randomMini = new RandomIntArray(100);
            _HashViewModel = new HashTableViewModel(randomMini, 11);

            _tableHashArray = new HashArrayTableRow[]
            {
                new HashArrayTableRow(11),
                new HashArrayTableRow(13),
                new HashArrayTableRow(17),
                new HashArrayTableRow(19),
                new HashArrayTableRow(23),
                new HashArrayTableRow(29),
                new HashArrayTableRow(31),
                new HashArrayTableRow(37),
                new HashArrayTableRow(41),
                new HashArrayTableRow(43),
                new HashArrayTableRow(47),
                new HashArrayTableRow(53),
                new HashArrayTableRow(59),
                new HashArrayTableRow(61),
                new HashArrayTableRow(67),
                new HashArrayTableRow(71),
                new HashArrayTableRow(73),
                new HashArrayTableRow(79),
                new HashArrayTableRow(83),
                new HashArrayTableRow(89),
                new HashArrayTableRow(97),
            };
        }
        public string HashViewModel => _HashViewModel.ToString();
        public HashArrayTableRow [] HashTable => _tableHashArray;

        private HashTableViewModel _HashViewModel;
        private HashArrayTableRow[] _tableHashArray;
    }
}
