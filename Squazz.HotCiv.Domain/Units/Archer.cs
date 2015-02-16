using HotCiv.Tiles;
using Squazz.HotCiv;

namespace HotCiv.Units
{
    public class Archer : Unit
    {
        public Archer(Player owner, ITile tile, int cost, int movingDistance, int defense, int attack) 
            : base(owner, tile, cost, movingDistance, defense, attack)
        {
        }
        
    }
}
