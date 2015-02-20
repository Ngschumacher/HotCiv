using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotCiv.Managers;
using HotCiv.Tiles;
using NSubstitute;
using NUnit.Framework;
using Squazz.HotCiv;
using Squazz.HotCiv.Managers;

namespace HotCiv.Core.Test
{
	[TestFixture]
	public class GameTest
	{
		Game _game;
		IUnitManager _unitManager;
		ICityManager _cityManager;
		ITileManager _tileManager;
		IPlayerManager _playerManager;

		[SetUp]
		public void Initialize()
		{

			_unitManager = Substitute.For<IUnitManager>();
			_cityManager = Substitute.For<ICityManager>();
			_tileManager = Substitute.For<ITileManager>();
			_playerManager = Substitute.For<IPlayerManager>();

			WorldSetup();

			_game = new Game(_tileManager, _unitManager, _cityManager, _playerManager);
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
			Assert.AreEqual("Ocean", _game.GetTileAt(new Position(1, 0)));
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

			var playerRed = new Player(PlayerColor.Red, "First");
			var playerBlue = new Player(PlayerColor.Blue, "Second");

			_unitManager.CreateArcher(playerRed, _tileManager.GetLegalTileForItem(new Position(2, 0)));
			_unitManager.CreateSettler(playerRed, _tileManager.GetLegalTileForItem(new Position(4, 3)));
			_unitManager.CreateLegion(playerBlue, _tileManager.GetLegalTileForItem(new Position(3, 2)));

		}
	}
}
