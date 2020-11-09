using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0044
{
    /*
    Seems like this coule be a very hard problem, but actually it's not that so hard.

    the difference between this problem and problem No.10 is:
        1. '*' in here matches any string, include empty.
           '*' in No.10 match zero or more preceeding character(s) sequence
        2. this problem's constraints is 0<= s.length, p.length <= 3000, 
           constraints of No.10 is much less
    
    the problem told us s and p might be very long, so you might want to use recursive at first
    but very obvious that's not a good way due to s and p could be very long

    the only problem is : how to handle '*'

    let me pick an example to illustrate:
        s : "abcdef1234g"
        p : "?bcdef*g"
    
    we can directly match each character util we encounter '*'
    then we'll pause at here

        s : "abcdef1234g"
                   ^
        p : "?bcdef*g"
                   ^
    
    now, there are several possibles:
        1. '*' matches empty string
        2. '*' matches '1'
        3. '*' matches '12'
        4. '*' matches '123'
        5. '*' matches '1234'
        6. '*' matches '1234g'
        7. all above are unmatches, then the whole match are false
    
    so you see ? this is a very typical 'branch' problem
        1. you have to try all the possible branches one by one to find the right way
        2. after one branch is failed, you have to reset the context, then do next try
        3. if all branches is dead way, then the problem is dead
    
    what's the best way to do this kind of problem?

    not recursive, recursive is just the coding represention, the implementation
    not the "way" to solve this kind of problem

    is DFS+Recall

    unlike Problem.10, i'll write a non-recursive algorithm here to solve this problem


    */
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            int si = 0;
            int pi = 0;

            int recallSi = -1;
            int recallPi = -1;

            while (si < s.Length)
            {
                // single character matches, move next both
                if (
                    pi < p.Length &&
                    (
                    p[pi] == '?' ||
                    (p[pi] != '*' && p[pi] == s[si])
                    )
                )
                {
                    si++;
                    pi++;
                    continue;
                }

                // encounter *, DFS and record recall context
                if (pi < p.Length && p[pi] == '*')
                {
                    pi++;
                    if (pi == p.Length)
                    {
                        return true;
                    }

                    recallSi = si;
                    recallPi = pi;
                    continue;
                }

                // if code goes here, means match failed on current char
                // recall if possible
                if (recallSi != -1)
                {
                    pi = recallPi;
                    si = recallSi + 1;
                    recallSi = si;
                    continue;
                }

                return false;

            }

            while (pi < p.Length && p[pi] == '*')
            {
                pi++;
            }

            return pi == p.Length;
        }
    }
}