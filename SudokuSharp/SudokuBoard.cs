using System;

namespace SudokuSharp
{
    public class SudokuBoard
    {
        // 0 indicates not filled in
        public ushort[,] _board = new ushort[9, 9];

        public ushort Cell(ushort x, ushort y)
        {
            if (x > 8) throw new ArgumentOutOfRangeException(nameof(x));
            if (y > 8) throw new ArgumentOutOfRangeException(nameof(y));
            return _board[x, y];
        }

        /// <summary>
        /// Loads a board from a flat string representation. 0 or space is treated
        /// as not filled in. The string must be 81 characters long and only contain
        /// spaces or 0 to 9.
        /// </summary>
        /// <param name="board"></param>
        public void Load(string board)
        {
            if (board == null) throw new ArgumentNullException(nameof(board));
            if (board.Length != 81) throw new ArgumentException(nameof(board));

            board = board.Replace(' ', '0');

            for (ushort y = 0; y < 9; y++)
            for (ushort x = 0; x < 9; x++)
            {
                int val = board[y * 9 + x] - '0';
                if(val < 0 || val > 9) throw new ArgumentException(nameof(board));
                _board[x, y] = (ushort)val;
            }
        }
    }
}
