using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Perchev_Kyrsach.Fields
{
    public abstract class AbstractField : INotifyPropertyChanged
    {
        public bool Flag
        {
            get => _flag;
            set
            {
                SetField(ref _flag, value);
            }
        }
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                SetField(ref _isOpen, value);
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private bool _flag;
        private bool _isOpen;
    }
}
