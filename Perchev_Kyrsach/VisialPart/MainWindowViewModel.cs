using Avalonia.Controls.Documents;
using Avalonia.Styling;
using Perchev_Kyrsach.Fields;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VisialPart
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly int size = 16;
        public MainWindowViewModel()
        {
            _board = new GameBoard(size);
        }

        public ObservableCollection<AbstractField> Board => _board.Board;

        public bool IsStart
        {
            get => _isStart;
            set
            {
                SetField(ref _isStart, value);
            }
        }

        public bool IsWin
        {
            get => _isWin;
            set
            {
                SetField(ref _isWin, value);
            }
        }

        public bool IsDefeat
        {
            get => _isDefeat;
            set
            {
                SetField(ref _isDefeat, value);
            }
        }

        public void OpenCell(object cell)
        {
            if(CanPlay())
            {
                for (int y = 0; y < size; ++y)
                {
                    for (int x = 0; x < size; ++x)
                    {
                        if (Board[y * size + x] == cell)
                        {
                            _board.OpenCell(x, y);
                            CheckWin();
                            CheckDefeat();
                        }
                    }
                }
            }
            
        } 

        private bool CanPlay()
        {
            return IsStart && !IsWin && !IsDefeat;
        }

        public void SetFlag(object cell)
        {
            if(CanPlay())
            {
                if (cell is AbstractField { IsOpen: false } c)
                {
                    c.Flag = !c.Flag;
                }
            }
        }

        public void StartGame(object o)
        {
            IsStart = true;
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

        private void CheckWin()
        {
            _isWin = Board.All(x => x is EmptyField { IsOpen: true });
        }

        private void CheckDefeat()
        {
            _isDefeat = Board.Any(x => x is BombField { IsOpen : true });

            if(_isDefeat)
            {
                foreach (AbstractField cell in Board)
                {
                    if (cell is BombField bombField)
                    {
                        bombField.IsOpen = true;
                    }
                }
            }
            
        }

        private bool _isStart;
        private bool _isWin;
        private bool _isDefeat;
        private GameBoard _board;

    }
}
