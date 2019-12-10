using System;

namespace RegionsCut
{
    public class Regions
    {
        public Regions()
        {
        }

        public int RegionsBySlashes(string[] grid)
        {
            if (grid.Length < 0 || grid[0].Length > 30)
                return 0;
 
            int[][] gridArray = CreateIntGridArray(grid);
            int RegionsSize = 0;

            for (int arrayRow = 1; arrayRow < gridArray.Length; arrayRow+=3)
            {
                //if (arrayRow % 3 != 1)
                //    continue;
                for (int arrayCol = 0; arrayCol < gridArray[arrayRow].Length; arrayCol++)
                {
                    RegionsSize += isRegions(gridArray, arrayRow, arrayCol);
                }
            }

            return RegionsSize;
        }

        private int[][] createArrayWithSize(int size)
        {
            int[][] gridArray = new int[size][];

            for (int i = 0; i < size; i++)
            {
                gridArray[i] = new int[size];
                for (int j = 0; j < size; j++)
                    gridArray[i][j] = 1;
            }

            return gridArray;
        }

        private int[][] CreateIntGridArray(string[] grid)
        {
            int size = grid.Length * 3;
            int[][] gridArray = createArrayWithSize(size);

            for (int i = 0; i < grid.Length; i++)
            {
                string slashStrings = grid[i];
                for (int j = 0; j < slashStrings.Length; j++)
                {
                    int tempRow = i * 3;
                    int tempCol = j * 3;
                    
                    if (slashStrings[j] == '\\')
                    {
                        gridArray[tempRow][tempCol] = 0;
                        gridArray[tempRow + 1][tempCol + 1] = 0;
                        gridArray[tempRow + 2][tempCol + 2] = 0;
                    }
                    else if (slashStrings[j] == '/')
                    {
                        gridArray[tempRow][tempCol + 2] = 0;
                        gridArray[tempRow + 1][tempCol + 1] = 0;
                        gridArray[tempRow + 2][tempCol] = 0;
                    }
                }
            }

            return gridArray;
        }

        private int isRegions(int[][] gridArray, int row, int col)
        {
            if (row < 0 || row >= gridArray.Length || col < 0 || col >= gridArray[0].Length)
                return 0;

            if (gridArray[row][col] == 1)
            {
                gridArray[row][col] = 0;
                isRegions(gridArray, row, col + 1);
                isRegions(gridArray, row, col - 1);
                isRegions(gridArray, row - 1, col);
                isRegions(gridArray, row + 1, col);
                return 1;
            }
            return 0;
        }
    }
}