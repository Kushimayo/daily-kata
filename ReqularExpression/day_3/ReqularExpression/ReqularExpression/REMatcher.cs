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

            if (s.Length == 0)
            {
                return CheckPatternIsDone(p);
            }

            if (s.Length == singleCharLengthFromP(p))
            {
                p = removeStarPattern(p);
            } else if (s.Length > singleCharLengthFromP(p))
            {
                if (p.Length >= 4 && p[1].Equals('*'))
                {
                    if (s[0].Equals(p[2]) && s[1].Equals(p[3]))
                    {
                        p = p.Substring(2);
                    }
                }
            }

            bool firstmatch = true;
            string s_sub = s;
            string p_sub = p;
            if (p[p.Length - 1].Equals('*'))
            {
                if (s[0].Equals(p[0]) || p[0].Equals('.'))
                {
                    firstmatch = true;
                    s_sub = s.Substring(1);
                    if (!NextPatternIsStar(p))
                    {
                        p_sub = p.Substring(1);
                    }
                }
                else
                {
                    if (NextPatternIsStar(p))
                    {
                        firstmatch = true;
                        p_sub = p.Substring(2);
                    }
                    else
                    {
                        firstmatch = false;
                    }
                }

            } else
            {
                if (s[s.Length -1].Equals(p[p.Length -1]) || p[p.Length - 1].Equals('.'))
                {
                    firstmatch = true;
                    s_sub = s.Substring(0, s.Length - 1);
                    p_sub = p.Substring(0, p.Length - 1);
                } else
                {
                    firstmatch = false;
                }
            }

            return firstmatch && IsMatch(s_sub, p_sub);
        }

        private string removeStarPattern(string p)
        {
            string pattern = p;
            while(pattern.Contains("*"))
            {
                string temp = pattern;
                int index = temp.IndexOf("*");
                pattern = temp.Substring(0, index - 1) + temp.Substring(index + 1);
            }

            return pattern;
        }

        private bool NextPatternIsStar(string p)
        {
            return p.Length >= 2 && p[1].Equals('*');
        }

        private int singleCharLengthFromP(string p)
        {
            if (p.Contains("*"))
            {
                string temp = p.Replace("*", "");

                return p.Length - ((p.Length - temp.Length) * 2);
            } else
            {
                return p.Length;
            }
        }

        private bool CheckPatternIsDone(string p)
        {
            if (p.Length < 1)
                return true;

            if (p.Length == 1 || !NextPatternIsStar(p))
                return false;

            return CheckPatternIsDone(p.Substring(2));
        }
    }
}