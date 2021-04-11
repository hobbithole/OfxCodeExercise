using OfxCodeExercise.Battleship.Lib;

namespace OfxCodeExercise.Battleship.Api.StateTracker.ViewModel
{
    public class ShipViewModel
    {
        public int BoardId { get; set; }
        public int Id { get; set; }
        public ShipViewModel()
        {

        }
        public ShipViewModel(Lib.Battleship ship)
        {
            BoardId = ship.BoardId;
            Id = ship.Id;
        }
    }
}
