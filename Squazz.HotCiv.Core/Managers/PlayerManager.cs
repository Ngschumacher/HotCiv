using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotCiv;

namespace Squazz.HotCiv.Managers
{
    public class PlayerManager
    {
        readonly List<Player> _players = new List<Player>();
        private Player CurrentPlayersTurn = null;
        public Player CreatePlayer(string name)
        {
            if (!Enum.IsDefined(typeof(PlayerColor), _players.Count)){
                return null;
            }

            var player = new Player((PlayerColor)_players.Count);
            //No players yet, make it first players turn.
            if (_players.Count == 0)
            {
                CurrentPlayersTurn = player;
            }
            _players.Add(player);

            return player;
        }

        public Player GetPlayerForThisTurn()
        {
            return CurrentPlayersTurn;
        }

        public Player NextPlayersTurn()
        {
            var currentPlayerIndex = _players.IndexOf(CurrentPlayersTurn);
            var newPlayer = _players[++currentPlayerIndex];
            if (newPlayer == null)
            {
                return _players[0];
            }
            else
            {
                return newPlayer;
            }
        }
    }
}
