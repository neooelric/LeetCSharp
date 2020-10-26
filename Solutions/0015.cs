
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0015
{
    /*
    sort nums first, then traverse the sorted numbers

    here is the logic, during loop like below:
        for(int i = 0; i < nums.Length; ++i}
        {
            int A = nums[i];
            // ...
        }

    the problem actually became: in each loop iteration, find two numbers, B and C, which 
        1. sum equals -A
        2. nums[i] itself must not be any of these two numbers (they can be equals, but can not be the same number)
        3. B and C not a same number (they can be equals, but can not be the same number)

    and because nums are sorted, B&C must located after i if they are exists, that means, you have to find it out in nums[i+1, ..]

    */

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<int> listNums = nums.ToList();

            listNums.Sort();

            List<IList<int>> res = new List<IList<int>>();

            for(int i = 0; i < listNums.Count; ++i)
            {
                if(i > 0 && listNums[i-1] == listNums[i])
                {
                    continue;
                }

                int A = listNums[i];

                int left = i + 1;
                int right = listNums.Count - 1;

                while(left < right)
                {
                    int B = listNums[left];
                    int C = listNums[right];

                    if(B + C == -A)
                    {
                        res.Add(new List<int> { A, B, C });
                        do { left++; } while (left < listNums.Count && listNums[left] == B);
                        do { right--; } while (right > i && listNums[right] == C);
                    }
                    else if (B + C > -A)
                    {
                        do { right--; } while (right > i && listNums[right] == C);
                    }
                    else if(B+C < -A)
                    {
                        do { left++; } while (left < listNums.Count && listNums[left] == B);
                    }
                }
            }

            return res;
        }

    }
}
