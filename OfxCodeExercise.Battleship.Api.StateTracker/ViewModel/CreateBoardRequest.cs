using OfxCodeExercise.Battleship.Lib;
using System.Security.Cryptography;

namespace OfxCodeExercise.Battleship.Api.StateTracker.ViewModel
{
    public class CreateBoardRequest
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Board ToBoard()
        {
            return new Board()
            {
                Width = Width,
                Height = Height
            };
        }
    }
}