
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0035
{
    /*
    simple binary-search problem.
    */

    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while(left <= right)
            {
                int mid = (left + right) / 2;

                if(nums[mid] == target)
                {
                    return mid;
                }

                if(nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

    }
}
