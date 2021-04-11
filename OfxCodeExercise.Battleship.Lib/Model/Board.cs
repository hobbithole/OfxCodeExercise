using OfxCodeExercise.Battleship.Lib.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace OfxCodeExercise.Battleship.Lib
{
    public class Board
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public ICollection<Battleship> Ships { get; private set; }

        public Board()
        {
            Ships = new List<Battleship>();
        }
        public  Battleship AddBattleship(Battleship ship)
        {
            // Check battleship size
            var fitBoardSize = CheckBatteshipFitIntoBoard(ship);
            if (!fitBoardSize)
                throw new InvalidRequestException("The battleship can not fit into the specified board");

            // Detect if the ship has collision with existing ships on the board
            var noCollision = CheckNoCollision(ship);

            if(!noCollision)
                throw new ShipCollisionException();

            ship.Id = Ships.Count + 1;
            Ships.Add(ship);
            return ship;
                
        }

        private bool CheckBatteshipFitIntoBoard(Battleship ship)
        {
            if(ship.ShipParts.Select(p => p.Position.X).Max() >= Width) return false;
            if (ship.ShipParts.Select(p => p.Position.Y).Max() >= Height) return false;
            return true;
        }
        private bool CheckNoCollision(Battleship ship)
        {
            var positions = Ships.SelectMany(s => s.ShipParts).Select(p=>p.Position);
            var collisionPoints = positions.Where(p => ship.ShipParts.Select(s => s.Position).Contains(p));
            return !collisionPoints.Any();
            
        }
    }
}
