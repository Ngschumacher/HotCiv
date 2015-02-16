using HotCiv.Tiles;
using Squazz.HotCiv;

namespace HotCiv.Cities
{
    public class City : ICity
    {
        public City(Player owner, string production, string workforceFocus, Tile placement)
        {
            Owner = owner;
            Production = production;
            WorkforceFocus = workforceFocus;
            Placement = placement;
        }

        public Player Owner { get; private set; }
        public int Size { get; private set; }
        public string Production { get; private set; }
        public string WorkforceFocus { get; private set; }
        public ITile Placement { get; set; }
    }
}
