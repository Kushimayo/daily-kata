using System;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public string Wrap(string word, int col_size)
        {
            if (word.Length <= col_size)
                return word;

            int prev_space_index = word.LastIndexOf(' ', col_size);
            int wrap_index = prev_space_index;
            if (GetOneWordSize(word.Substring(prev_space_index + 1)) > col_size)
            {
                wrap_index = col_size;
            }

            return word.Substring(0, wrap_index) + "--" + Wrap(word.Substring(wrap_index).Trim(), col_size);
        }

        int GetOneWordSize(string word)
        {
            return word.Contains(" ") ? word.IndexOf(' ') + 1 : word.Length;
        }
    }
}