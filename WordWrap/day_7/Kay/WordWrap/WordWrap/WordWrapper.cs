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
            int last_index = 0;

            if (word.Length > col_size)
            {
                char[] split_key_words = { ' ' };
                int prev_index = 0;
                bool bNeed_space = false;
                string[] split_strings = word.Split(split_key_words);
                int space_index = 0;

                for (int i = 0; i < split_strings.Length; i++)
                {
                    prev_index = i;
                    if (i == 0)
                        space_index = 0;
                    else
                        space_index = 1;
                    if ((result_string.Length - last_index) + split_strings[i].Length + space_index > col_size)
                    {
                        if (split_strings[i].Length > col_size)
                        {
                            int one_word_wrap_index = (col_size - (result_string.Length - last_index) - space_index);
                            if (bNeed_space && space_index==1)
                                result_string += " ";
                            result_string += split_strings[i].Substring(0, one_word_wrap_index);
                            result_string += "--";
                            last_index = result_string.Length;
                            split_strings[i] = split_strings[i].Substring(one_word_wrap_index);
                            i -= 1;
                        }
                        else
                        {
                            result_string += "--";
                            last_index = result_string.Length;
                            result_string += split_strings[i];
                        }
                    }
                    else
                    {
                        if (bNeed_space && space_index == 1)
                            result_string += " ";
                        result_string += split_strings[i];
                    }
                    if (prev_index != i)
                        bNeed_space = false;
                    else
                        bNeed_space = true;
                }
            } else
            {
                result_string = word;
            }

            return result_string;
        }
    }
}