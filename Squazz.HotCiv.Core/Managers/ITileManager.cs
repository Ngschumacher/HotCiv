using HotCiv.Tiles;

namespace Squazz.HotCiv.Managers
{
	public interface ITileManager
	{
		Plain CreatePlain(Position position);
		Hill CreateHill(Position position);
		Mountain CreateMountain(Position position);
		Ocean CreateOcean(Position position);
		ITile GetTileAt(Position position);
		ITile GetLegalTileForItem(Position position);

		bool ValidPosition(Position position);
	}
}