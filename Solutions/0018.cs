
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0018
{
    /*
    sort the nums first, then traverse numbers like this:
        for(int i = 0; i < nums.Length; ++i)
        {
            int A = nums[i];
            int B, C, D = ThreeSum(nums[i+1, ..], target-A);
        }
    
    now we downgrade a FourSum problem to multiple ThreeSum problem
    for ThreeSum problem, you can use the same trick to downgrade it to multiple TwoSum problem

        for(int j = i+1; j < nums.Length; ++j)
        {
            int B = nums[i+1];
            int C, D = TwoSum(nums[j+1, ..], target-A-B);
        }

    for TwoSum problem, you can use Dictionary to solve, or use algorithm like below:
        for(int left = j+1, right = nums.Length-1; left < right; )
        {
            int C = nums[left];
            int D = nums[right];
            if(C+D > target-A-B)
            {
                right--;
            }
            if(C+D < target-A-B)
            {
                left++;
            }
        }

    tip:
        please carefully handle the repeated numbers
    */

    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; ++i)
            {
                int A = nums[i];
                if(i > 0 && nums[i] == nums[i-1])
                {
                    continue;
                }

                for (int j = i + 1; j < nums.Length; ++j)
                {
                    int B = nums[j];
                    if(j > i + 1 && nums[j] == nums[j-1])
                    {
                        continue;
                    }

                    for(int left = j+1,right = nums.Length-1; left < right;)
                    {
                        int C = nums[left];
                        int D = nums[right];

                        if(left > j+1 && nums[left] == nums[left-1])
                        {
                            left++;
                            continue;
                        }

                        if(right < nums.Length-1 && nums[right] == nums[right+1])
                        {
                            right--;
                            continue;
                        }

                        if(C+D > target -A-B)
                        {
                            right--;
                        }
                        else if(C+D < target -A-B)
                        {
                            left++;
                        }
                        else
                        {
                            res.Add(new List<int> { A,B,C,D});
                            left++;
                            right--;
                        }
                    }

                }
            }

            return res;
        }
    }
}
