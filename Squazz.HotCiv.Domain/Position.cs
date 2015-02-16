using System;

namespace Squazz.HotCiv
{
    public class Position {
        /** create a position. 
        * @param r the row
        * @param c the column
        */
        public Position(int r, int c) { 
            Row = r;
            Column = c; 
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
        
        public override bool Equals(Object o)
        {
            Position other = o as Position;
            if (other == null) { return false; }
            return Row == other.Row && Column == other.Column;
        }

        public override int GetHashCode()
        {
            // works ok for positions up to columns == 479
            return 479 * Row + Column;
        }

        public override string ToString()
        {
            return "[" + Row + "," + Column + "]";
        }
    }
}
