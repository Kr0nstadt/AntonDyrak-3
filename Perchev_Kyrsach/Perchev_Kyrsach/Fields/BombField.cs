using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perchev_Kyrsach.Fields
{
    public class BombField : AbstractField, INotifyPropertyChanged
    {
        public override string ToString()
        {
            return "B";
        }
    }
}
