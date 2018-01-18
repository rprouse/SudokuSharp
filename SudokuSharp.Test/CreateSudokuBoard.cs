using NUnit.Framework;

namespace SudokuSharp.Test
{
    [TestFixture]
    public class CreateSudokuBoard
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
            for (ushort x = 0; x < 9; x++)
            for (ushort y = 0; y < 9; y++)
            {
                Assert.That(_board.Cell(x, y), Is.EqualTo(0));
            }
        }
    }
}
