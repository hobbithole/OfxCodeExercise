using OfxCodeExercise.Battleship.Lib;

namespace OfxCodeExercise.Battleship.Api.StateTracker.ViewModel
{
    public class AttackResponse
    {
        public int BoardId { get; set; }
        public Position AttackAt { get; set; }
        public bool IsHit { get; set; }
    }
}
