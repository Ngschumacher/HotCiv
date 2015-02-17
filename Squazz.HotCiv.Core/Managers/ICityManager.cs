using HotCiv.Cities;
using HotCiv.Tiles;

namespace Squazz.HotCiv.Managers
{
	public interface ICityManager
	{
		ICity GetCityAt(Position position);
		ICity GetCityAt(ITile tile);
	}
}