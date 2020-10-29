
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0027
{
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {

            int res = 0;
            for(int i = 0; i < nums.Length; ++i)
            {
                if(nums[i] == val)
                {
                    continue;
                }
                nums[res] = nums[i];
                res++;
            }

            return res;
        }

    }
}
