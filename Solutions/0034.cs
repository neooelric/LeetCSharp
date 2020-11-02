using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0034
{
    /*
    binary-search is a simple powerful tool to search a specified target
    but the painful part is : if there are several target in an array
    binary can not tell you the start index and end index of this consecutive target

    so there are two problems:
        1. find the target
        2. since the previous number and later number could be target too
           you have to find the minimum and maximum index of target
    
    the interesting part is:
        you can use binary-search to solve step 1
        you also can use binary-search to solve step 2
    
    the train of thought is:
        since we solved step 1, we got an index of target
        the minIndex of target must <= index
        the maxIndex of target must >= index
    
    so we have to find minIndex between [0, index] and maxIndex between[index, nums.Length-1]

    how?
    use minIndex as example:
        1. search target between [0, index-1], if no result, ok, index is the minIndex, if has a result:
        2. search target between [0, index2-1], if no result, ok, index2 is the minIndex, if has a result, continue iterate

    ----
    just don't be so rigid, you can use binary-search in a very flexible way

    if a problem is about search, and it's content is sorted in some way

    then very likely this problem can be solved by binary-search

    back to step 2, you've already know that the minIndex of target is between [0, index]

    actually you can made the cursor start with value 'index', move it (left+right)/2 in each iteration

    if the cursor is point to target, then move the cursor to left, otherwise move it to right

    this also some kind of binary-search
    */

    public class Solution
    {
        private int BinarySearch(int[] nums, int left, int right, int target)
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
        public int[] SearchRange(int[] nums, int target)
        {
            int targetIndex = BinarySearch(nums, 0, nums.Length - 1, target);
            if (targetIndex == -1)
            {
                return new int[2] { -1, -1 };
            }

            int targetMinIndex = targetIndex;
            int targetMaxIndex = targetIndex;

            int left = 0;
            int right = targetIndex - 1;

            while (true)
            {
                int newTargetIndex = BinarySearch(nums, left, right, target);
                if (newTargetIndex == -1)
                {
                    break;
                }

                targetMinIndex = newTargetIndex;
                right = newTargetIndex - 1;
            }

            left = targetIndex + 1;
            right = nums.Length - 1;

            while (true)
            {
                int newTargetIndex = BinarySearch(nums, left, right, target);
                if (newTargetIndex == -1)
                {
                    break;
                }

                targetMaxIndex = newTargetIndex;
                left = newTargetIndex + 1;
            }

            return new int[2] { targetMinIndex, targetMaxIndex };
        }

    }
}