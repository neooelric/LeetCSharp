using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0046
{
    /*
    we've already solved the Next Permutation problem(No.31)

    so this could be very easy

    and this is the NextPermutation algorithm on wikipedia:

        1. Find the largest index "k" such that "a[k] < a [k+1]", if no such index exists, the permutation is the last permutation
        2. Find the largest index "l" greater than "k" such that "a[k] < a[l]"
        3. Swap the value of "a[k]" with that of "a[l]"
        4. Reverse the sequence from "a[k+1]" up to and including the final element "a[n]"
    
    tips:
        sort the numbers first

    */

    public class Solution
    {
        private void Reverse(int[] nums, int startIndex, int endIndex)
        {
            for (int left = startIndex, right = endIndex; left < right; ++left, --right)
            {
                int tmp = nums[left];
                nums[left] = nums[right];
                nums[right] = tmp;
            }
        }

        private int[] NextPermutation(int[] nums)
        {
            if (nums.Length == 1)
            {
                return null;
            }

            int[] dupNums = nums.ToArray();

            int k = dupNums.Length - 2;
            while (k >= 0 && dupNums[k] >= dupNums[k + 1])
            {
                k--;
            }

            if (k < 0)
            {
                return null;
            }

            int l = dupNums.Length - 1;
            while (l > k && dupNums[l] <= dupNums[k])
            {
                l--;
            }

            int tmp = dupNums[k];
            dupNums[k] = dupNums[l];
            dupNums[l] = tmp;

            Reverse(dupNums, k + 1, nums.Length - 1);

            return dupNums;
        }
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);

            for (int[] permutation = nums; permutation != null; permutation = NextPermutation(permutation))
            {
                res.Add(permutation);
            }

            return res;
        }
    }
}