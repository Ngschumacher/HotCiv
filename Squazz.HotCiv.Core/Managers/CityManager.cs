using System.Collections.Generic;
using System.Linq;
using HotCiv.Cities;
using HotCiv.Tiles;

namespace Squazz.HotCiv.Managers
{
    public class CityManager
    {
        private readonly List<ICity> _cities = new List<ICity>(); 
        public ICity GetCityAt(Position position)
        {
            return _cities.FirstOrDefault(x => x.Placement.Position.Equals(position));
        }
        public ICity GetCityAt(ITile tile)
        {
            return _cities.FirstOrDefault(x => x.Placement.Equals(tile));
        }
    }
}
