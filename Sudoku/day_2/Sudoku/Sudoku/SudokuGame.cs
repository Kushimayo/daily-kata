using System;

namespace Sudoku
{
    public class SudokuGame
    {
        private int[] remainNumber;
        public SudokuGame()
        {
        }

        public bool ValidateColumn(int[,] sudokuResult)
        {
            bool result = true;
            for (int i = 0; i < 9; i++)
            {
                int[] temp = new int[9] {
                    sudokuResult[i, 0],
                    sudokuResult[i, 1],
                    sudokuResult[i, 2],
                    sudokuResult[i, 3],
                    sudokuResult[i, 4],
                    sudokuResult[i, 5],
                    sudokuResult[i, 6],
                    sudokuResult[i, 7],
                    sudokuResult[i, 8]};
                if (!ValidateCore(temp))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private bool ValidateCore(int[] arrys)
        {
            bool result = true;
            bool[] temp = new bool[9] { false, false, false, false, false, false, false, false, false};
            for (int i = 0; i < arrys.Length; i++)
            {
                if (arrys[i] <= 0 || arrys[i] > 9 || temp[arrys[i] - 1])
                {
                    result = false;
                    break;
                }
                temp[arrys[i] - 1] = true;
            }

            return result;
        }

        public bool ValidateRow(int[,] sudokuResult)
        {
            bool result = true;
            for (int i = 0; i < 9; i++)
            {
                int[] temp = new int[9] {
                    sudokuResult[0, i],
                    sudokuResult[1, i],
                    sudokuResult[2, i],
                    sudokuResult[3, i],
                    sudokuResult[4, i],
                    sudokuResult[5, i],
                    sudokuResult[6, i],
                    sudokuResult[7, i],
                    sudokuResult[8, i]};
                if (!ValidateCore(temp))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public bool ValidateSmallMatrix(int[,] sudokuResult)
        {
            bool result = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int tempRow = i * 3;
                    int tempColumn = j * 3;
                    int[] temp = new int[9] {
                    sudokuResult[tempRow, tempColumn],
                    sudokuResult[tempRow, tempColumn + 1],
                    sudokuResult[tempRow, tempColumn + 2],
                    sudokuResult[tempRow + 1, tempColumn],
                    sudokuResult[tempRow + 1, tempColumn + 1],
                    sudokuResult[tempRow + 1, tempColumn + 2],
                    sudokuResult[tempRow + 2, tempColumn],
                    sudokuResult[tempRow + 2, tempColumn + 1],
                    sudokuResult[tempRow + 2, tempColumn + 2] };
                    if (!ValidateCore(temp))
                    {
                        result = false;
                        break;
                    }
                }
                if (!result)
                    break;
            }
            return result;
        }

        public bool Validate(int[,] sudokuResult)
        {
            if (ValidateColumn(sudokuResult) &&
                ValidateRow(sudokuResult) &&
                ValidateSmallMatrix(sudokuResult))
                return true;

            return false;
        }

        public int[,] Solve(int[,] quiz)
        {
            int[,] result = quiz;
            int i = 0;
            remainNumber = InitialRemain(result);
            while (true)
            {
                i++;
                int[,] preResult = (int[,])result.Clone();
                result = InsertPossibleNumber(result);
                if (IsNotChange(preResult, result))
                    break;
            }
            
            return result;
        }

        private bool IsNotChange(int[,] preMatrix, int[,] postMatrix)
        {
            bool result = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (preMatrix[i, j] != postMatrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return result;
        }

        private int[] GetSmallMatrixArray(int[,] quiz, int row, int column)
        {
            return new int[9] {
                    quiz[row, column],
                    quiz[row, column + 1],
                    quiz[row, column + 2],
                    quiz[row + 1, column],
                    quiz[row + 1, column + 1],
                    quiz[row + 1, column + 2],
                    quiz[row + 2, column],
                    quiz[row + 2, column + 1],
                    quiz[row + 2, column + 2] };
        }

        private int[,] InsertPossibleNumber(int[,] quiz)
        {
            int[,] result = quiz;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int tempRow = i * 3;
                    int tempColumn = j * 3;
                    for (int x = 0; x < 9; x++)
                    {
                        if (remainNumber[x] == 0)
                            continue;
                        bool[,] canInsert = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };
                        for (int y = 0; y < 3; y++)
                        {
                            for (int z = 0; z < 3; z++)
                            {
                                if (result[tempRow + y, tempColumn + z] == 0)
                                {
                                    if (canInsertNumber(result, tempRow, tempColumn, y, z, x + 1))
                                    {
                                        canInsert[y, z] = true;
                                    }
                                }
                            }
                        }

                        if (IsOnlyOneSpotInsert(canInsert))
                        {
                            for (int a = 0; a < 3; a++)
                            {
                                for (int b = 0; b < 3; b++)
                                {
                                    if (canInsert[a, b])
                                    {
                                        result[tempRow + a, tempColumn + b] = x + 1;
                                        remainNumber[x]--;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        private bool IsOnlyOneSpotInsert(bool[,] possibleMatrix)
        {
            bool result = false;
            int matchCount = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (possibleMatrix[i, j])
                        matchCount++;
                }
            }
            if (matchCount == 1)
                result = true;

            return result;
        }

        private int[] InitialRemain(int[,] quiz)
        {
            int[] remain = new int[9] { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (quiz[i, j] != 0)
                    {
                        remain[quiz[i, j] - 1]--;
                    }
                }
            }

            return remain;
        }

        private bool canInsertNumber(int[,] quiz, int row, int column, int rowOffset, int columnOffset, int number)
        {
            bool result = true;
            int[] smallMetrix = GetSmallMatrixArray(quiz, row, column);
            for (int i = 0; i < 9; i++)
            {
                if (quiz[row + rowOffset, i] == number || quiz[i, column + columnOffset] == number || smallMetrix[i] == number)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}