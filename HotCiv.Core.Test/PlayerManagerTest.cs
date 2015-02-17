using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotCiv.Managers;
using NUnit.Framework;
using Squazz.HotCiv.Managers;

namespace HotCiv.Core.Test
{
	[TestFixture]
	public class PlayerManagerTest
	{
		

		public class CreatePlayerMethod
		{
			private PlayerManager _playerManager;

			[SetUp]
			public void Initialize()
			{
				_playerManager = new PlayerManager();
			}
		
			[Test]
			public void OnePlayer_Success()
			{
				var player1 = _playerManager.CreatePlayer("Første");
				Assert.AreEqual(PlayerColor.Red, player1.Color, "First player should be color red");
				var player2 = _playerManager.CreatePlayer("Anden");
				Assert.AreEqual(PlayerColor.Blue, player2.Color, "Second player should be color Blue");
				var player3 = _playerManager.CreatePlayer("Tredje");
				Assert.Null(player3, "Shouldn't be able to create the third player");
			}

			[Test]
			public void TwoPlayers_Success()
			{
				var player1 = _playerManager.CreatePlayer("Første");
				Assert.AreEqual(PlayerColor.Red, player1.Color, "First player should be color red");
				var player2 = _playerManager.CreatePlayer("Anden");
				Assert.AreEqual(PlayerColor.Blue, player2.Color, "Second player should be color Blue");
			}

			[Test]
			public void ThreePlayers_ThirdReturnNull()
			{
				var player1 = _playerManager.CreatePlayer("Første");
				Assert.AreEqual(PlayerColor.Red, player1.Color, "First player should be color red");
				var player2 = _playerManager.CreatePlayer("Anden");
				Assert.AreEqual(PlayerColor.Blue, player2.Color, "Second player should be color Blue");
				var player3 = _playerManager.CreatePlayer("Tredje");
				Assert.Null(player3, "Shouldn't be able to create the third player");
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void NameNull_ThrowNullException()
			{
				var player = _playerManager.CreatePlayer(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void NameEmpty_ThrowNullException()
			{
				var player = _playerManager.CreatePlayer(string.Empty);
			}
			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void NameWhiteplace_ThrowNullException()
			{
				var player = _playerManager.CreatePlayer(" ");
			}
		}

		public class GetCurrentPlayerThisTurnMethod
		{
			private PlayerManager _playerManager;

			[SetUp]
			public void Initialize()
			{
				_playerManager = new PlayerManager();
			}

			[Test]
			public void NoUsers_Null()
			{
				var playerInTurn = _playerManager.GetPlayerForThisTurn();
				Assert.IsNull(playerInTurn);
			}

			[Test]
			public void onlyOneUser_Success()
			{
				_playerManager.CreatePlayer("first");
				var playerInTurn = _playerManager.GetPlayerForThisTurn();
				Assert.AreEqual("first", playerInTurn.Name);
			}

			[Test]
			public void TwoUsersStillFirst_Success()
			{
				_playerManager.CreatePlayer("first");
				_playerManager.CreatePlayer("second");
				var playerInTurn = _playerManager.GetPlayerForThisTurn();
				Assert.AreEqual("first", playerInTurn.Name);
			}
		}

		public class NextPlayersTurn
		{
			private PlayerManager _playerManager;

			[SetUp]
			public void Initialize()
			{
				_playerManager = new PlayerManager();
			}

			[Test]
			[ExpectedException(typeof(NoNullAllowedException))]
			public void NoUsers_ThrowException()
			{
				var nextPlayer = _playerManager.NextPlayersTurn();
			}
			

			[Test]
			public void FirstPlayer_Succes()
			{
				var firstPlayer = _playerManager.CreatePlayer("First");

				var currentPlayer = _playerManager.GetPlayerForThisTurn();
				var nextPlayer = _playerManager.NextPlayersTurn();

				Assert.AreEqual(firstPlayer.Name, currentPlayer.Name, "First added user, has first turn");
				Assert.AreEqual(firstPlayer.Name, nextPlayer.Name, "Only one user, same users turn");
			}

			[Test]
			public void TwoUsers_Succes()
			{
				var firstPlayer = _playerManager.CreatePlayer("First");
				var secondPlayer = _playerManager.CreatePlayer("Second");


				var currentPlayer = _playerManager.GetPlayerForThisTurn();
				Assert.AreEqual(firstPlayer.Name, currentPlayer.Name, "First added user, has first turn");

				var nextPlayer = _playerManager.NextPlayersTurn();
				Assert.AreEqual(secondPlayer.Name, nextPlayer.Name, "Next user, should be 'second'");
			}

			[Test]
			public void FirstUserGetsTurnAgian_Success()
			{
				var firstPlayer = _playerManager.CreatePlayer("First");
				var secondPlayer = _playerManager.CreatePlayer("Second");


				var currentPlayer = _playerManager.GetPlayerForThisTurn();
				Assert.AreEqual(firstPlayer.Name, currentPlayer.Name, "First added user, has first turn");
				 
				var nextPlayer = _playerManager.NextPlayersTurn();
				Assert.AreEqual(secondPlayer.Name, nextPlayer.Name, "Next user, should be 'second'");

				currentPlayer = _playerManager.NextPlayersTurn();
				Assert.AreEqual(firstPlayer.Name, currentPlayer.Name, "First players turn once agian.");
			}
		}
	}
}
