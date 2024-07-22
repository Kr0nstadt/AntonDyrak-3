using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hash;
using Tmds.DBus.Protocol;

namespace VisualPartSAOD.ViewModel.Lab2
{
    internal class HashTableInfoTwo
    {
        public HashTableInfoTwo()
        {
            RandomIntArray randomMini = new RandomIntArray(100);
            _SearchViewModel = new HashBinaryViewModel(key);

            _tableHashArrayOne = new HashArrayTableRowFirst[]
            {
                new HashArrayTableRowFirst(1, 0),
                new HashArrayTableRowFirst(1,1),
                new HashArrayTableRowFirst(1,2),
                new HashArrayTableRowFirst(1,3),
                new HashArrayTableRowFirst(1,4),
                new HashArrayTableRowFirst(1,5),
                new HashArrayTableRowFirst(1,6),
                new HashArrayTableRowFirst(1,7),
                new HashArrayTableRowFirst(1,8),
                new HashArrayTableRowFirst(1,9),
                new HashArrayTableRowFirst(1,10),
                new HashArrayTableRowFirst(1,11),
                new HashArrayTableRowFirst(1,12),
                new HashArrayTableRowFirst(1,13),
                new HashArrayTableRowFirst(1,14),
                new HashArrayTableRowFirst(1,15),
                new HashArrayTableRowFirst(1,16),
                new HashArrayTableRowFirst(1,17),
                new HashArrayTableRowFirst(1, 18),
                new HashArrayTableRowFirst(1, 19),
                new HashArrayTableRowFirst(1, 20),
                new HashArrayTableRowFirst(1, 21),
                new HashArrayTableRowFirst(1, 22),
                
            };
            _tableHashArraySecond = new HashArrayTableRowFirst[]
            {
                new HashArrayTableRowFirst(2,0),
                new HashArrayTableRowFirst(2,1),
                new HashArrayTableRowFirst(2,2),
                new HashArrayTableRowFirst(2,3),
                new HashArrayTableRowFirst(2,4),
                new HashArrayTableRowFirst(2,5),
                new HashArrayTableRowFirst(2,6),
                new HashArrayTableRowFirst(2,7),
                new HashArrayTableRowFirst(2,8),
                new HashArrayTableRowFirst(2,9),
                new HashArrayTableRowFirst(2,10),
                new HashArrayTableRowFirst(2,11),
                new HashArrayTableRowFirst(2,12),
                new HashArrayTableRowFirst(2,13),
                new HashArrayTableRowFirst(2,14),
                new HashArrayTableRowFirst(2,15),
                new HashArrayTableRowFirst(2,16),
                new HashArrayTableRowFirst(2,17),
                new HashArrayTableRowFirst(2, 18),
                new HashArrayTableRowFirst(2, 19),
                new HashArrayTableRowFirst(2, 20),
                new HashArrayTableRowFirst(2, 21),
                new HashArrayTableRowFirst(2, 22),
                new HashArrayTableRowFirst(2, 23),
                new HashArrayTableRowFirst(2, 24),
                new HashArrayTableRowFirst(2, 25),
                new HashArrayTableRowFirst(2, 26),
                new HashArrayTableRowFirst(2, 27),
                new HashArrayTableRowFirst(2, 28),
                new HashArrayTableRowFirst(2, 29),
                new HashArrayTableRowFirst(2, 30),
                new HashArrayTableRowFirst(2, 31),
                new HashArrayTableRowFirst(2, 32),
                new HashArrayTableRowFirst(2, 33),
                new HashArrayTableRowFirst(2, 34),
                new HashArrayTableRowFirst(2, 35),

            };
            _tableHashArrayFinal = new HashArrayTableRowTwo[]
            {
                 new HashArrayTableRowTwo(11),
                new HashArrayTableRowTwo(13),
                new HashArrayTableRowTwo(17),
                new HashArrayTableRowTwo(19),
                new HashArrayTableRowTwo(23),
                new HashArrayTableRowTwo(29),
                new HashArrayTableRowTwo(31),
                new HashArrayTableRowTwo(37),
                new HashArrayTableRowTwo(41),
                new HashArrayTableRowTwo(43),
                new HashArrayTableRowTwo(47),
                new HashArrayTableRowTwo(53),
                new HashArrayTableRowTwo(59),
                new HashArrayTableRowTwo(61),
                new HashArrayTableRowTwo(67),
                new HashArrayTableRowTwo(71),
                new HashArrayTableRowTwo(73),
                new HashArrayTableRowTwo(79),
                new HashArrayTableRowTwo(83),
                new HashArrayTableRowTwo(89),
                new HashArrayTableRowTwo(97),
            };
            
            string array = "";
            for(int i = 0;i < HashArrayTableRowFirst.random.Data.Length; i++)
            {
                array += HashArrayTableRowFirst.random.Data[i] + " ";
            }
           txt = $"Массив для создания хеш таблицы : \n" +
                $"{array}\n" +
                $"Длинна массива : 23\n" +
                $"Размер хеш таблицы : 23";
        }
        public static int key = 15;
        public string HashSearchViewModel => _SearchViewModel.ToString();
        public string HashTableInfo => txt;
        public HashArrayTableRowFirst[] HashTableOne => _tableHashArrayOne;
        public HashArrayTableRowFirst[] HashTableSecond => _tableHashArraySecond;
        public HashArrayTableRowTwo[] HashTableFinal => _tableHashArrayFinal;

        private HashTableViewModel _HashViewModel;
        private HashBinaryViewModel _SearchViewModel;
        private HashArrayTableRowFirst[] _tableHashArrayOne;
        private HashArrayTableRowFirst[] _tableHashArraySecond;
        private HashArrayTableRowTwo[] _tableHashArrayFinal;
        private string txt;
    }
}
