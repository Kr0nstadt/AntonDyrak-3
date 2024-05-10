using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perchev_Kyrsach.Fields
{
    public class EmptyField : AbstractField, INotifyPropertyChanged
    {
        public int BombCount { get; set; }
        public override string ToString()
        {
            return BombCount.ToString();
        }
    }
}
