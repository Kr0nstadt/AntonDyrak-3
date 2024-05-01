using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perchev_Kyrsach.Fields
{
    public class GameBoard
    {
        public GameBoard(int size)
        {
            _fieldSize = size;
            _board = EmptyState(BoardIsBomb(size * size));
            
        }

        public ObservableCollection<AbstractField> Board => _board;

        public void OpenCell(int x, int y)
        {
            AbstractField c;
            if (GetCell(x, y) != -1)
            {
                c = _board[GetCell(x, y)];
                
                if(c.Flag == true)
                {
                    return;
                }

                c.IsOpen = true;
                if (c is EmptyField { BombCount: 0 })
                {
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if (GetCell(x + i, y + j) != -1)
                            {
                                c = _board[GetCell(x + i, y + j)];
                                if (c is EmptyField { BombCount: 0 } && c.IsOpen == false)
                                {
                                    OpenCell(x + i, y + j);
                                }
                                else if(c.IsOpen == false)
                                {
                                    c.IsOpen = true;
                                }
                            }

                        }
                    }
                }
            }
            
        }
        private ObservableCollection<AbstractField> BoardIsBomb(int size)
        {
            Random rnd = new Random();
            int[] BombIndex = new int[_bombCount];
            int index = 0;

            while (index < BombIndex.Length)
            {
                int val = rnd.Next(size - 1);
                if (BombIndex.Contains(val) == false)
                {
                    BombIndex[index] = val;
                    index++;
                }
            }

            ObservableCollection<AbstractField> res = new ObservableCollection<AbstractField>();
            for (int i = 0; i < size; i++)
            {
                res.Add(new EmptyField());
            }
            for (int i = 0; i < BombIndex.Length; i++)
            {
                res[BombIndex[i]] = new BombField();
            }

            return res;
        }
        private ObservableCollection<AbstractField> EmptyState(ObservableCollection<AbstractField> array)
        {
            int sizeX = _fieldSize;
            int sizeY = _fieldSize;

            for (int y = 0; y < sizeY; ++y)
            {
                for (int x = 0; x < sizeX; ++x)
                {
                    if (array[y * _fieldSize + x] is BombField)
                    {
                        SetBombCounterAroundBomb(x, y, array);
                    }
                }
            }

            return array;
        }

        private void SetBombCounterAroundBomb(int x, int y, ObservableCollection<AbstractField> array)
        {
            for (int i = -1; i < 2; ++i)
            {
                for (int j = -1; j < 2; ++j)
                {
                    if (x + j > -1 && x + j < _fieldSize &&
                        y + i > -1 && y + i < _fieldSize)
                    {
                        if (array[(y + i) * _fieldSize + x + j] is EmptyField emptyField)
                        {
                            ++emptyField.BombCount;
                        }
                    }
                }
            }
        }

        private int GetCell(int x, int y)
        {
            if (x > -1 && x < _fieldSize &&
                        y > -1 && y < _fieldSize)
            {
                return y * _fieldSize + x;
            }
            return -1;
        }

        private string StringIsOpen(AbstractField af)
        {
            if (af.IsOpen) return "_";
            else return "x";
        }
        public override string ToString()
        {
            int i = 0;
            string res = "";
            //_board[23].IsOpen = true;

            foreach (AbstractField abstractField in _board)
            {
                if (i >= _fieldSize)
                {
                    res += "\n";
                    i = 0;
                }
                res += StringIsOpen(abstractField) + " ";
                ++i;
            }
            return res;
        }

        private ObservableCollection<AbstractField> _board;
        private readonly int _fieldSize;
        private readonly int _bombCount = 40;
    }
}
