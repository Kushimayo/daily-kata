using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class SudokuGame
    {
        public SudokuGame()
        {
        }

        public Dictionary<string, string> ConvertToDicionary(int[,] quiz)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            char a = 'A';
            for (int i = 0; i < 9; i++)
            {                
                for (int j = 0; j < 9; j++)
                {
                    string key = "";
                    string value = "";
                    if (quiz[j, i] == 0)
                    {
                        value = "123456789";
                    } else
                    {
                        value = quiz[j, i].ToString();
                    }
                    key = a + (j+1).ToString();
                    result.Add(key, value);
                }
                a++;
            }

            return result;
        }

        public string[,] ConvertToString(int[,] given)
        {
            string[,] result = new string[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (given[i, j] == 0)
                        result[i, j] = "123456789";
                    else
                        result[i, j] = given[i, j].ToString();
                }
            }
            return result;
        }

        public string[,] Solve(int[,] quiz)
        {
            string[,] result = ConvertToString(quiz);
            bool isError = false;

            result = Check(result, ref isError);

            //for (int row = 0; row < 9; row++)
            //{
            //    for (int column = 0; column < 9; column++)
            //    {
            //        if (result[row, column].Length == 1)
            //            result = RemovePeerValues(result, row, column, result[row, column]);
            //    }
            //}

            return result;
        }

        private string[,] Check(string[,] quiz, ref bool isError)
        {
            string[,] result = quiz;
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (result[row, column].Length == 1)
                    {
                        result = RemovePeerValues(result, row, column, result[row, column], ref isError);
                        if (isError)
                            return result;
                    }
                }
            }
            return result;
        }

        private string[,] Solving(string[,] quiz, ref bool isError)
        {
            if (isError)
                return quiz;
            if (IsDone(quiz))
                return quiz;

            int findMinLength = 10;
            int tryRow = 0;
            int tryColumn = 0;

            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (quiz[row, column].Length != 1 && quiz[row, column].Length < findMinLength)
                    {
                        findMinLength = quiz[row, column].Length;
                        tryRow = row;
                        tryColumn = column;
                        if (quiz[row, column].Length == 2)
                            break;
                    }
                }
                if (quiz[tryRow, tryColumn].Length == 2)
                    break;
            }

            string currentValue = quiz[tryRow, tryColumn];
            for (int i = 0; i < currentValue.Length; i++)
            {
                string tryValue = currentValue.Substring(i, 1);
            }
        }

        private bool IsDone(string[,] quiz)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (quiz[row, column].Length != 1)
                        return false;
                }
            }
            return true;
        }

        private string[,] RemovePeerValues(string[,] quiz, int row, int column, string value, ref bool isError)
        {
            string[,] temp = (string[,])quiz.Clone();
            int tempRow = (row / 3) * 3;
            int tempColumn = (column / 3) * 3;
            int tempRowOffset = row % 3;
            int tempColumnOffset = column % 3;

            for (int i = 0; i < 9; i++)
            {
                if (i == column)
                    continue;
                if (temp[row, i].Contains(value))
                {
                    temp[row, i] = temp[row, i].Replace(value, "");
                    if (temp[row, i].Length == 1)
                    {
                        temp = RemovePeerValues(temp, row, i, temp[row, i], ref isError);
                    }
                    else if (temp[row, i].Length == 0)
                    {
                        isError = false;
                        return temp;
                    }
                }
            }

            for (int j = 0; j < 9; j++)
            {
                if (j == row)
                    continue;
                if (temp[j, column].Contains(value))
                {
                    temp[j, column] = temp[j, column].Replace(value, "");
                    if (temp[j, column].Length == 1)
                    {
                        temp = RemovePeerValues(temp, j, column, temp[j, column], ref isError);
                    }
                    else if (temp[j, column].Length == 0)
                    {
                        isError = false;
                        return temp;
                    }
                }
            }

            for (int miniRow = 0; miniRow < 3; miniRow++)
            {
                int actualRow = tempRow + miniRow;
                for (int miniCol = 0; miniCol < 3; miniCol++)
                {
                    int actualCol = tempColumn + miniCol;
                    if (actualRow == row && actualCol == column)
                        continue;
                    if (temp[actualRow, actualCol].Contains(value))
                    {
                        temp[actualRow, actualCol] = temp[actualRow, actualCol].Replace(value, "");
                        if (temp[actualRow, actualCol].Length == 1)
                        {
                            temp = RemovePeerValues(temp, actualRow, actualCol, temp[actualRow, actualCol], ref isError);
                        }
                        else if (temp[actualRow, actualCol].Length == 0)
                        {
                            isError = false;
                            return temp;
                        }
                    }
                    
                }
            }

            return temp;
        }
    }
}