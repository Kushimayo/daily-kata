using System;

namespace ReqularExpression
{
    public class REMatcher
    {
        public REMatcher()
        {
        }

        public bool IsMatch(string s, string p)
        {
            if (!p.Contains("*") && !p.Contains("."))
                return s.Equals(p);

            for(int i = 0; i < s.Length; i++)
            {
                int match_index = p.IndexOf(s[i]);
                if (match_index == -1)
                {
                    match_index = p.IndexOf(".");
                    if (match_index == -1)
                    {
                        return false;
                    } else
                    {

                    }
            }

            int index_star = p.IndexOf("*");
            if (index_star > 0)
            {
                string star_string = p.Substring(index_star - 1, 1);

            } else
            {
                return false;
            }

            return true;
        }
    }
}