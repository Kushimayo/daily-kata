using System;
using System.Collections;

namespace Sudoku
{
    public class SudokuGame
    {
        private int[] remainNumber;
        private ArrayList rollbackQuiz = new ArrayList();
        private ArrayList rollbackRemain = new ArrayList();
        private ArrayList possibleInsertIndex = new ArrayList();
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
        private int[,] RollbackQuiz()
        {
            int index = 1;
            int[,] result = new int[9,9] ;
            foreach (int[,] item in rollbackQuiz)
            {
                if (index == rollbackQuiz.Count)
                {
                    result = (int[,])item.Clone();
                }
                index++;
            }

            return result;
        }

        private int[] RollbackRemain()
        {
            int index = 1;
            int[] result = new int[9];
            foreach (int[] remain in rollbackRemain)
            {
                if (index == rollbackRemain.Count)
                {
                    result = (int[])remain.Clone();
                }
                index++;
            }
            return result;
        }

        public int[,] Solve(int[,] quiz)
        {
            int[,] result = quiz;
            int i = 0;
            remainNumber = InitialRemain(result);
            while (true)
            {
                i++;
                bool isError = false;
                int[,] preResult = (int[,])result.Clone();
                result = SolveThreeWay(result, ref isError);

                if (isError)
                {
                    result = RollbackQuiz();
                    remainNumber = RollbackRemain();
                    result = InsertPossibleNumberV2(result);
                }
                else
                {
                    if (IsNotChange(preResult, result))
                    {
                        if (IsCompleteQuiz())
                            break;
                        // 여기서 뎁스 내려가면서 숫자 넣어줌
                        rollbackQuiz.Add(preResult);
                        rollbackRemain.Add(remainNumber.Clone());
                        possibleInsertIndex.Add(0);
                        result = InsertPossibleNumberV2(result);
                    }
                }
            }
            
            return result;
        }

        private int[,] SolveThreeWay(int[,] quiz, ref bool isError)
        {
            int[,] result = quiz;
            result = InsertSolvedNumberWithSmallMatrix(result, ref isError);
            if (isError == true)
                return result;
            result = InsertSolvedNumberWithRow(result, ref isError);
            if (isError == true)
                return result;
            result = InsertSolvedNumberWithColumn(result, ref isError);
            if (isError == true)
                return result;

            return result;
        }

        private bool IsCompleteQuiz()
        {
            for (int i = 0; i < 9; i++)
            {
                if (remainNumber[i] > 0)
                    return false;
            }

            return true;
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

        private int[,] InsertPossibleNumberV2(int[,] quiz)
        {
            int[,] result = quiz;
            int possibleRow = 0;
            bool[] possibleColumn = new bool[9];
            int possibleNumber = 0;
            int minCount = 10;
            bool serchFlag = true;
            for (int i = 0; i < 9; i++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (remainNumber[x] == 0 || IsNumberAlreadyExistWithRow(result, i, x + 1))
                        continue;
                    bool[] canInsert = new bool[9] { false, false, false, false, false, false, false, false, false };
                    int canInsertCount = 0;
                    for (int j = 0; j < 9; j++)
                    {
                        canInsert[j] = IsCanInsert(result, i, j, x + 1);
                        if (canInsert[j])
                            canInsertCount++;
                    }
                    if (minCount > canInsertCount)
                    {
                        minCount = canInsertCount;
                        possibleRow = i;
                        possibleColumn = (bool[])canInsert.Clone();
                        possibleNumber = x;
                    }
                    if (minCount <= 2)
                    {
                        serchFlag = false;
                        break;
                    }
                }

                if (!serchFlag)
                    break;
            }
            for (int a = 0; a < 9; a++)
            {
                if (possibleColumn[a])
                {
                    if (IsTriedNumber(possibleRow, a, possibleNumber))
                        continue;
                    result[possibleRow, a] = possibleNumber + 1;
                    remainNumber[possibleNumber]--;
                    int value = (possibleRow * 100) + (a * 10) + possibleNumber + 1;
                    possibleInsertIndex.Add(value);
                    return result;
                }
            }
            if (CanInsertButAllTriedNumber(possibleColumn))
            {
                rollbackQuiz.RemoveAt(rollbackQuiz.Count - 1);
                rollbackRemain.RemoveAt(rollbackRemain.Count - 1);
                result = RollbackQuiz();
                remainNumber = RollbackRemain();
                RemoveUselessPossibleInsert();

                return result;
            }
            return result;
        }

        private int[,] InsertPossibleNumber(int[,] quiz)
        {
            int[,] result = quiz;
            for (int i = 0; i < 9; i++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (remainNumber[x] == 0 || IsNumberAlreadyExistWithRow(result, i, x + 1))
                        continue;
                    bool[] canInsert = new bool[9] { false, false, false, false, false, false, false, false, false };
                    for (int j = 0; j < 9; j++)
                    {
                        canInsert[j] = IsCanInsert(result, i, j, x + 1);
                    }

                    for (int a = 0; a < 9; a++)
                    {
                        if (canInsert[a])
                        {
                            if (IsTriedNumber(i, a, x))
                                continue;
                            result[i, a] = x + 1;
                            remainNumber[x]--;
                            int value = (i * 100) + (a * 10) + x + 1;
                            possibleInsertIndex.Add(value);
                            return result;
                        }
                    }
                    if (CanInsertButAllTriedNumber(canInsert))
                    {
                        rollbackQuiz.RemoveAt(rollbackQuiz.Count - 1);
                        rollbackRemain.RemoveAt(rollbackRemain.Count - 1);
                        result = RollbackQuiz();
                        remainNumber = RollbackRemain();
                        RemoveUselessPossibleInsert();

                        return result;
                    }
                }
            }
            return result;
        }

