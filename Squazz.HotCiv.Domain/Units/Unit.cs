using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotCiv.Tiles;
using Squazz.HotCiv;

namespace HotCiv.Units
{
    public class Unit : IUnit, ICloneable
    {
        public Unit(Player owner, ITile placement, int cost, int movingDistance, int defense, int attack)
        {
            Owner = owner;
            Placement = placement;
            Defense = defense;
            Attack = attack;
            Moves = movingDistance;
            Placement.SetOccupitation(true);
        }
        public string Type { get; private set; }
        public Player Owner { get; private set; }
        public int Moves { get; set; }
        public int Defense { get; private set; }
        public int Attack { get; private set; }
        public ITile Placement { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
