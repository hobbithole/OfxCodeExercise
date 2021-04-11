using OfxCodeExercise.Battleship.Lib;

namespace OfxCodeExercise.Battleship.Api.StateTracker.ViewModel
{
    public class AttackRequest
    {
        public int BoardId { get; set; }
        public Position AttackAt { get; set; }
    }
}
