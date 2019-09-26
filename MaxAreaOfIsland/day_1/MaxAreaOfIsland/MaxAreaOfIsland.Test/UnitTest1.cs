using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxAreaOfIsland.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void �ν��Ͻ���_������ִ�()
        {
            Island island = new Island();
        }

        [TestMethod]
        public void ���̾�����0�����Ѵ�()
        {
            var island = new Island();
            int[][] grid = new int[1][];
            grid[0] = new int[]{ 0, 0, 0, 0, 0, 0 };
            Assert.AreEqual(0, island.MaxAreaOfIsland(grid));
        }

        [TestMethod]
        public void ����1����1�����Ѵ�()
        {
            var island = new Island();
            int[][] grid = new int[1][];
            grid[0] = new int[] { 0, 0, 0, 0, 0, 1 };
            Assert.AreEqual(1, island.MaxAreaOfIsland(grid));
        }

        [TestMethod]
        public void ���μ�2����2�����Ѵ�()
        {
            var island = new Island();
            int[][] grid = new int[2][];
            grid[0] = new int[] { 1 };
            grid[1] = new int[] { 1 };
            Assert.AreEqual(2, island.MaxAreaOfIsland(grid));
        }

        [TestMethod]
        public void ��������()
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
