using System.Collections.Generic;
using System.Linq;
using HotCiv;
using HotCiv.Tiles;
using HotCiv.Units;
using NUnit.Framework;
using Squazz.HotCiv.Managers;

namespace Squazz.HotCiv.Core.Tests
{
    [TestFixture]
    public class AlphaCivTests
    {
        Game _game;
        UnitManager _unitManager;
        CityManager _cityManager;
        TileManager _tileManager;
        PlayerManager _playerManager;

        [TestFixtureSetUp]
        public void Initialize()
        {

            _unitManager = new UnitManager();
            _cityManager = new CityManager();
            _tileManager = new TileManager();
            _playerManager = new PlayerManager();

            WorldSetup();

            _game = new Game(_tileManager, _unitManager, _cityManager, _playerManager);
        }

        [Test]
        public void AddPlayers()
        {
            var player1 = _game.AddPlayer("Første");
            Assert.AreEqual(PlayerColor.Red, player1.Color, "First player should be color red");
            var player2 = _game.AddPlayer("Anden");
            Assert.AreEqual(PlayerColor.Blue, player2.Color, "Second player should be color Blue");
            var player3 = _game.AddPlayer("Tredje");
            Assert.Null(player3, "Shouldn't be able to create the third player");
        }

        [Test]
        public void FirstPlayer()
        {
            Assert.AreEqual(PlayerColor.Red, _game.GetPlayerInTurn().Color, "Red should be the first player to do a action");
        }

        [Test]
        public void ShouldHaveCityAt1_1()
        {
            Assert.IsNotNull(_game.GetCityAt(new Position(1, 1)), "Should have a city at 1,1");
            Assert.AreEqual(PlayerColor.Red, _game.GetCityAt(new Position(1, 1)).Owner.Color, "City at (1,1) should be owned by red");
        }

         [Test]
        public void OceanAt1_0()
        {
            Assert.AreEqual("Ocean", _game.GetTileAt(new Position(1,0)));
        }

        [Test]
        public void WordLayOut()
        {
            Assert.AreEqual("Ocean", _game.GetTileAt(new Position(1, 0)));
            Assert.AreEqual("hill", _game.GetTileAt(new Position(0, 1)));
            Assert.AreEqual("Mountain", _game.GetTileAt(new Position(2, 2)));
        }

        [Test]
        public void UnitMoveUp()
        {
           var unit = _game.GetUnitAt(new Position(3, 2));
           Assert.IsTrue(_game.MoveUnit(unit, new Position(2, 2)), "The unit moved a from 3,2 to 2,2 (One up)");
        }

        [Test]
        public void UnitMoveRight()
        {
            var unit = _game.GetUnitAt(new Position(3, 2));
            Assert.IsTrue(_game.MoveUnit(unit, new Position(3, 3)), "The unit moved a from 3,2 to 3,3 (One right)");
        }

        [Test]
        public void UnitMoveLeft()
        {
            var unit = _game.GetUnitAt(new Position(3, 2));
            Assert.IsTrue(_game.MoveUnit(unit, new Position(3, 1)), "The unit moved a from 3,2 to 3,1 (One Left)");
        }

        [Test]
        public void UnitMoveDown()
        {
            var unit = _game.GetUnitAt(new Position(3, 2));
            Assert.IsTrue(_game.MoveUnit(unit, new Position(4, 2)), "The unit moved a from 3,2 to 4,2 (One down)");
        }

        [Test]
        public void UnitMoveUpRight()
        {
            var unit = _game.GetUnitAt(new Position(3, 2));
            Assert.IsTrue(_game.MoveUnit(unit, new Position(2, 3)), "The unit moved a from 3,2 to 2,3 (One upright (diagonal))");
        }

        [Test]
        public void UnitMoveUpLeft()
        {
            var unit = _game.GetUnitAt(new Position(3, 2));
            Assert.IsTrue(_game.MoveUnit(unit, new Position(2, 1)), "The unit moved a from 3,2 to 2,1 (One upleft (diagonal))");
        }

        [Test]
        public void UnitMoveDownRight()
        {
            var unit = _game.GetUnitAt(new Position(3, 2));
            Assert.IsTrue(_game.MoveUnit(unit, new Position(3, 3)), "The unit moved a from 3,2 to 3,3 (One downright (diagonal))");
        }

        [Test]
        public void UnitMoveDownLeft()
        {
            var unit = _game.GetUnitAt(new Position(3, 2));
            Assert.IsTrue(_game.MoveUnit(unit, new Position(3, 1)), "The unit moved a from 3,2 to 3,1 (One downleft (diagonal))");
        }

        [Test]
        public void UserCantMoveToMountain()
        {
            //to be implemented
        }

        [Test]
        public void UserCantMoveToOcean()
        {
            //to be implemented
        }

        [Test]
        public void UserCantMoveOverMountain()
        {
            //to be implemented
        }

        [Test]
        public void UserCantMoveOverOcean()
        {
            //to be implemented
        }

        [Test]
        public void RedCantMoveBluesUnits()
        {
            //to be implemented
        }

        [Test]
        public void CityProduce6AfterEndTurn()
        {
            //to be implemented
        }

        [Test]
        public void CityPopulation()
        {
            Assert.AreEqual(1, _game.GetCityAt(new Position(1, 1)).Size, "City at (1,1) should have 1 in population");
            //to be implemented
        }

        [Test]
        public void AfterRedEndTurnThenBlueTurn()
        {
            //to be implemented
        }

        [Test]
        public void RedTurnThenBlueThenRed()
        {
            //to be implemented
        }

        [Test]
        public void RedWinsInYear3000()
        {
            //to be implemented
        }

        [Test]
        public void RedAttack()
        {
            //to be implemented
        }





        public void WorldSetup()
        {
            var list = new List<ITile>();

            //create the special fields first
            _tileManager.CreateOcean(new Position(1, 0));
            _tileManager.CreateHill(new Position(0, 1));
            _tileManager.CreateMountain(new Position(2, 2));

            //fill the rest with plain fields
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    _tileManager.CreatePlain(new Position(i, j));
                }
            }

             var playerRed = new Player(PlayerColor.Red);
            var playerBlue = new Player(PlayerColor.Blue);

            _unitManager.CreateArcher(playerRed, _tileManager.GetLegalTileForItem(new Position(2, 0)));
            _unitManager.CreateSettler(playerRed, _tileManager.GetLegalTileForItem(new Position(4, 3)));
            _unitManager.CreateLegion(playerBlue, _tileManager.GetLegalTileForItem(new Position(3, 2)));

        }
    }
}