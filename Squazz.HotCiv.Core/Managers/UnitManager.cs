using System;
using System.Collections.Generic;
using System.Linq;
using HotCiv.Tiles;
using HotCiv.Units;
using Squazz.HotCiv;
using Squazz.HotCiv.Managers;

namespace HotCiv.Managers
{
    public class UnitManager : IUnitManager
    {
        readonly List<IUnit> _units = new List<IUnit>();

	    public IUnit Create<TIUnit>()
	    {
		    
	    }

        public IUnit Create<T>(Player owner, ITile tilePosition) where T : IUnit
        {
            if (tilePosition == null)
                return null;

            if (typeof (T) != typeof (IUnit))
                throw new NotSupportedException(typeof(T) + "");

            if (_units.Any(x => x.Placement.Equals(tilePosition)))
                return null;

            //Do something smart here
            IUnit unit = null;
            if (typeof (T) == typeof (Archer))
            {
                unit = new Archer(owner, tilePosition, 10, 1, 3, 2);
            }
            else if (typeof(T) == typeof(Legion))
            {
                unit = new Legion(owner, tilePosition, 15, 1, 2, 4);
            }
            else if (typeof(T) == typeof(Settler))
            {
                unit = new Settler(owner, tilePosition, 30, 1, 3, 0);
            }

            if (unit != null)
            {
                _units.Add(unit);
                return unit;
            }
            return null;

        }

        public Archer CreateArcher(Player owner, ITile tilePosition)
        {
            
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
