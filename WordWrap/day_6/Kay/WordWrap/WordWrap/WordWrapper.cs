using System;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public string doWrap(string word, int col_size)
        {
            string result_string = "";
            int last_wrap_index = 0;
            int preview_index = 0;
            bool need_space = true;

            if (word.Length > col_size)
            {
                char[] split_key_word = { ' ' };
                string[] split_strings = word.Split(split_key_word);
                if (split_strings[0].Length > col_size)
                {

                } else
                {
                    result_string += split_strings[0];
                }

                for (int i = 1; i < split_strings.Length; i++)
                {
                    preview_index = i;
                    if ((result_string.Length - last_wrap_index) + split_strings[i].Length + 1 > col_size)
                    {
                        if (split_strings[i].Length > col_size)
                        {
                            int one_word_wrap_index = (col_size - (result_string.Length - last_wrap_index) - 1);
                            if (need_space)
                                result_string += " ";
                            result_string += split_strings[i].Substring(0, one_word_wrap_index);
                            result_string += "--";
                            last_wrap_index = result_string.Length;
                            split_strings[i] = split_strings[i].Substring(one_word_wrap_index);
                            i -= 1;
                        } else
                        {
                            result_string += "--";
                            last_wrap_index = result_string.Length;
                            result_string += split_strings[i];
                        }
                    } else
                    {
                        if (need_space)
                            result_string += " ";
                        result_string += split_strings[i];
                    }
                    if (preview_index != i)
                        need_space = false;
                    else
                        need_space = true;
                }
            } else
            {
                result_string += word;
            }

            return result_string;
        }
    }
}