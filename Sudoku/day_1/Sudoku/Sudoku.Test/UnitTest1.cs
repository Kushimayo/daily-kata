using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 정답확인_인스턴스를_생성할수있다()
        {
            Validator validator = new Validator();
        }

        [TestMethod]
        public void 한column에는다른숫자가들어간다()
        {
            Validator validator = new Validator();
            int[,] matrix = new int[9, 9] { {1, 2, 3, 4, 5, 6, 7, 8, 9 },
                                            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                            {0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                            {0, 0, 0, 0, 0, 0, 0, 0, 0 }};
            
        }
    }
}
