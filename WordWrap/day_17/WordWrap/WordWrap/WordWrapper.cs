using System;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public string Wrap(string word, int limit)
        {
            if (word.Length <= limit)
                return word;

            int wrapIndex = GetIndexOfLastSpace(word, limit);
            if (GetoneWordLength(GetRemainString(word, wrapIndex + 1)) > limit)
                wrapIndex = limit;

            return GetOneLineString(word, wrapIndex) + "--" + GetTailString(word, limit, wrapIndex);
        }

        private static string GetRemainString(string word, int wrapIndex)
        {
            return word.Substring(wrapIndex);
        }

        private string GetTailString(string word, int limit, int wrapIndex)
        {
            return Wrap(GetRemainString(word, wrapIndex).Trim(), limit);
        }

        private static string GetOneLineString(string word, int wrapIndex)
        {
            return word.Substring(0, wrapIndex);
        }

        private int GetoneWordLength(string word)
        {
            return GetIndexOfSpace(word) != -1 ? GetIndexOfSpace(word) + 1 : word.Length;
        }

        private static int GetIndexOfSpace(string word)
        {
            return word.IndexOf(' ');
        }

        private static int GetIndexOfLastSpace(string word, int limit)
        {
            return word.LastIndexOf(' ', limit);
        }
    }
}