using Perchev_Kyrsach.Fields;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Avalonia.Threading;
using Perchev_Kyrsach.Model;

namespace VisialPart
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        
        public MainWindowViewModel()
        {
            _repository =
                new Repository(
                    "C:\\Users\\iamna\\YandexDisk-mileschko.sibsutis\\Информатика 2023\\AntonDyrak-3\\Perchev_Kyrsach\\Perchev_Kyrsach\\PointsDB.db");
            Context = new MinesweeperViewModel(_repository);
        }

        public INotifyPropertyChanged Context
        {
            get => _context;
            set
            {
                SetField(ref _context, value);
            }
        }

        public void ChangeViewModel()
        {
            if (Context is MinesweeperViewModel)
            {
                Context = new PointsTableViewModel(_repository);
            }
            else
            {
                Context = new MinesweeperViewModel(_repository);
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

        private INotifyPropertyChanged _context;
        private Repository _repository;
    }
}
