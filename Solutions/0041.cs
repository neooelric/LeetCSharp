using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0041
{
    /*
    bucket sort can solve this kind of problem
    but regular bucket sort use O(n) memory, not O(1) memory. -- you need to create a new array

    so we need to do bucket sort in place

        traverse(nums)
        {
            numShouldAt = nums[i]-1;
            while(numShouldAt >= 0 && numShouldAt < nums.length && num[numShouldAt] != nums[i])
            {
                Swap(nums[index], nums[numShouldAt]);
            }
        }
    
    be careful with the while loop conditions, if you use
        numShouldAt != i
    instead of
        num[numShouldAt] != nums[i]
    in below cases, it'll loop forever
        [1,1]
    
    -----

    the algorithm is actually not the simple as you think
    especially the while loop conditions

    */

    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                while (
                    nums[i] - 1 >= 0 &&
                    nums[i] - 1 < nums.Length &&
                    nums[nums[i] - 1] != nums[i]
                )
                {
                    int num = nums[i];
                    nums[i] = nums[num - 1];
                    nums[num - 1] = num;
                }
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return nums.Length + 1;
        }
    }
}