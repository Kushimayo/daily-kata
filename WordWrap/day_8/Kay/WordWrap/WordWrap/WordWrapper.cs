using System;

namespace WordWrap
{
    public class WordWrapper
    {
        public string doWrap(string word, int col_size)
        {
            string result_string = "";

            if (word.Length > col_size)
            {
                char[] split_key_word = { ' ' };
                string[] split_strings = word.Split(split_key_word);
                int last_wrap_index = 0;
                int need_space = 0;
                int prev_index = 0;
                int available_word_count = 0;

                for (int i = 0; i < split_strings.Length; i++)
                {
                    prev_index = i;
                    available_word_count = result_string.Length - last_wrap_index;
                    if (available_word_count + split_strings[i].Length + need_space > col_size)
                    {
                        if (split_strings[i].Length > col_size)
                        {
                            int long_word_wrap_index = col_size - available_word_count - need_space;
                            result_string = add_space(result_string, need_space);
                            result_string += split_strings[i].Substring(0, long_word_wrap_index);
                            result_string += "--";
                            last_wrap_index = result_string.Length;
                            split_strings[i] = split_strings[i].Substring(long_word_wrap_index);
                            i -= 1;
                        } else
                        {
                            result_string += "--";
                            last_wrap_index = result_string.Length;
                            result_string += split_strings[i];
                        }
                    } else
                    {
                        result_string = add_space(result_string, need_space);
                        result_string += split_strings[i];
                    }

                    if (prev_index != i)
                        need_space = 0;
                    else
                        need_space = 1;
                }
            } else
            {
                result_string = word;
            }

            return result_string;
        }
        public string add_space(string word, int need_space)
        {
            if (need_space != 0)
                word += " ";
            return word;
        }
    }    
}