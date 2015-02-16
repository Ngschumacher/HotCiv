using Squazz.HotCiv;

namespace HotCiv
{
    public class Player
    {
        public Player(PlayerColor color)
        {
            Color = color;
        }

        public PlayerColor Color { get; set; }
    }
}
