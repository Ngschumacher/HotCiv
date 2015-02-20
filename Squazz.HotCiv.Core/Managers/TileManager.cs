using System;
using System.Collections.Generic;
using System.Linq;
using HotCiv.Tiles;
using Squazz.HotCiv;
using Squazz.HotCiv.Managers;

namespace HotCiv.Managers
{
    public class TileManager : ITileManager
    {
	    private int _width;
	    private int _height;
		private readonly List<ITile> _tiles = new List<ITile>(); 
		
	    public TileManager(int width, int height)
	    {
		    _width = width;
		    _height = height;
	    }
        public Plain CreatePlain(Position position)
        {
			if(!ValidPosition(position))
                return null;

            var tile = new Plain(position);
            _tiles.Add(tile);
            return tile;
        }

	    public bool ValidPosition(Position position)
	    {
		    if (position == null)
			    throw new ArgumentNullException();
		    if (GetTileAt(position) != null)
			    return false;
		    if (position.Column > _width)
			    return false;
		    if (position.Row > _height)
			    return false;

		    return true;
	    }

	    public Hill CreateHill(Position position)
        {
			if (!ValidPosition(position))
				return null;

            var tile = new Hill(position);
            _tiles.Add(tile);
            return tile;
        }
        public Mountain CreateMountain(Position position)
        {
			if (!ValidPosition(position))
                return null;

            var tile = new Mountain(position);
            _tiles.Add(tile);
            return tile;
        }
        public Ocean CreateOcean(Position position)
        {
			if (!ValidPosition(position))
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
