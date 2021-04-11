using System.Collections;

namespace OfxCodeExercise.Battleship.Lib
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static bool operator == (Position lh, Position rh)
        {
            return lh.Equals(rh);
        }
        public static bool operator !=(Position lh, Position rh)
        {
            return !lh.Equals(rh);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Position))
                return false;
            return Equals((Position)obj);
        }
        public bool Equals(Position other)
        {
            if (X != other.X) return false;
            return Y == other.Y;
        }


    }
}
