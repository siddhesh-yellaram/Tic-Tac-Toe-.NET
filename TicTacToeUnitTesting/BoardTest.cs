using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TicTacToeLib;

namespace TicTacToeUnitTesting
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void TestForMarkOOnBoardAtIndex0()
        {
            Mark expectedMark = Mark.O;

            Board board = new Board(3);
            board.SetMarkOnCell(0, Mark.O);

            Mark actualMark = board.GetCells().ElementAt(0).GetMark();

            Assert.AreEqual(expectedMark, actualMark);
        }

        [TestMethod]
        public void TestForMarkXOnBoardAtIndex8()
        {
            Mark expectedMark = Mark.X;

            Board board = new Board(3);
            board.SetMarkOnCell(8, Mark.X);

            Mark actualMark = board.GetCells().ElementAt(8).GetMark();

            Assert.AreEqual(expectedMark, actualMark);
        }

        [TestMethod]
        public void TestForMarkXOnBoardAtIndex4()
        {
            Mark expectedMark = Mark.X;

            Board board = new Board(3);
            board.SetMarkOnCell(4, Mark.X);

            Mark actualMark = board.GetCells().ElementAt(4).GetMark();

            Assert.AreEqual(expectedMark, actualMark);
        }

        [TestMethod]
        public void TestForMarkOOnBoardAtIndex6()
        {
            Mark expectedMark = Mark.O;

            Board board = new Board(3);
            board.SetMarkOnCell(6, Mark.O);

            Mark actualMark = board.GetCells().ElementAt(6).GetMark();

            Assert.AreEqual(expectedMark, actualMark);
        }

        [TestMethod]
        public void TestIsBoardNotFullyMarked()
        {
            bool expectedIsBoardFull = false;

            Board board = new Board(3);
            bool actualIsBoardFull = board.IsBoardFullyMarked();

            Assert.AreEqual(expectedIsBoardFull, actualIsBoardFull);
        }


        [TestMethod]
        public void TestIsBoardFullyMarked()
        {
            bool expectedIsBoardFull = true;

            Board board = new Board(3);
            for (int i = 0; i < 3 * 3; i++)
            {
                if (i % 2 == 0)
                {
                    board.SetMarkOnCell(i, Mark.O);
                    continue;
                }
                board.SetMarkOnCell(i, Mark.X);
            }

            bool actualIsBoardFull = board.IsBoardFullyMarked();

            Assert.AreEqual(expectedIsBoardFull, actualIsBoardFull);
        }
    }
}
