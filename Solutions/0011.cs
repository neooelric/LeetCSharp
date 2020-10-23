
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0011
{
    /*
    This problem is not about your basic known of Algorithm or Basic Datas Structures
    It's about brain twist.

    here is the logic:
    
    set two walls, "left" and "right", iterate "left" from 0 to bigger, iterate "right" from "height.Length - 1" to smaller

    during iteration, we'll count many possible answer, just choose the biggest one.

    the key concept is:
        assume "left" and "right" now is among our iteration
        if(leftWall higher than rightWall) {
            then in order to get a more biggest answer, you have to change the rightWall, no other choice
            because change leftWall doesn't help
        }
        vice versa

    it use a strategy called "greedy"
    */

    public class Solution
    {
        public int MaxArea(int[] height)
        {
            int maxArea = 0;

            for(int left = 0, right = height.Length - 1; left < right;)
            {
                int currentArea = (right - left) * (height[left] < height[right] ? height[left] : height[right]);
                if(currentArea > maxArea)
                {
                    maxArea = currentArea;
                }

                if(height[left] < height[right])
                {
                    ++left;
                }
                else
                {
                    --right;
                }
            }

            return maxArea;
        }
    }
}
