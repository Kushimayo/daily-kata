using System;

namespace DiamondPrint
{
    public class Solution
    {
        public Solution()
        {
        }

        public int GetDepth(char letter)
        {
            char Upletter = Char.ToUpper(letter);
            int result = Upletter - 'A';
            return result;
        }

        public string GetDiamondString(char letter)
        {
            char upLetter = Char.ToUpper(letter);
            int depth = GetDepth(upLetter);
            int width = depth + 1;
            int height = depth * 2 + 1;
            var sb = new System.Text.StringBuilder();
            char printLetter = 'A';
            string result = "";
            Boolean grow = true;
            for (int i = 0; i < height;)
            {
                for (int j = 0; j < width; j++)
                {
                    if (isAddLetter(depth, width, i, j))
                    {
                        sb.Append(printLetter);
                    } else
                    {
                        sb.Append(" ");
                    }
                }
                if (++i != height)
                    sb.Append("\n");
                if (upLetter == printLetter)
                {
                    grow = false;
                }
                if (grow)
                {
                    width++;
                    printLetter++;
                } else
                {
                    width--;
                    printLetter--;
                }
            }
            result = sb.ToString();
            return result;

        }

        private Boolean isAddLetter(int depth, int width, int row, int col)
        {
            return Math.Abs(depth - row) == col || col == width - 1;
        }
    }
}