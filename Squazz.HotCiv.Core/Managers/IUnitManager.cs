using HotCiv.Tiles;
using HotCiv.Units;
using Squazz.HotCiv;

namespace HotCiv.Managers
{
	public interface IUnitManager
	{
		Archer CreateArcher(Player owner, ITile tilePosition);
		Legion CreateLegion(Player owner, ITile tilePosition);
		Settler CreateSettler(Player owner, ITile tilePosition);
		IUnit GetUnitAt(Position position);
	}
}