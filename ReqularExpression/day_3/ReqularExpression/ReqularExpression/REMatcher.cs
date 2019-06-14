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

            bool firstmatch = false;
            string s_sub = s;
            string p_sub = p;
            if (s[0].Equals(p[0]) || p[0].Equals('.'))
            {
                firstmatch = true;
                s_sub = s.Substring(1);
                if (!NextPatternIsStar(p))
                {
                    p_sub = p.Substring(1);
                }
            } else
            {
                if (NextPatternIsStar(p))
                {
                    firstmatch = true;
                    p_sub = p.Substring(2);
                } else
                {
                    firstmatch = false;
                }
            }

            if (s_sub.Length == 0)
            {
                if (CheckPatternIsDone(p_sub))
                    return firstmatch;
                else
                    return false;
            } else
            {
                return firstmatch && IsMatch(s_sub, p_sub);
            }
        }

        private bool NextPatternIsStar(string p)
        {
            return p.Length >= 2 && p[1].Equals('*');
        }

        private bool CheckPatternIsDone(string p)
        {
            if (p.Length < 1)
                return true;

            if (p.Length == 1)
                return false;

            if (NextPatternIsStar(p))
            {
                return CheckPatternIsDone(p.Substring(2));
            } else
            {
                return false;
            }

        }
    }
}