        private void RemoveUselessPossibleInsert()
        {
            int lastIndex = possibleInsertIndex.LastIndexOf(0);
            possibleInsertIndex.RemoveRange(lastIndex, possibleInsertIndex.Count - lastIndex);
        }

        private bool CanInsertButAllTriedNumber(bool[] canInsert)
        {
            for (int i = 0; i < 9; i++)
            {
                if (canInsert[i])
                    return true;
            }
            return false;
        }

        private bool IsTriedNumber(int row, int column, int value)
        {
            int number = (100 * row) + (10 * column) + value + 1;
            return possibleInsertIndex.Contains(number);
        }

        private bool IsCanInsert(int[,] quiz, int baseRow, int baseCol, int number)
        {
            if (quiz[baseRow, baseCol] == 0)
            {
                int tempRow = (baseRow / 3) * 3;
                int tempColumn = (baseCol / 3) * 3;
                int tempRowOffset = baseRow % 3;
                int tempColumnOffset = baseCol % 3;
                if (canInsertNumber(quiz, tempRow, tempColumn, tempRowOffset, tempColumnOffset, number))
                {
                    return true;
                }
            }
            return false;
        }

        private int[,] InsertSolvedNumberWithRow(int[,] quiz, ref bool isError)
        {
            int[,] result = quiz;
            for (int i = 0; i < 9; i++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (remainNumber[x] == 0 || IsNumberAlreadyExistWithRow(result, i, x + 1))
                        continue;
                    bool[] canInsert = new bool[9] { false, false, false, false, false, false, false, false, false };
                    for (int j = 0; j < 9; j++)
                    {
                        canInsert[j] = IsCanInsert(result, i, j, x + 1);
                    }

                    if (IsOnlyOneSpotInsert(canInsert))
                    {
                        for (int a = 0; a < 9; a++)
                        {
                            if (canInsert[a])
                            {
                                result[i, a] = x + 1;
                                remainNumber[x]--;
                            }
                        }
                    } else if (IsCanNotInsertAnySpot(canInsert))
                    {
                        isError = true;
                        return result;
                    }
                }
            }
            return result;
        }

        private bool IsCanNotInsertAnySpot(bool[] possibleArray)
        {
            for (int i = 0; i < 9; i++)
            {
                if (possibleArray[i] == true)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsCanNotInsertAnySpot(bool[,] possibleMatrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (possibleMatrix[i, j]) {
                        return false;
                    }
                }
            }
            return true;
        }

        private int[,] InsertSolvedNumberWithColumn(int[,] quiz, ref bool isError)
        {
            int[,] result = quiz;
            for (int i = 0; i < 9; i++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (remainNumber[x] == 0 || IsNumberAlreadyExistWithColumn(result, i, x + 1))
                        continue;
                    bool[] canInsert = new bool[9] { false, false, false, false, false, false, false, false, false };
                    for (int j = 0; j < 9; j++)
                    {
                        canInsert[j] = IsCanInsert(result, j, i, x + 1);
                    }

                    if (IsOnlyOneSpotInsert(canInsert))
                    {
                        for (int a = 0; a < 9; a++)
                        {
                            if (canInsert[a])
                            {
                                result[a, i] = x + 1;
                                remainNumber[x]--;
                            }
                        }
                    }
                    else if (IsCanNotInsertAnySpot(canInsert))
                    {
                        isError = true;
                        return result;
                    }
                }
            }
            return result;
        }

        private int[,] InsertSolvedNumberWithSmallMatrix(int[,] quiz, ref bool isError)
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
                        if (remainNumber[x] == 0 || IsNumberAlreadyExistWithSmallMatrix(result, tempRow, tempColumn, x + 1))
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
                        else if (IsCanNotInsertAnySpot(canInsert))
                        {
                            isError = true;
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        private bool IsNumberAlreadyExistWithSmallMatrix(int[,] quiz, int row, int column, int number)
        {
            int[] smallMetrix = GetSmallMatrixArray(quiz, row, column);
            for ( int i = 0; i < 9; i++)
            {
                if (smallMetrix[i] == number)
                    return true;
            }
            return false;
        }

        private bool IsNumberAlreadyExistWithColumn(int[,] quiz, int column, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (quiz[i, column] == number)
                    return true;
            }
            return false;
        }

        private bool IsNumberAlreadyExistWithRow(int[,] quiz, int row, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (quiz[row, i] == number)
                    return true;
            }
            return false;
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

        private bool IsOnlyOneSpotInsert(bool[] possibleArray)
        {
            bool result = false;
            int matchCount = 0;
            for (int i = 0; i < 9; i++)
            {
                if (possibleArray[i])
                    matchCount++;
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