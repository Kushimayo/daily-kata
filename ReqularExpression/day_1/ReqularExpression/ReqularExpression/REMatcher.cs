using System;

namespace ReqularExpression
{
    public class REMatcher
    {
        public REMatcher()
        {
        }

        public bool isMatch(string s, string p)
        {
            if (!p.Contains("*") && !p.Contains("."))
                return s.Equals(p);

            int star_index = p.IndexOf("*");
            string star_string = p.Substring(star_index - 1, 1);
            bool result = false;

            if (s.Contains(star_string))
            {

            }

            return result;
        }
    }
}