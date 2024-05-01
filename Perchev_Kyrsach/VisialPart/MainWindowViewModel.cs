using Perchev_Kyrsach.Fields;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Avalonia.Threading;

namespace VisialPart
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        
        public MainWindowViewModel()
        {
            _board = new GameBoard(_size);
            Board = new ObservableCollection<AbstractField>(_board.Board);
        }

        public ObservableCollection<AbstractField> Board
        {
            get => _cells;
            set
            {
                SetField(ref _cells, value);
            }
        } 

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

        public int Seconds
        {
            get => _seconds;
            set
            {
                SetField(ref _seconds, value);
            }
        }

        public string NickName
        {
            get => _nickName;
            set
            {
                SetField(ref _nickName, value);
            }
        }

        public void OpenCell(object cell)
        {
            if(CanPlay())
            {
                for (int y = 0; y < _size; ++y)
                {
                    for (int x = 0; x < _size; ++x)
                    {
                        if (Board[y * _size + x] == cell)
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
            if (!string.IsNullOrEmpty(NickName) &&
                !string.IsNullOrWhiteSpace(NickName))
            {
                IsStart = true;
                IsWin = false;
                IsDefeat = false;
                Seconds = 0;
                _board = new GameBoard(_size);
                Board = new ObservableCollection<AbstractField>(_board.Board);
                _timer = new DispatcherTimer(TimeSpan.FromSeconds(1),
                    DispatcherPriority.Normal,
                    (s, e) => { ++Seconds; });
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

        private void CheckWin()
        {
            //_isWin = Board.All(x => x is EmptyField { IsOpen: true });
            _isWin = Board.Where(x => x is EmptyField)
                .All(x => x.IsOpen);
            if (_isWin)
            {
                _timer.Stop();
            }
        }

        private void CheckDefeat()
        {
            _isDefeat = Board.Any(x => x is BombField { IsOpen : true });

            if(_isDefeat)
            {
                _timer.Stop();
                foreach (AbstractField cell in Board)
                {
                    if (cell is BombField {Flag:false} bombField)
                    {
                        bombField.IsOpen = true;
                    }
                }
            }
        }

        private bool _isStart;
        private bool _isWin;
        private bool _isDefeat;
        private readonly int _size = 16;
        private GameBoard _board;
        private ObservableCollection<AbstractField> _cells;
        private int _seconds;
        private DispatcherTimer _timer;
        private string _nickName;
    }
}
