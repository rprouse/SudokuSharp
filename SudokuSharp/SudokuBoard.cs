using System;

namespace SudokuSharp
{
    public class SudokuBoard
    {
        // 0 indicates not filled in
        public ushort[,] _board = new ushort[9, 9];

        public ushort Cell(ushort row, ushort column)
        {
            if (row > 8) throw new ArgumentOutOfRangeException(nameof(row));
            if (column > 8) throw new ArgumentOutOfRangeException(nameof(column));
            return _board[row, column];
        }
    }
}
