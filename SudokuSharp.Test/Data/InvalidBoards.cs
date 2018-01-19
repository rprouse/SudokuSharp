namespace SudokuSharp.Test.Data
{
    /// <summary>
    /// These boards do not pass validity tests for various reasons
    /// </summary>
    public class InvalidBoards
    {
        public static readonly string[] Boards = new[]
        {
            // Same number in column 4
            "100830002570001000000509064704008590003010400051430306360704000000600079800052003",
            // Same number in row 5
            "100830002570001000000509064704008590003010400051460306360704000000600079800052003",
            // Same number in box 1,0
            "100830002570001000000589064704008590003010400051400306360704000000600079800052003",
            // Same number in box 1,1
            "100830002570001000000509064704008590003010400051480306360704000000600079800052003",
            // Same number in box 2,1
            "100830002570001000000509064704008590003010405051400306360704000000600079800052003",
        };
    }
}
