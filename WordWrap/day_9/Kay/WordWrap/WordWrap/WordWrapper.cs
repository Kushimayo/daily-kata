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

            if (word.Length > col_size)
            {
                int pre_space_index = word.Substring(0, col_size).LastIndexOf(' ');
                int post_space_index = word.Substring(col_size).IndexOf(' ');
                if (pre_space_index == -1)
                {
                    result_string += word.Substring(0, col_size);
                    result_string += "--";
                    if (post_space_index == 0)
                        result_string += doWrap(word.Substring(col_size + 1), col_size);
                    else
                        result_string += doWrap(word.Substring(col_size), col_size);
                } else
                {
                    if (post_space_index == -1)
                    {
                        int word_size = word.Length - pre_space_index;
                        if (word_size > col_size)
                        {
                            result_string += word.Substring(0, col_size);
                            result_string += "--";
                            result_string += doWrap(word.Substring(col_size), col_size);
                        }
                        else
                        {
                            result_string += word.Substring(0, pre_space_index);
                            result_string += "--";
                            result_string += doWrap(word.Substring(pre_space_index + 1), col_size);
                        }
                    } else
                    {
                        if (post_space_index == 0)
                        {
                            result_string += word.Substring(0, col_size);
                            result_string += "--";
                            result_string += doWrap(word.Substring(col_size + 1), col_size);
                        }
                        else
                        {
                            int word_size = post_space_index + (col_size - pre_space_index);
                            if (word_size > col_size)
                            {
                                result_string += word.Substring(0, col_size);
                                result_string += "--";
                                result_string += doWrap(word.Substring(col_size), col_size);
                            }
                            else
                            {
                                result_string += word.Substring(0, pre_space_index);
                                result_string += "--";
                                result_string += doWrap(word.Substring(pre_space_index + 1), col_size);
                            }
                        }
                    }
                }
            } else
            {
                result_string = word;
            }

            return result_string;
        }
    }
}