using System.Collections.Generic;
using System.Linq;
using HotCiv.Tiles;

namespace Squazz.HotCiv.Managers
{
    public class TileManager : ITileManager
    {
        private readonly List<ITile> _tiles = new List<ITile>(); 
        public Plain CreatePlain(Position position)
        {
            if (GetTileAt(position) != null)
                return null;

            var tile = new Plain(position);
            _tiles.Add(tile);
            return tile;
        }
        public Hill CreateHill(Position position)
        {
            if (GetTileAt(position) != null)
                return null;

            var tile = new Hill(position);
            _tiles.Add(tile);
            return tile;
        }
        public Mountain CreateMountain(Position position)
        {
            if (GetTileAt(position) != null)
                return null;

            var tile = new Mountain(position);
            _tiles.Add(tile);
            return tile;
        }
        public Ocean CreateOcean(Position position)
        {
            if (GetTileAt(position) != null)
                return null;

            var tile = new Ocean(position);
            _tiles.Add(tile);
            return tile;
        }

        public ITile GetTileAt(Position position)
        {
            return _tiles.FirstOrDefault(x => x.Position.Equals(position));
        }
        public ITile GetLegalTileForItem(Position position)
        {
            return _tiles.FirstOrDefault(x => x.Position.Equals(position) && x.Movement);
        }
    }
}
