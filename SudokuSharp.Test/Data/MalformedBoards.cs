using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSharp.Test.Data
{
    public static class MalformedBoards
    {
        public static readonly string[] Boards = new[]
        {
            // Too many characters
            "0610300200500081070003007034009006078003209506570300900190700000802400060040010250",
            // Too few characters
            "10083000257000100000509064704008590003010400051400306360704000000600079800052003",
            // Invalid characters
            "A61030020050008107000007034009006078003209506570300900190700000802400060040010250",
            // No characters
            ""
        };
    }
}
