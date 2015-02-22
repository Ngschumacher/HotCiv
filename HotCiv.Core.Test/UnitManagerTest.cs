using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotCiv.Managers;
using HotCiv.Tiles;
using HotCiv.Units;
using Squazz.HotCiv;

namespace HotCiv.Core.Test
{
	public class UnitManagerTest
	{
		public class CreateArcherMethod
		{
		    private IUnitManager _unitManager;
            private Player _redOwner = new Player(PlayerColor.Red, "First");
            private Player _blueOwner = new Player(PlayerColor.Blue, "Second");
		    public void Initialize()
		    {
		        _unitManager = new UnitManager();
		        var archer = _unitManager.Create<Archer>(_redOwner, new Plain(new Position(0, 0)));

		    }
    	}
	}
}
