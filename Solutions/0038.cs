using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0038
{
    /*
    look at the constraints of the problem, it mentioned that 1 <= n <= 30
    this basically the hint : hey, the n is pretty small, please use recursive
    */

    public class Solution
    {
        public string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }

            string res = "";
            string prevRes = CountAndSay(n - 1);

            int currentDigit = prevRes[0] - '0';
            int currentDigitCount = 1;

            for (int i = 1; i <= prevRes.Length; ++i)
            {
                if (i == prevRes.Length || currentDigit != prevRes[i] - '0')
                {
                    res += (char)(currentDigitCount + '0');
                    res += (char)(currentDigit + '0');
                    if (i < prevRes.Length)
                    {
                        currentDigit = prevRes[i] - '0';
                        currentDigitCount = 1;
                    }
                }
                else
                {
                    currentDigitCount++;
                }
            }

            return res;
        }
    }
}