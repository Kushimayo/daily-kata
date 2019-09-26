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
            bool[][] check = GetAreaBeenChecker(grid);
            int maxArea = 0;
            int tempArea = 0;
            int rowLength = grid.Length;
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    tempArea = GetMaxArea(row, col, grid, check);
                    if (tempArea >= maxArea)
                        maxArea = tempArea;
                }
            }

            return maxArea;
        }

        private bool[][] GetAreaBeenChecker(int[][] grid)
        {
            int rowLength = grid.Length;
            bool[][] check = new bool[rowLength][];

            for (int row = 0; row < rowLength; row++)
            {
                int length = grid[row].Length;
                check[row] = new bool[length];
                for (int col = 0; col < length; col++)
                {
                    check[row][col] = false;
                }
            }

            return check;
        }

        private int GetMaxArea(int row, int col, int[][] grid, bool[][] checker)
        {
            int maxArea = 0;
            if (grid[row][col] == 1 && checker[row][col] == false)
            {
                maxArea++;
                checker[row][col] = true;               
                if (row - 1 >= 0 && col < grid[row -1].Length)
                {
                    maxArea += GetMaxArea(row - 1, col, grid, checker);
                }
                if (row + 1 < grid.Length && col < grid[row + 1].Length)
                {
                    maxArea += GetMaxArea(row + 1, col, grid, checker);
                }
                if (col - 1 >= 0)
                {
                    maxArea += GetMaxArea(row, col - 1, grid, checker);
                }
                if (col + 1 < grid[row].Length)
                {
                    maxArea += GetMaxArea(row, col + 1, grid, checker);
                }
                
            }

            return maxArea;
        }
    }
}