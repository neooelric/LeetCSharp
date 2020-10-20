using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions._0001
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] res = new int[2];

            Dictionary<int, List<int>> indexesOfNumber = new Dictionary<int, List<int>>();

            for (int index = 0; index < nums.Length; ++index)
            {
                int numberA = nums[index];
                if (indexesOfNumber.ContainsKey(numberA))
                {
                    indexesOfNumber[numberA].Add(index);
                }
                else
                {
                    indexesOfNumber.Add(numberA, new List<int> { index });
                }

                int numberB = target - numberA;

                if (!indexesOfNumber.ContainsKey(numberB))
                {
                    continue;
                }

                List<int> numberAIndexes = indexesOfNumber[numberA];
                List<int> numberBIndexes = indexesOfNumber[numberB];

                if (numberAIndexes == numberBIndexes && numberAIndexes.Count < 2)
                {
                    continue;
                }

                res[0] = numberAIndexes.First();
                res[1] = numberBIndexes.Last();
                break;
            }

            return res;
        }
    }
}
