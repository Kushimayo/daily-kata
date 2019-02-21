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
            string result = "";

            if (word.Length > col_size)
            {
                int prev_space_index = word.Substring(0, col_size).LastIndexOf(' ');
                int post_space_index = word.Substring(col_size).IndexOf(' ');

                if (post_space_index == 0)
                    result += doWrap(word, col_size, col_size, 1);
                else if (prev_space_index == -1)
                    result += doWrap(word, col_size, col_size, 0);
                else
                {
                    int one_word_size = 0;
                    if (post_space_index == -1)
                        one_word_size = word.Length - prev_space_index;
                    else
                        one_word_size = col_size - prev_space_index + post_space_index;

                    if (one_word_size > col_size)
                        result += doWrap(word, col_size, col_size, 0);
                    else
                        result += doWrap(word, prev_space_index, col_size, 1);
                }
            } else
                result = word;

            return result;
        }

        public string doWrap(string word, int wrap_index, int col_size, int space_offset)
        {
            string result = word.Substring(0, wrap_index);
            result += "--";
            result += Wrap(word.Substring(wrap_index + space_offset), col_size);
            return result;
        }
    }
}