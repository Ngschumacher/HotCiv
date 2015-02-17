using Squazz.HotCiv;

namespace HotCiv
{
    public class Player
    {
        public Player(PlayerColor color, string name)
        {
            Color = color;
	        Name = name;
        }

        public PlayerColor Color { get; set; }
	    public string Name { get; set; }
    }
}
