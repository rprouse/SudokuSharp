using System;
using NUnit.Framework;

namespace SudokuSharp.Test
{
    [TestFixture]
    public class SudokuBoardTest
    {
        SudokuBoard _board;

        [SetUp]
        public void SetUp()
        {
            _board = new SudokuBoard();
        }

        [Test]
        public void CanCreate()
        {
            Assert.That(_board, Is.Not.Null);
        }

        [Test]
        public void BoardIsInitializedToUnset()
        {
            for (ushort row = 0; row < 9; row++)
            for (ushort column = 0; column < 9; column++)
            {
                Assert.That(_board.Cell(row, column), Is.EqualTo(0));
            }
        }
    }
}
