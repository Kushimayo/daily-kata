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
            char[] split_key_word = { ' ' };
            if (word.Length > col_size)
            {
                int last_space = word.Substring(0, col_size).LastIndexOf(" ");
                if (last_space != -1)
                {
                    result_string += word.Substring(0, last_space);
                    result_string += "--";
                    result_string += doWrap(word.Substring(last_space + 1), col_size);
                } else
                {

                }
                
            } else
            {
                result_string = word;
            }

            return result_string;
        }
    }
}