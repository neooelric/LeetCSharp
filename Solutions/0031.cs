
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0031
{
    /*
    There is a classic algorithm of how to generate next permutation in lexicographic ordering, and it can handle repeated values.
    This algorithm goes back to Narayana Pandita in 14th century India.

        1. Find the largest index "k" such that "a[k] < a [k+1]", if no such index exists, the permutation is the last permutation
        2. Find the largest index "l" greater than "k" such that "a[k] < a[l]"
        3. Swap the value of "a[k]" with that of "a[l]"
        4. Reverse the sequence from "a[k+1]" up to and including the final element "a[n]"
    */

    public class Solution
    {
        private void Reverse(int[] nums, int startIndex, int endIndex)
        {
            for(int left=startIndex, right=endIndex; left < right; left++, right--)
            {
                int tmp = nums[left];
                nums[left] = nums[right];
                nums[right] = tmp;
            }
        }

        public void NextPermutation(int[] nums)
        {
            if(nums.Length < 2)
            {
                return;
            }

            int k = nums.Length - 2;
            while(k >= 0 && nums[k] >= nums[k+1])
            {
                k--;
            }

            if(k < 0)
            {
                Reverse(nums, 0, nums.Length - 1);
                return;
            }

            int l = nums.Length - 1;
            while(l > k && nums[l] <= nums[k])
            {
                l--;
            }

            int tmp = nums[k];
            nums[k] = nums[l];
            nums[l] = tmp;

            Reverse(nums, k + 1, nums.Length - 1);
        }

    }
}
