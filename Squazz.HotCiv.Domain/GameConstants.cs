using System;

namespace Squazz.HotCiv
{
    public class GameConstants {
        // The size of the world is set permanently to a 16x16 grid 
        public const int Worldsize = 16;
        // Valid unit types
        public const String Archer = "archer";
        public const String Legion = "legion";
        public const String Settler = "settler";
        // Valid terrain types
        public const String Plains = "plains";
        public const String Ocean = "ocean";
        public const String Forest = "forest";
        public const String Hills = "hills";
        public const String Mountains = "Mountain";
        // Valid production balance types
        public const String ProductionFocus = "hammer";
        public const String FoodFocus = "apple";
    }
}
