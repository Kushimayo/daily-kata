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

            int pre_space_index = word.LastIndexOf(' ', col_size);
            int post_space_index = word.IndexOf(' ', col_size);
            int wrap_index = 0;
            int remove_space = 0;

            if (post_space_index == 0)
            {
                wrap_index = col_size;
                remove_space = 1;
            }
            else if (pre_space_index == -1 || one_word_length(word, col_size, pre_space_index, post_space_index) > col_size)
            {
                wrap_index = col_size;
            } else
            {
                wrap_index = pre_space_index;
                remove_space = 1;
            }

            return word.Substring(0, wrap_index) + "--" + Wrap(word.Substring(wrap_index + remove_space), col_size);
        }

        public int one_word_length(string word, int col_size, int pre, int post)
        {
            if (post == -1)
                return word.Length - (pre + 1);

            return col_size - (pre + 1) + (post + 1);
        }
    }
}