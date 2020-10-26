
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0016
{
    /*
    the most simple train of thought is:
        1. 3-level nested traverse the array with index i, j, k, and let A = nums[i], B = nums[j], C = nums[k]
        2. sum A, B, C up, find out the closet summation to target

    the problems of this thought is:
        some loop are not necessary, like in array [1,2,3,2], (i, j, k) == (0,1,2) and (0,2,3) actually is the same
    

    Sort() the array first, is a very good optimize way
        because the array is sorted, so array like [1,2,3,2] could become [1,2,2,3], so then we can skip some unnucessary iteration
    */

    public class Solution
    {
        public int ThreeSumClosest(int[] nums, int target) 
        {
            int res = target;
            Array.Sort(nums);
            for(int i = 0; i < nums.Length; ++i)
            {
                if(i > 0 && nums[i-1] == nums[i])
                {
                    continue;
                }

                int A = nums[i];

                for(int j = i + 1; j < nums.Length; ++j)
                {
                    if(j > i + 1 && nums[j-1] == nums[j])
                    {
                        continue;
                    }
                    int B = nums[j];

                    for(int k = j + 1; k < nums.Length; ++k)
                    {
                        if(k > j + 1 && nums[k-1] == nums[k])
                        {
                            continue;
                        }

                        int C = nums[k];

                        if(A+B+C == target)
                        {
                            return target;
                        }

                        if(res == target || Math.Abs(A+B+C-target) < Math.Abs(res-target))
                        {
                            res = A + B + C;
                        }
                    }
                }
            }
            return res;
        }
    }
}
