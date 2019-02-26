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

            int wrap_index = 0;
            int space_remove = 0;
            int prev_space_index = word.LastIndexOf(' ', col_size);
            if (prev_space_index == -1)
            {
                wrap_index = col_size;
                prev_space_index = 0;
                if (word.IndexOf(' ', col_size) == 0)
                    space_remove = 1;
            } else
            {
                int post_space_index = word.IndexOf(' ', prev_space_index);
                int one_word_length = 0;
                if (post_space_index == -1)
                {
                    one_word_length = word.Length - prev_space_index;
                } else
                {

                }
            }
            

            return word.Substring(0, wrap_index) + "--" + Wrap(word.Substring(wrap_index + space_remove), col_size);
        }
    }
}