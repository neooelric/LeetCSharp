
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0014
{
    /*
    simple problem

    trick:
        throw Exception can quick jump out of nested loop and deep recursive call stack,

        but this trick is like "goto" : 
            it's dangerous, it's very controversial, do not abuse this kind of trick in real work
    */

    public class Solution
    {
        private class DoneFlag : Exception { }

        public string LongestCommonPrefix(string[] strs)
        {
            if(strs.Length == 0)
            {
                return "";
            }

            int commonPrefixLength = 0;
            try
            {
                while (true)
                {
                    if (commonPrefixLength + 1 > strs[0].Length)
                    {
                        throw new DoneFlag();
                    }

                    char commonChar = strs[0][commonPrefixLength];

                    foreach (string str in strs)
                    {
                        if (commonPrefixLength + 1 > str.Length)
                        {
                            throw new DoneFlag();
                        }

                        if (str[commonPrefixLength] != commonChar)
                        {
                            throw new DoneFlag();
                        }
                    }

                    commonPrefixLength++;
                }
            }
            catch(DoneFlag)
            {
                return strs[0].Substring(0, commonPrefixLength);
            }
        }

    }
}
