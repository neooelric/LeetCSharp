using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0050
{
    /*
    multiply x n times can not solve the problem, I dont event need to try and I know that will be definitely out of time-limit.

    a very easy to thought way is try to iterate result*result operation,to reduce the iterate count, instead of n times.

    trick:
        1. x^n == (x^2)^(n/2)
        2. if N & 1 == 0, that means N can be exact divide by 2
        3. if x equals 1 or -1 or 0, you can quickly return the answer instead of calcualte by loop
    
    */

    public class Solution
    {
        public double MyPow(double x, int n)
        {
            bool NIsNegetive = n < 0;

            // since abs(-int.MinValue) might over flow
            // we need use a larger type to store n's abs
            // fortunately, Math.Abs already return long type

            long ln = Math.Abs((long)(n));

            if (Math.Abs(x) < 0.000001)
            {
                return 0;
            }

            if (Math.Abs(Math.Abs(x) - 1.0) < 0.000001)
            {
                return x > 0 ? 1 : ((n & 1) == 1 ? -1 : 1);
            }

            double res = 1;
            while (ln != 0)
            {

                if ((ln & 1) == 1)
                {
                    res *= x;
                }

                ln >>= 1;
                x *= x;
            }

            return NIsNegetive ? 1.0 / res : res;
        }
    }
}