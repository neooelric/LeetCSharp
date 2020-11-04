using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0042
{
    /*
    very interesting problem!

    1. find the highest block's position, then split the map into two parts at the highest block's position
    2. at the left part, let's say it is "height[0...highestBlockIndex-1]"
        if a block at i, can save some water above it's head, it must be another wall which positioned at it's left, and higher than it
        in another word, if a block at i, and all other block positioned left it, that means "height[0...i-1]" are lower than it
        it definitely can not save any water above on it's head!
    3. at the right part. V.V.

    so, the solution is:
        1. find the highest block's index "highestBlockIndex", split map into "height[0..highestBlockIndex-1]" and "height[highestBlockIndex+1..]"
        2. for "height[0..highestBlockIndex-1]", traverse it, in each iteration:
            1. if all left blocks is lower than current block, no water
            2. if there is some blocks higher than current block, find the highest block among them, 
               current block can save "2ndHighestBlock's height - current height" water
        3. for "height[highestBlockIndex+1..]", V.V

    */

    public class Solution
    {
        public int Trap(int[] height)
        {
            int totalWater = 0;

            int highestBlockIndex = 0;
            int highestBlockHeight = 0;
            for (int i = 0; i < height.Length; ++i)
            {
                if (height[i] > highestBlockHeight)
                {
                    highestBlockHeight = height[i];
                    highestBlockIndex = i;
                }
            }

            int secondHighestBlockHeight = 0;
            int secondHighestBlockIndex = 0;
            for (int i = 0; i < highestBlockIndex; ++i)
            {
                if (height[i] > secondHighestBlockHeight)
                {
                    secondHighestBlockHeight = height[i];
                    secondHighestBlockIndex = i;
                    continue;
                }

                totalWater += secondHighestBlockHeight - height[i];
            }

            secondHighestBlockHeight = 0;
            secondHighestBlockIndex = 0;
            for (int i = height.Length - 1; i > highestBlockIndex; --i)
            {
                if (height[i] > secondHighestBlockHeight)
                {
                    secondHighestBlockHeight = height[i];
                    secondHighestBlockIndex = i;
                    continue;
                }

                totalWater += secondHighestBlockHeight - height[i];
            }

            return totalWater;
        }
    }
}