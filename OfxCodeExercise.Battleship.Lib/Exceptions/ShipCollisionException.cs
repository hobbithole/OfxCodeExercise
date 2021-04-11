using System;

namespace OfxCodeExercise.Battleship.Lib.Exceptions
{
    public class ShipCollisionException: ApplicationException
    {
        public ShipCollisionException() : base("Detected collision when adding a new boat to the board.")
        {
        }
    }
}
