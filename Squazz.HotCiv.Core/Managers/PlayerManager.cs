using System;
using System.Collections.Generic;
using System.Data;
using Squazz.HotCiv.Managers;

namespace HotCiv.Managers
{
    public class PlayerManager : IPlayerManager
    {
        readonly List<Player> _players = new List<Player>();
        private Player _currentPlayersTurn = null;
        public Player CreatePlayer(string name)
        {
	        if (name == null)
				throw new ArgumentNullException("name");
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("name");
            if (!Enum.IsDefined(typeof(PlayerColor), _players.Count)){
                return null;
            }

            var player = new Player((PlayerColor)_players.Count, name);
            //No players yet, make it first players turn.
            if (_players.Count == 0)
            {
                _currentPlayersTurn = player;
            }
            _players.Add(player);

            return player;
        }

        public Player GetPlayerForThisTurn()
        {
            return _currentPlayersTurn;
        }

        public Player NextPlayersTurn()
        {
			if(_currentPlayersTurn == null)
				throw new NoNullAllowedException("currentPlayerInTurn is null, no users");
            var currentPlayerIndex = _players.IndexOf(_currentPlayersTurn) + 1;
	       
			if (currentPlayerIndex == _players.Count)
	        {
		        currentPlayerIndex = 0;
	        }
			
	        _currentPlayersTurn = _players[currentPlayerIndex];

	        return GetPlayerForThisTurn();
        }
    }
}
