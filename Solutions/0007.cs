
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0007
{
    /*
    pretty simple problem, but the corner cases is pretty gross if you decide to handle it using Int32 variable

    the simpliest way to handle the overflow properly:
        1. using Int64
        2. if the result not in Int32 range, return zero
    */

    public class Solution
    {
        public int Reverse(int x)
        {
            Int64 i64X = Convert.ToInt64(x);
            Int64 i64Res = 0;

            while (i64X != 0)
            {
                Int64 lastDigit = i64X % 10;
                i64X /= 10;

                i64Res *= 10;
                i64Res += lastDigit;
            }

            if(i64Res < Convert.ToInt64(Int32.MinValue) || i64Res > Convert.ToInt64(Int32.MaxValue))
            {
                return 0;
            }

            return Convert.ToInt32(i64Res);
        }
    }
}
