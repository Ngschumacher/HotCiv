using System;
using System.Collections.Generic;
using System.Linq;
using HotCiv;
using HotCiv.Cities;
using HotCiv.Tiles;
using HotCiv.Units;
using Squazz.HotCiv.Managers;

namespace Squazz.HotCiv
{
    public class Game : IGame
    {
        
        private readonly ITileManager _tileManager;
        private readonly IUnitManager _unitManager;
        private readonly ICityManager _cityManager;
        private readonly IPlayerManager _playerManager;
        public Game(ITileManager tileManager, IUnitManager unitManager, ICityManager cityManager, IPlayerManager playerManager)
        {
            _tileManager = tileManager;
            _unitManager = unitManager;
            _cityManager = cityManager;
            _playerManager = playerManager;
        }
        public int Age { get; private set; }

        

        public ITile GetTileAt(Position position)
        {
           return _tileManager.GetTileAt(position);
        }

        public IUnit GetUnitAt(Position position)
        {
            return _unitManager.GetUnitAt(position);
        }

        public ICity GetCityAt(Position position)
        {
            return _cityManager.GetCityAt(position);
        }

        public Player GetWinner() { return null; }

        public bool MoveUnit(IUnit unit, Position to)
        {
            if (unit == null)
                return false;
            if (unit.Owner != _playerManager.GetPlayerForThisTurn())
                return false;
             if (unit.Moves > 0)
                return false;

            var tile = _tileManager.GetLegalTileForItem(to);
            if (tile == null)
                return false;

            if (tile.Occupied)
                return false;

            if (!MoveUnitToTile(unit, to))
                return false;
            unit.Placement = tile;

            return true;
        }

        private bool MoveUnitToTile(IUnit unit, Position to)
        {
            if (unit.Placement.Position.Equals(to))
            {
                return true;
            }
            var from = unit.Placement;
            if (from.Position.Column < to.Column)
            {
                var tile = _tileManager.GetLegalTileForItem(new Position(from.Position.Column + 1, from.Position.Row));
                if (!tile.Movement)
                    return false;
                var clone = (IUnit) unit.Clone();
                clone.Placement = tile;
                return MoveUnitToTile(clone, to);
            }
            return false;
        }

        public void EndOfTurn() {}
        
        public void ChangeWorkForceFocusInCityAt( Position position, String balance ) {}

        public void ChangeProductionInCityAt(Position position, String unitType) {}

        public void PerformUnitActionAt( Position position ) {}
	
        public Player AddPlayer(string name)
        {
            return _playerManager.CreatePlayer(name);
        }

        public Player GetPlayerInTurn()
        {
            return _playerManager.GetPlayerForThisTurn();
        }
    }
}