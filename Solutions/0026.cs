using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0026
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            int res = 0;
            for(int i = 0; i < nums.Length; ++i)
            {
                if(i > 0 && nums[i] == nums[i-1])
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