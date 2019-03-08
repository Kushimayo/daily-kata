using System;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public string Wrap(string text, int limit)
        {
            if (text.Length <= limit)
                return text;

            int wrapIndex = text.LastIndexOf(' ', limit);
            if (GetOneWordSize(text.Substring(wrapIndex + 1)) > limit)
                wrapIndex = limit;

            return text.Substring(0, wrapIndex) + "--" + Wrap(text.Substring(wrapIndex).Trim(), limit);
        }

        private int GetOneWordSize(string text)
        {
            return text.IndexOf(' ') != -1 ? text.IndexOf(' ') + 1 : text.Length;
        }
    }
}