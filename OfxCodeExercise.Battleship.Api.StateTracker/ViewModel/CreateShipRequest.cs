using OfxCodeExercise.Battleship.Lib;

namespace OfxCodeExercise.Battleship.Api.StateTracker.ViewModel
{
    public class CreateShipRequest
    {
        public int BoardId { get; set; }
        public Position StartAt { get; set; }
        public Orientation Orientation { get; set; }
        public int Length { get; set; }
        public Lib.Battleship ToBattleship()
        {
            var battleship = new Lib.Battleship(BoardId, StartAt, Orientation, Length);
            return battleship;
        }
    }
}
