using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxAreaOfIsland.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 인스턴스생성할수있다()
        {
            Island island = new Island();
        }

        [TestMethod]
        public void 땅이없으면0을리턴한다()
        {
            var island = new Island();
            int[][] grid = new int[1][];
            grid[0] = new int[] { 0, 0, 0, 0 };
            Assert.AreEqual(0, island.MaxAreaOfIsland(grid));
        }

        [TestMethod]
        public void 예제()
        {
            var island = new Island();
            int[][] grid = new int[8][];
            grid[0] = new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
            grid[1] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
            grid[2] = new int[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            grid[3] = new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 };
            grid[4] = new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 };
            grid[5] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
            grid[6] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
            grid[7] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 };
            Assert.AreEqual(6, island.MaxAreaOfIsland(grid));
        }
    }
}
