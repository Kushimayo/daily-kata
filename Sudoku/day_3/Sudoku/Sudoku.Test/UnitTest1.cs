using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Test
{
    [TestClass]
    public class UnitTest1
    {
        private SudokuGame game;
        [TestInitialize]
        public void Initialize()
        {
            game = new SudokuGame();
        }

        //[TestMethod]
        //public void 인스턴스를_생성할수있다()
        //{
        //    SudokuGame game = new SudokuGame();
        //}

        [TestMethod]
        public void 배열의정보를_dictionary로변경할수있다()
        {
            int[,] given = new int[9, 9] {
                { 5, 3, 4, 6, 7, 8, 9, 1, 2},
                { 6, 7, 2, 1, 9, 5, 3, 4, 8},
                { 1, 9, 8, 3, 4, 2, 5, 6, 7},
                { 8, 5, 9, 7, 6, 1, 4, 2, 3},
                { 4, 2, 6, 8, 5, 3, 7, 9, 1},
                { 7, 1, 3, 9, 2, 4, 8, 5, 6},
                { 9, 6, 1, 5, 3, 7, 2, 8, 4},
                { 2, 8, 7, 4, 1, 9, 6, 3, 5},
                { 3, 4, 5, 2, 8, 6, 1, 7, 9}};
            Dictionary<String, String> actualResult = game.ConvertToDicionary(given);

            Assert.AreEqual("5", actualResult["A1"]);
            Assert.AreEqual("9", actualResult["I9"]);
            Assert.AreEqual("5", actualResult["E5"]);
        }

        [TestMethod]
        public void 배열의정보를_string_array로변경할수있다()
        {
            int[,] given = new int[9, 9] {
                { 5, 3, 4, 6, 7, 8, 9, 1, 2},
                { 6, 7, 2, 1, 9, 5, 3, 4, 8},
                { 1, 9, 8, 3, 4, 2, 5, 6, 7},
                { 8, 5, 9, 7, 6, 1, 4, 2, 3},
                { 4, 2, 6, 8, 5, 3, 7, 9, 1},
                { 7, 1, 3, 9, 2, 4, 8, 5, 6},
                { 9, 6, 1, 5, 3, 7, 2, 8, 4},
                { 2, 8, 7, 4, 1, 9, 6, 3, 5},
                { 3, 4, 5, 2, 8, 6, 1, 7, 9}};
            string[,] actualResult = game.ConvertToString(given);

            Assert.AreEqual("5", actualResult[0,0]);
            Assert.AreEqual("9", actualResult[8,8]);
            Assert.AreEqual("5", actualResult[4,4]);
            Assert.AreEqual("3", actualResult[0, 1]);

            Display(actualResult);

        }

        [TestMethod]
        public void 별1개난이도문제를_풀이할수있다()
        {
            int[,] quiz = new int[9, 9]
            {{9, 4, 1,  0, 0, 2,  0, 0, 0},
            {0, 0, 0,  0, 0, 0,  0, 5, 0},
            {0, 0, 0,  7, 0, 0,  1, 3, 0},

            {8, 0, 0,  0, 0, 3,  0, 6, 0},
            {3, 6, 2,  1, 0, 7,  5, 9, 4},
            {0, 9, 0,  5, 0, 0,  0, 0, 8},

            {0, 5, 7,  0, 0, 1,  0, 0, 0},
            {0, 3, 0,  0, 0, 0,  0, 0, 0},
            {0, 0, 0,  2, 0, 0,  6, 7, 1}};
            string[,] solvedResult = game.Solve(quiz);
            Display(solvedResult);

        }

        [TestMethod]
        public void 별2개난이도문제를_풀이할수있다()
        {
            int[,] quiz = new int[9, 9]
            {{4, 3, 5,  0, 6, 1,  0, 7, 0},
            {7, 6, 0,  0, 0, 0,  3, 0, 0},
            {0, 0, 0,  0, 0, 0,  0, 4, 0},

            {0, 0, 0,  8, 0, 0,  0, 0, 3},
            {3, 0, 0,  5, 7, 9,  0, 0, 4},
            {8, 0, 0,  0, 0, 4,  0, 0, 0},

            {0, 8, 0,  0, 0, 0,  0, 0, 0},
            {0, 0, 1,  0, 0, 0,  0, 9, 7},
            {0, 9, 0,  7, 4, 0,  5, 6, 1}};
            string[,] solvedResult = game.Solve(quiz);
            Display(solvedResult);
        }

        [TestMethod]
        public void 별3개난이도문제를_풀이할수있다()
        {
            int[,] quiz = new int[9, 9]
            {{7, 0, 0,  0, 0, 9,  3, 4, 8},
            {0, 0, 0,  0, 4, 0,  0, 1, 0},
            {0, 0, 0,  5, 0, 0,  0, 0, 0},

            {9, 1, 0,  4, 0, 0,  0, 7, 0},
            {6, 0, 0,  9, 0, 3,  0, 0, 1},
            {0, 3, 0,  0, 0, 1,  0, 2, 9},

            {0, 0, 0,  0, 0, 5,  0, 0, 0},
            {0, 8, 0,  0, 1, 0,  0, 0, 0},
            {4, 9, 3,  8, 0, 0,  0, 0, 2}};
            string[,] solvedResult = game.Solve(quiz);
            Display(solvedResult);
        }

        [TestMethod]
        public void 별5개난이도문제를_풀이할수있다()
        {
            int[,] quiz = new int[9, 9]
            {{0, 0, 3,  9, 0, 2,  0, 5, 0},
            {0, 0, 0,  0, 6, 0,  3, 0, 0},
            {0, 0, 0,  3, 0, 0,  0, 0, 4},

            {0, 6, 7,  0, 0, 0,  5, 9, 0},
            {5, 0, 4,  0, 9, 0,  1, 0, 3},
            {0, 8, 9,  0, 0, 0,  7, 4, 0},

            {4, 0, 0,  0, 0, 7,  0, 0, 0},
            {0, 0, 5,  0, 2, 0,  0, 0, 0},
            {0, 3, 0,  6, 0, 1,  4, 0, 0}};
            string[,] solvedResult = game.Solve(quiz);
            Display(solvedResult);
        }

        private void Display(string[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Debug.Write(" "  + sudoku[i, j] + " ");
                    if (j == 2 || j == 5)
                        Debug.Write("  |  ");
                }
                Debug.Write("\n");
                if (i == 2 || i == 5)
                {
                    Debug.WriteLine("-----------------------------------");
                }
            }
        }

        //[TestMethod]
        //public void 한칸에대한_이웃의정보를가져올수있다()
        //{
        //    SudokuGame game = new SudokuGame();
        //    int[,] quiz = new int[9, 9] {
        //        { 5, 3, 4, 6, 7, 8, 9, 1, 2},
        //        { 6, 7, 2, 1, 9, 5, 3, 4, 8},
        //        { 1, 9, 8, 3, 4, 2, 5, 6, 7},
        //        { 8, 5, 9, 7, 6, 1, 4, 2, 3},
        //        { 4, 2, 6, 8, 5, 3, 7, 9, 1},
        //        { 7, 1, 3, 9, 2, 4, 8, 5, 6},
        //        { 9, 6, 1, 5, 3, 7, 2, 8, 4},
        //        { 2, 8, 7, 4, 1, 9, 6, 3, 5},
        //        { 3, 4, 5, 2, 8, 6, 1, 7, 9}};
        //    Dictionary<String, String> given = game.ConvertToDicionary(quiz);
        //    Dictionary<String, String> actualResult = game.GetPeer(given, "A2");
        //    Assert.AreEqual(20, actualResult.Count)
        //}
    }
}
