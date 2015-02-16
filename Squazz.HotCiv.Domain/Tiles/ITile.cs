using Squazz.HotCiv;

namespace HotCiv.Tiles
{
    public interface ITile
    {
        /** return position of this tile on the board. 
         * @return position of tile.
         */
        Position Position { get; }

        /** return the tile type as a string. The set of
         * valid strings are defined by the graphics
         * engine, as they correspond to named image files.
         * @return the type type as string
         */
        string Type { get; }
        bool Movement { get; }
        bool Occupied { get; }
        void SetOccupitation(bool value);

    }
}
