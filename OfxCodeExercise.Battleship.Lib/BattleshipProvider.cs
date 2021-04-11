using OfxCodeExercise.Battleship.Lib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OfxCodeExercise.Battleship.Lib
{
    public class BattleshipProvider : IBattleshipProvider
    {
        private List<Board> _boards = new List<Board>();
        private Object _lock = new object();
        public Battleship AddShipToBoard(int boardId, Battleship ship)
        {
            lock(_lock)
            {
                var board = _boards.FirstOrDefault(b => b.Id == boardId);
                if (board == null)
                {
                    throw new InvalidRequestException("Wrong board id; the specified board could not be found.");
                }
                board.AddBattleship(ship);
                return ship;
            }
        }

        public bool Attack(int boardId, Position position)
        {
            Board board;
            lock(_lock)
            {
                board = _boards.FirstOrDefault(b => b.Id == boardId);
            }
            
            foreach(var ship in board.Ships)
            {
                if(ship.Attacked(position))
                {
                    return true;
                }
            }
            return false;
        }

        public Board CreateBoard(Board board)
        {
            var newBoard = new Board()
            {
                Width = board.Width,
                Height  = board.Height
            };
            lock(_lock)
            {
                newBoard.Id = _boards.Count + 1;
                _boards.Add(newBoard);
            }
            return newBoard;
        }

        public ICollection<Board> GetBoards()
        {
            throw new NotImplementedException();
        }

        public ICollection<Battleship> GetShipsOnBoard(int boardId)
        {
            throw new NotImplementedException();
        }
    }
}
