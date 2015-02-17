using System.Collections.Generic;
using System.Linq;
using HotCiv;
using HotCiv.Tiles;
using HotCiv.Units;

namespace Squazz.HotCiv.Managers
{
    public class UnitManager : IUnitManager
    {
        readonly List<IUnit> _units = new List<IUnit>(); 
        public Archer CreateArcher(Player owner, ITile tilePosition)
        {
            if (tilePosition == null)
                return null;
            var unit = new Archer(owner, tilePosition, 10, 1, 3, 2);
            _units.Add(unit);
            return unit;
        }

        public Legion CreateLegion(Player owner, ITile tilePosition)
        {
            if (tilePosition == null)
                return null;
            var unit = new Legion(owner, tilePosition, 15, 1, 2, 4);
            _units.Add(unit);
            return unit;
        }

        public Settler CreateSettler(Player owner, ITile tilePosition)
        {
            if (tilePosition == null)
                return null;
            var unit = new Settler(owner,tilePosition, 30, 1, 3, 0);
            _units.Add(unit);
            return unit;
        }

        public IUnit GetUnitAt(Position position)
        {
            return _units.FirstOrDefault(x => x.Placement.Position.Equals(position));
        }
    }
}
