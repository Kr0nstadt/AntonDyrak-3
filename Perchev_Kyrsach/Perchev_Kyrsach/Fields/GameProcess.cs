using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perchev_Kyrsach.Fields
{
    public class GameProcess
    {
        public bool GameState;
        
        private AbstractField[] _board;

        public GameProcess(GameBoard board)
        {
            _board = board.Board.ToList().ToArray();
        }
        private AbstractField CellOpen(AbstractField cell)
        {
            if(cell.Flag == true)
            {
                cell.Flag = false;
                return cell;
            }
            else
            {
                if(cell is EmptyField _cell)
                {
                    _cell.IsOpen = true;
                    if (EmptyOpenAll())
                    {
                        GameState = true;
                    }
                    return cell;
                }
                if(cell is BombField _bomb)
                {
                    GameState = false;
                    return cell;
                }
                return cell;
            }
        }
        private bool EmptyOpenAll()
        {
            List<int> EmptyIndex = new List<int>();
            for(int i = 0; i < _board.Length; i++)
            {
                if(_board[i] is EmptyField && _board[i].IsOpen == false && _board[i].Flag == false)
                {
                    EmptyIndex.Add(i);
                }
            }
            if(EmptyIndex.Count == 0) { return true; }
            return false;
        }
        //if(EmptyOpenAll == true && GameState == true) == WIN
    }
}
