
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Solutions._0028
{
    /*
    aha, the classic string match problem

    for this kind of problem, you really should use KMP algorithm to solve

    KMP is not easy to understand, it's a little bit twist, 
    but it's so classic and widely known, 
    actually, it becomes the "standard interview answer" to string matching problem

    */

    public class Solution
    {
        private int[] getNextArray(string needle)
        {
            int[] next = new int[needle.Length];
            next[0] = -1;

            int i = 0;
            int j = -1;

            while(i < needle.Length - 1)
            {
                if(j == -1 || needle[i] == needle[j])
                {
                    i++;
                    j++;
                    next[i] = j;
                }
                else
                {
                    j = next[j];
                }
            }

            return next;
        }

        private int KMP(string haystack, string needle, int[] next)
        {
            int i = 0;
            int j = 0;
            while(i < haystack.Length && j < needle.Length)
            {
                if(j == -1 || haystack[i] == needle[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = next[j];
                }
            }

            if(j == needle.Length)
            {
                return i - j;
            }
            else
            {
                return -1;
            }
        }

        public int StrStr(string haystack, string needle)
        {
            if(string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            return KMP(haystack, needle, getNextArray(needle));
        }
    }
}