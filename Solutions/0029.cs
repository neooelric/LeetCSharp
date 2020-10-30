
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace Solutions._0029
{
    /*
    it is very obviously that this problem is ask you to do "divide" operation manually
    using code logic to simiulate the "divide" logic

    the basic train of thought is :
        step 1 : check the answer should be positive or negative, 
                 then convert two operand both to it's Abs value, maybe store them into Unsigned type variable
        step 2 : using minus in a loop, before dividend goes less than divisor, the minus count is the answer

    so there are two key points:
        1. range of int(Int32) is : [-0x80000000, 0x7fffffff]
        2. minus in loop is pretty low performance, we have to find a way to optimize this, speed the loop up
           the most intuitive way is to using bit operation to speed up the loop
           minus 2^n * divisor in each iteration instead of divisor
    */

    public class Solution
    {
        public UInt32 IntAbsToUInt32(int num)
        {
            if(num > 0)
            {
                return Convert.ToUInt32(num);
            }

            if(num == int.MinValue)
            {
                return 0x80000000;
            }

            return Convert.ToUInt32(-num);
        }
        public int Divide(int dividend, int divisor)
        {
            // step 1. convert operand to UInt32 and handle some corner cases
            bool resIsNegative = (dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0);

            UInt32 unsignedDividend = IntAbsToUInt32(dividend);
            UInt32 unsignedDivisor = IntAbsToUInt32(divisor);

            // step 2 : simulate divide operation
            UInt32 res = 0;
            while(unsignedDividend >= unsignedDivisor)
            {
                UInt32 multiplesCountOfDivisor = 1;
                UInt32 minuend = unsignedDivisor;

                while(minuend < unsignedDividend)
                {
                    minuend <<= 1;
                    multiplesCountOfDivisor <<= 1;
                }

                if (minuend > unsignedDividend)
                {
                    minuend >>= 1;
                    multiplesCountOfDivisor >>= 1;
                }

                unsignedDividend -= minuend;
                res += multiplesCountOfDivisor;
            }

            if(res > 0x80000000)
            {
                return int.MaxValue;
            }

            if(res == 0x80000000)
            {
                return resIsNegative ? int.MinValue : int.MaxValue;
            }

            return resIsNegative ? -Convert.ToInt32(res) : Convert.ToInt32(res);
        }

    }
}
