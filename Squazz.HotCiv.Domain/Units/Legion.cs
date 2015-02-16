using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotCiv.Tiles;
using Squazz.HotCiv;

namespace HotCiv.Units
{
    public class Legion : Unit
    {
        public Legion(Player owner, ITile tile, int cost, int movingDistance, int defense, int attack)
            : base(owner, tile, cost, movingDistance, defense, attack)
        {
            
        }
    }
}
