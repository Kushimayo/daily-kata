using System;

namespace WordWrap
{
    public class WordWrapper
    {
        public WordWrapper()
        {
        }

        public string doWrap(string word, int colSize)
        {
            string resultString = "";
            if (word.Length > colSize)
            {
                int indexOfSpace = word.IndexOf(" ");
                if (indexOfSpace < colSize)
                {
                    resultString = word.Substring(0, indexOfSpace);
                    resultString += "--";
                    resultString += word.Substring(indexOfSpace + 1);
                }
            } else
            {
                resultString = word;
            }
            return resultString;
        }
    }
}