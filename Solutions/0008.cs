
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0008
{
    /*
    pretty simple, just pay attention at overflows
    */

    public class Solution
    {
        public int MyAtoi(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            int res = 0;
            bool isNegative = false;
            int i = 0;

            while(char.IsWhiteSpace(s[i]))
            {
                i++;
            }

            if(s[i] == '-' || s[i] == '+')
            {
                isNegative = s[i] == '-';
                i++;
            }

            while(i < s.Length && char.IsDigit(s[i]))
            {
                int digit = s[i] - '0';

                if(isNegative && res < (Int32.MinValue + digit) / 10)
                {
                    return Int32.MinValue;
                }

                if(!isNegative && res > (Int32.MaxValue - digit) / 10)
                {
                    return Int32.MaxValue;
                }

                res *= 10;

                res = isNegative ? (res - digit) : (res + digit);

                i++;
            }

            return res;
        }
    }
}
