using OfxCodeExercise.Battleship.Lib;
using System.Security.Cryptography;

namespace OfxCodeExercise.Battleship.Api.StateTracker.ViewModel
{
    public class BoardViewModel
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public BoardViewModel()
        {

        }
        public BoardViewModel(Board board)
        {
            Id = board.Id;
            Width = board.Width;
            Height = board.Height;
        }
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