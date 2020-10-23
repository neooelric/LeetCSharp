
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0010
{
    /*
    this problem looks kind of creepy, but acutally it's not that kind of diffcult you think.

    the overall thoughts is to judge IsMatch recursively
    and in order to avoid the string copy during recursive calling, we'd better to write a wrapper
    which accept the original S and P, and the index of each string
    this wrapper only judge s[si..] and p[pi..] is match or not, not the entire S and P

    and the tedious thing is debugging, this kind of problem will kill lots of time when you ain't handle the corner cases very well
    */

    public class Solution
    {
        private bool IsMatch(string s, int si, string p, int pi)
        {
            int sLength = s.Length - si;
            int pLength = p.Length - pi;

            if(pLength <= 0)
            {
                return sLength <= 0;
            }

            if(pLength == 1)
            {
                if(sLength != 1)
                {
                    return false;
                }

                if(s[si] == p[pi] || p[pi] == '.')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // the below code block only handles scenarios which pLength >= 2 and the second character of p is not '*'
            if(p[pi+1] != '*')
            {
                if(sLength <= 0)
                {
                    return false;
                }

                if(s[si] != p[pi] && p[pi] != '.')
                {
                    return false;
                }

                return IsMatch(s, si + 1, p, pi + 1);
            }

            // the below two code blocks only handles scenarios which pLength >= 2 and the second character of p is '*'
            if(p[pi] == '.')
            {
                for(int skipCharCount = 0; skipCharCount <= sLength; ++skipCharCount)
                {
                    if(IsMatch(s, si+skipCharCount, p, pi+2))
                    {
                        return true;
                    }
                }
            }
            else
            {
                if(IsMatch(s, si, p, pi+2))
                {
                    return true;
                }

                for(int skipCharCount = 1; skipCharCount <= sLength && s[si+skipCharCount - 1] == p[pi]; ++skipCharCount)
                {
                    if (IsMatch(s, si + skipCharCount, p, pi+2))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsMatch(string s, string p)
        {
            return IsMatch(s, 0, p, 0);
        }

    }
}
