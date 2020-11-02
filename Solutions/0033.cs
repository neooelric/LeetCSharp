using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0033
{
    /*
    the only thing stop you to use binary-search is:
        you don't know where is the start index of this rotated array
    
    so, how to find the "rotate-point" ?

    this is the most-interesting part : 
        you can use binary-search to search rotate point

    so, two step:
        1. use binary-search to search the rotate point
        2. search the target -- just mapping rotate-point to 0, then treat it as a regular sorted array
    */

    public class Solution
    {

        private int searchRotatePoint(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int middle = (left + right) / 2;

                if (nums[middle] < nums[right])
                {
                    right = middle;
                }
                else if (nums[middle] > nums[right])
                {
                    left = middle + 1;
                }
            }

            return left;
        }

        public int Search(int[] nums, int target)
        {
            int rotateIndex = searchRotatePoint(nums);

            int leftLogicIndex = 0;
            int rightLogicIndex = nums.Length - 1;

            while (leftLogicIndex <= rightLogicIndex)
            {
                int middleLogicIndex = (leftLogicIndex + rightLogicIndex) / 2;

                int middleIndex = (middleLogicIndex + rotateIndex) % nums.Length;

                if (nums[middleIndex] == target)
                {
                    return middleIndex;
                }

                if (nums[middleIndex] < target)
                {
                    leftLogicIndex = middleLogicIndex + 1;
                }
                else
                {
                    rightLogicIndex = middleLogicIndex - 1;
                }
            }

            return -1;
        }
    }
}