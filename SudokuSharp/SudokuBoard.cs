using System;
using System.Text;

namespace SudokuSharp
{
    public class SudokuBoard
    {
        // 0 indicates not filled in
        public ushort[,] _board = new ushort[9, 9];

        public ushort Cell(int x, int y)
        {
            if (x < 0 || x > 8) throw new ArgumentOutOfRangeException(nameof(x));
            if (y < 0 || y > 8) throw new ArgumentOutOfRangeException(nameof(y));
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

        public bool Valid()
        {
            for (int i = 0; i < 9; i++)
            {
                if (!RowValid(i)) return false;
                if (!ColumnValid(i)) return false;
            }
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (!BoxValid(x, y)) return false;
                }
            }
            return true;
        }

        public bool RowValid(int y)
        {
            if (y < 0 || y > 8) throw new ArgumentOutOfRangeException(nameof(y));
            for (int x1 = 0; x1 < 8; x1++)
            {
                for (int x2 = x1 + 1; x2 < 9; x2++)
                {
                    var cell = Cell(x1, y);
                    if (cell != 0 && cell == Cell(x2, y))
                        return false;
                }
            }
            return true;
        }

        public bool ColumnValid(int x)
        {
            if (x < 0 || x > 8) throw new ArgumentOutOfRangeException(nameof(x));
            for (int y1 = 0; y1 < 8; y1++)
            {
                for (int y2 = y1 + 1; y2 < 9; y2++)
                {
                    var cell = Cell(x, y1);
                    if (cell != 0 && cell == Cell(x, y2))
                        return false;
                }
            }
            return true;
        }

        public bool BoxValid(int x, int y)
        {
            if (x < 0 || x > 8) throw new ArgumentOutOfRangeException(nameof(x));
            if (y < 0 || y > 8) throw new ArgumentOutOfRangeException(nameof(y));

            for (int i1 = 0; i1 < 8; i1++)
            {
                int x1 = i1 % 3 + x * 3;
                int y1 = i1 / 3 + y * 3;
                var cell = Cell(x1, y1);
                if (cell == 0)
                    continue;

                for (int i2 = i1 + 1; i2 < 9; i2++)
                {
                    int x2 = i2 % 3 + x * 3;
                    int y2 = i2 / 3 + y * 3;
                    if (cell == Cell(x2, y2))
                        return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(".---.---.---.");
            for (int y = 0; y < 9; y++)
            {
                sb.Append('|');
                for (int x = 0; x < 9; x++)
                {
                    var c = Cell(x, y);
                    sb.Append(c == 0 ? " " : c.ToString());
                    if ((x + 1) % 3 == 0)
                        sb.Append('|');
                }
                sb.AppendLine();
                if((y + 1) % 3 == 0)
                    sb.AppendLine(".---.---.---.");
            }
            return sb.ToString();
        }
    }
}
