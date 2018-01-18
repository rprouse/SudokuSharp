using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SudokuSharp.Test.Data;

namespace SudokuSharp.Test
{
    [TestFixture]
    public class LoadSudokuBoard
    {
        SudokuBoard _board;

        [SetUp]
        public void SetUp()
        {
            _board = new SudokuBoard();
        }

        [Test]
        public void LoadsBoardWithZeroAsUnset()
        {
            _board.Load(ValidBoards.Boards[0]);
            Assert.That(_board.Cell(0, 0), Is.EqualTo(0));
            Assert.That(_board.Cell(8, 8), Is.EqualTo(0));
            Assert.That(_board.Cell(6, 3), Is.EqualTo(0));
            Assert.That(_board.Cell(7, 8), Is.EqualTo(5));
            Assert.That(_board.Cell(5, 2), Is.EqualTo(7));
        }

        [Test]
        public void LoadsBoardWithSpaceAsUnset()
        {
            _board.Load(ValidBoards.Boards[0].Replace('0', ' '));
            Assert.That(_board.Cell(0, 0), Is.EqualTo(0));
            Assert.That(_board.Cell(8, 8), Is.EqualTo(0));
            Assert.That(_board.Cell(6, 3), Is.EqualTo(0));
            Assert.That(_board.Cell(7, 8), Is.EqualTo(5));
            Assert.That(_board.Cell(5, 2), Is.EqualTo(7));
        }

        [Test]
        public void NullBoardThrows()
        {
            Assert.That(() => _board.Load(null), Throws.ArgumentNullException);
        }

        [TestCaseSource(nameof(MalformedData))]
        public void MalformedBoardsThrow(string board)
        {
            Assert.That(() => _board.Load(board), Throws.ArgumentException);
        }

        public static IEnumerable<string> MalformedData()
        {
            for (int i = 0; i < MalformedBoards.Boards.Length; i++)
            {
                yield return MalformedBoards.Boards[i];
            }
        }
    }
}
