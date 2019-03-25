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

            int wrapIndex = GetWrapIndexWithSpace(word, limit);

            if (GetWordSize(word.Substring(wrapIndex + 1)) > limit)
                wrapIndex = limit;

            return GetPreWrappedString(word, wrapIndex) + "--" + Wrap(word.Substring(wrapIndex).Trim(), limit);
        }

        private int GetWordSize(string word)
        {
            return word.IndexOf(' ') != -1 ? word.IndexOf(' ') + 1 : word.Length;
        }

        private string GetPreWrappedString(string word, int index)
        {
            return word.Substring(0, index);
        }

        private int GetWrapIndexWithSpace(string word, int startIndex)
        {
            return word.LastIndexOf(' ', startIndex);
        }
    }
}