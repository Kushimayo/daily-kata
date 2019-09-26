using System;

namespace MaxAreaOfIsland
{
    public class Island
    {
        public Island()
        {
        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            int maxArea = 0;
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    int tempAreaSize = GetAreaSize(grid, row, col);
                    if (tempAreaSize > maxArea)
                        maxArea = tempAreaSize;
                }
            }
            return maxArea;
        }

        private int GetAreaSize(int[][] grid, int row, int col)
        {
            int areaSize = 0;
            if (grid[row][col] == 1)
            {
                grid[row][col] = 0;
                areaSize++;
                if (row - 1 >= 0 && col < grid[row - 1].Length)
                    areaSize += GetAreaSize(grid, row - 1, col);
                if (row + 1 < grid.Length && col < grid[row + 1].Length)
                    areaSize += GetAreaSize(grid, row + 1, col);
                if (col - 1 >= 0)
                    areaSize += GetAreaSize(grid, row, col - 1);
                if (col + 1 < grid[row].Length)
                    areaSize += GetAreaSize(grid, row, col + 1);
            }

            return areaSize;
        }
    }
}