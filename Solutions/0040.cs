using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0040
{
    /*
    this actually the same problem as 0039, we can use DFS+recall to solve this

    the train of thought is like:

        combinations;
        walkPath;
        for(int i = 0; i < candidates.Length; ++i)
        {
            1. add candidates[i] to walkPath
            2. recursive solve the sub problem : {candidates[i+1...], target-candidates[i]}
               and if this path can reach a legal result
               then at that deep call stack, add the walkPath's dup to combinations set
            3. pop out candidates[i] from walkPath
        }

    the difference between this problem and 0039 is : 
        0039 allows a candidates shows multiple times, but 0039 guaranteed that all candidates are distinct
        in this problem, each candidates may only be used once, but candidates are not guaranteed to be distinct

    this difference reflected on code:
        1. since this problem each candidate may only be used once, the subproblem's definition has a little bit difference
            this problem : {candidates[i+1...], target-candidates[i]}
            0039         : {candidates[i...],   target-candidates[i]}
        2. we have to sort candidates first, then in each iteration of the loop, 
           we have to skip the repeated number, since the candidates are sorted now
           this change can erase the repeated answer, like [1,7,1,7] with target 8
           if we do not sort and skip the repeated candidate, we'll got four answers
                [1, 7] with index [0,1]
                [1, 7] with index [0,3]
                [7, 1] with index [1,2]
                [1, 7] with index [2,3]
            if we sort the candidates and skip the repeated number when looping, we'll only get one answer
                [1, 1, 7, 7]
                [1, 7] with index [0, 1]
                then when looping to 1 with index 1, it'll skip
                so, [1, 7] with index [0, 1] is the only answer

    */

    public class Solution
    {
        private void DFSAndRecall(
            int[] candidates,
            int startIndex,
            int target,
            IList<int> currentCombination,
            IList<IList<int>> combinations
        )
        {
            if (target < 0)
            {
                return;
            }

            if (target == 0)
            {
                combinations.Add(currentCombination.ToList());
                return;
            }

            for (int i = startIndex; i < candidates.Length; ++i)
            {
                if (i > startIndex && candidates[i] == candidates[i - 1])
                {
                    continue;
                }
                currentCombination.Add(candidates[i]);
                DFSAndRecall(candidates, i + 1, target - candidates[i], currentCombination, combinations);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<IList<int>> combinations = new List<IList<int>>();
            List<int> currentCombination = new List<int>();

            DFSAndRecall(candidates, 0, target, currentCombination, combinations);

            return combinations;
        }
    }
}