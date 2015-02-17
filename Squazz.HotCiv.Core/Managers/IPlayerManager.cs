using HotCiv;

namespace Squazz.HotCiv.Managers
{
	public interface IPlayerManager
	{
		Player CreatePlayer(string name);
		Player GetPlayerForThisTurn();
		Player NextPlayersTurn();
	}
}