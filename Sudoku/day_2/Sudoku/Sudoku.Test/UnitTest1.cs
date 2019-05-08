using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Test
{
    [TestClass]
    public class UnitTest1
    {
        private SudokuGame sudoku;
        [TestInitialize]
        public void Initialize()
        {
            sudoku = new SudokuGame();
        }

        [TestMethod]
        public void 한줄이_규칙에_맞는지검사한다()
        {
            int[,] given = new int[9, 9] { 
            { 1, 2, 3, 4, 5, 6, 7, 8, 9},
            { 1, 2, 3, 4, 5, 6, 7, 8, 9},
            { 1, 2, 3, 4, 5, 6, 7, 8, 9},
            { 1, 2, 3, 4, 5, 6, 7, 8, 9},
            { 1, 2, 3, 4, 5, 6, 7, 8, 9},
            { 1, 2, 3, 4, 5, 6, 7, 8, 9},
            { 1, 2, 3, 4, 5, 6, 7, 8, 9},
            { 1, 2, 3, 4, 5, 6, 7, 8, 9},
            { 1, 2, 3, 4, 5, 6, 7, 8, 9}};

            Assert.AreEqual(true, sudoku.ValidateColumn(given));
        }

        [TestMethod]
        public void 한행이_규칙에_맞는지검사한다()
        {
            int[,] given = new int[9, 9] {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 2, 2, 2, 2, 2, 2, 2, 2, 2},
            { 3, 3, 3, 3, 3, 3, 3, 3, 3},
            { 4, 4, 4, 4, 4, 4, 4, 4, 4},
            { 5, 5, 5, 5, 5, 5, 5, 5, 5},
            { 6, 6, 6, 6, 6, 6, 6, 6, 6},
            { 7, 7, 7, 7, 7, 7, 7, 7, 7},
            { 8, 8, 8, 8, 8, 8, 8, 8, 8},
            { 9, 9, 9, 9, 9, 9, 9, 9, 9}};

            Assert.AreEqual(true, sudoku.ValidateRow(given));
        }

        [TestMethod]
        public void 한행렬안에_규칙에_맞는지검사한다()
        {
            int[,] given = new int[9, 9] {
            { 1, 2, 3, 1, 2, 3, 1, 2, 3},
            { 4, 5, 6, 4, 5, 6, 4, 5, 6},
            { 7, 8, 9, 7, 8, 9, 7, 8, 9},
            { 1, 2, 3, 1, 2, 3, 1, 2, 3},
            { 4, 5, 6, 4, 5, 6, 4, 5, 6},
            { 7, 8, 9, 7, 8, 9, 7, 8, 9},
            { 1, 2, 3, 1, 2, 3, 1, 2, 3},
            { 4, 5, 6, 4, 5, 6, 4, 5, 6},
            { 7, 8, 9, 7, 8, 9, 7, 8, 9}};

            Assert.AreEqual(true, sudoku.ValidateSmallMatrix(given));
        }

        [TestMethod]
        public void 정답일경우의_validate()
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

            Assert.AreEqual(true, sudoku.Validate(given));
        }

        [TestMethod]
        public void 오답일경우의_validate()
        {
            int[,] given = new int[9, 9] {
                {5, 3, 4, 6, 7, 8, 9, 1, 2},
                {6, 7, 2, 1, 9, 0, 3, 4, 8},
                {1, 0, 0, 3, 4, 2, 5, 6, 0},
                {8, 5, 9, 7, 6, 1, 0, 2, 0},
                {4, 2, 6, 8, 5, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 0, 1, 5, 3, 7, 2, 1, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 0, 0, 4, 8, 1, 1, 7, 9} };

            Assert.AreEqual(false, sudoku.Validate(given));
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
            int[,] solvedResult = sudoku.Solve(quiz);
            Assert.AreEqual(true, sudoku.Validate(solvedResult));
        }

        [TestMethod]
        public void kata문제에나와있는걸풀어낼수있다()
        {
            int[,] quiz = new int[9, 9]
            {{5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},

            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},

            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}};
            int[,] solvedResult = sudoku.Solve(quiz);
            Assert.AreEqual(true, sudoku.Validate(solvedResult));
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
            int[,] solvedResult = sudoku.Solve(quiz);
            Assert.AreEqual(true, sudoku.Validate(solvedResult));
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
            int[,] solvedResult = sudoku.Solve(quiz);
            Assert.AreEqual(true, sudoku.Validate(solvedResult));
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
            int[,] solvedResult = sudoku.Solve(quiz);
            Assert.AreEqual(true, sudoku.Validate(solvedResult));
        }

        [TestMethod]
        public void 난이도2010_어려움_문제를_풀이할수있다()
        {
            int[,] quiz = new int[9, 9]
            {{0, 0, 5,  3, 0, 0,  0, 0, 0},
            {8, 0, 0,  0, 0, 0,  0, 2, 0},
            {0, 7, 0,  0, 1, 0,  5, 0, 0},

            {4, 0, 0,  0, 0, 5,  3, 0, 0},
            {0, 1, 0,  0, 7, 0,  0, 0, 6},
            {0, 0, 3,  2, 0, 0,  0, 8, 0},

            {0, 6, 0,  5, 0, 0,  0, 0, 9},
            {0, 0, 4,  0, 0, 0,  0, 3, 0},
            {0, 0, 0,  0, 0, 9,  7, 0, 0}};
            int[,] solvedResult = sudoku.Solve(quiz);
            Assert.AreEqual(true, sudoku.Validate(solvedResult));
        }

        [TestMethod]
        public void Array사용법()
        {
            ArrayList array = new ArrayList();
            array.Add(10);
            array.Add(15);
            array.Add(20);

            Assert.IsTrue(array.Contains(15));
        }

        //[TestMethod]
        //public void Array사용법2()
        //{
        //    Array array = new Array();
        //    array.Add(10);
        //    array.Add(15);
        //    array.Add(20);
        //    IEnumerator enumerator = array.GetEnumerator();
        //    for (enumerator.Current.)
        //        enumerator.Equals(10)

        //    Assert.IsTrue(array.Contains(15));
        //}
    }
}
