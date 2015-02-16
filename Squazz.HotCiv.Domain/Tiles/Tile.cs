using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Squazz.HotCiv;

namespace HotCiv.Tiles
{
    public class Tile : ITile
    {

        public Tile(Position position, bool movement)
        {
            Position = position;
            Movement = movement;
        }

        public Position Position { get; private set; }
        public string Type { get; private set; }
        public bool Movement { get; private set; }
        public bool Occupied { get; private set; }

        public void SetOccupitation(bool value)
        {
            if (Movement == false)
            {
                throw new Exception("Can't occupy of type: "+ Type);
            }
            if (Occupied == value)
            {
                throw new Exception("Tried to set Occupitation to same value as it had current Value : "+ Occupied +" new value: "+ value);
            }
            Occupied = value;
        }
    }
}
