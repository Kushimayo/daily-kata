using System;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public string Wrap(string word, int coloumnSize)
        {
            if (word.Length <= coloumnSize)
                return word;

            int wrapIndex = word.LastIndexOf(' ', coloumnSize);

            if (GetOneWordSize(word.Substring(wrapIndex + 1) ) > coloumnSize)
                wrapIndex = coloumnSize;

            return word.Substring(0, wrapIndex) + "--" + Wrap(word.Substring(wrapIndex).Trim(), coloumnSize);
        }

        private int GetOneWordSize(string word)
        {
            int spaceIndex = word.IndexOf(' ');
            return spaceIndex != -1 ? spaceIndex + 1 : word.Length;
        }
    }
}