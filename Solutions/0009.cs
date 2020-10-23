
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0009
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if(x < 10)
            {
                return x >= 0;
            }

            Int64 i64X = x;
            Int64 i64ReverseX = 0;

            for(Int64 tmp = i64X; tmp != 0; tmp /= 10)
            {
                i64ReverseX *= 10;
                i64ReverseX += tmp % 10;
            }

            return i64ReverseX == i64X;
        }

    }
}
