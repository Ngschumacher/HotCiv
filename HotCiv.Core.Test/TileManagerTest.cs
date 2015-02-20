using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotCiv.Managers;
using NUnit.Framework;
using Squazz.HotCiv;
using Squazz.HotCiv.Managers;

namespace HotCiv.Core.Test
{
	[TestFixture]
	public class TileManagerTest
	{
		[TestFixture]
		public class ValidPosition
		{
			private ITileManager _tileManager;
			[SetUp]
			public void Initialize()
			{
				_tileManager = new TileManager(16,16);
			}
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void NullPostion_ExceptionThrown()
			{
				_tileManager.ValidPosition(null);
			}

			[Test]
			public void PositionOutOfBounce_Null()
			{
				var tile = _tileManager.ValidPosition(new Position(21, 21));
				Assert.IsNotNull(tile);
			}

			[Test]
			public void PositionOccupied_Null()
			{
				var tile =  _tileManager.CreatePlain(new Position(1, 1));

				var newTile = _tileManager.ValidPosition(new Position(1, 1));
				Assert.IsFalse(newTile);
			}
		}

		[TestFixture]
		public class CreatePlainMethod
		{
			private ITileManager _tileManager;
			[SetUp]
			public void Initialize()
			{
				_tileManager = new TileManager(16, 16);
			}
			[Test]
			public void ValidPosition_success()
			{
				var tile = _tileManager.CreatePlain(new Position(12, 12));
				Assert.AreEqual(tile.Position, new Position(12,12));
			}
		}
	}
}
