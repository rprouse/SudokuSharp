using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SudokuSharp.Test.Data;

namespace SudokuSharp.Test
{
    [TestFixture]
    public class ValidateSudokuBoard
    {
        SudokuBoard _board;

        [SetUp]
        public void SetUp()
        {
            _board = new SudokuBoard();
        }

        [Test]
        public void RecognizeValidRow()
        {
            _board.Load(ValidBoards.Boards[0]);
            for (int i = 0; i < 9; i++)
                Assert.That(_board.RowValid(i), Is.True);
        }

        [Test]
        public void RecognizeValidColumn()
        {
            _board.Load(ValidBoards.Boards[0]);
            for (int i = 0; i < 9; i++)
                Assert.That(_board.ColumnValid(i), Is.True);
        }

        [Test]
        public void RecognizeValidBox()
        {
            _board.Load(ValidBoards.Boards[0]);
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    Assert.That(_board.BoxValid(x, y), Is.True, $"Box {x},{y} is invalid for board\r\n\r\n{ValidBoards.Boards[0]}");
        }

        [Test]
        public void RecognizeInvalidRow()
        {
            _board.Load(InvalidBoards.Boards[1]);
            Assert.That(_board.RowValid(5), Is.False);
        }

        [Test]
        public void RecognizeInvalidColumn()
        {
            _board.Load(InvalidBoards.Boards[0]);
            Assert.That(_board.ColumnValid(4), Is.False);
        }

        [TestCaseSource(nameof(InvalidBoxData))]
        public void RecognizeInvalidBox(string board, int x, int y)
        {
            _board.Load(board);
            Assert.That(_board.BoxValid(x, y), Is.False, $"Box {x},{y} is valid for board\r\n\r\n{_board}");
        }

        [TestCaseSource(nameof(ValidBoardData))]
        public void RecognizesValidBoards(string board)
        {
            _board.Load(board);
            Assert.That(_board.Valid(), Is.True);
        }

        [TestCaseSource(nameof(InvalidBoardData))]
        public void RecognizesInvalidBoards(string board)
        {
            _board.Load(board);
            Assert.That(_board.Valid(), Is.False);
        }

        public static IEnumerable InvalidBoxData()
        {
            yield return new TestCaseData(InvalidBoards.Boards[2], 1, 0);
            yield return new TestCaseData(InvalidBoards.Boards[3], 1, 1);
            yield return new TestCaseData(InvalidBoards.Boards[4], 2, 1);
        }

        public static IEnumerable<string> ValidBoardData()
        {
            return ValidBoards.Boards;
        }

        public static IEnumerable<string> InvalidBoardData()
        {
            return InvalidBoards.Boards;
        }
    }
}
