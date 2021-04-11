using System.Collections.Generic;
using System.Linq;

namespace OfxCodeExercise.Battleship.Lib
{
    public class Battleship: IBattleship
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        
        public ICollection<ShipPart> ShipParts { get; private set; }
        public Battleship()
        {
            ShipParts = new List<ShipPart>();
        }
        public Battleship(int boardId, Position start, Orientation orientation, int length): this()
        {
            BoardId = boardId;
            switch (orientation)
            {
                case Orientation.Horizontal:
                    for (int i = 0; i < length; i++)
                    {
                        ShipParts.Add(new ShipPart()
                        {
                            Position = new Position
                            {
                                X = start.X + i,
                                Y = start.Y
                            }
                        });
                    }

                    break;
                case Orientation.Vertical:
                    for (int i = 0; i < length; i++)
                    {
                        ShipParts.Add(new ShipPart()
                        {
                            Position = new Position
                            {
                                X = start.X,
                                Y = start.Y + i
                            }
                        });
                    }
                    break;
            }
        }


        public bool Attacked(Position position)
        {
            var part =  ShipParts.Where(x => x.Position == position).FirstOrDefault();
            if(part != null) part.IsHit = true;

            return part != null;
        }
    }
}
