using System;
using System.Collections.Generic;
using System.Text;

namespace OfxCodeExercise.Battleship.Lib
{
    public interface IBattleshipProvider
    {
        ICollection<Board> GetBoards();
        ICollection<Battleship> GetShipsOnBoard(int boardId);
        Board CreateBoard(Board board);
        Battleship AddShipToBoard(int boardId, Battleship ship);
        bool Attack(int boardId, Position position);
    }
}
