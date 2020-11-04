using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0039
{
    /*
    we'll use DFS+recall to solve this problem

    actually we've already used DFS in problem 37(solve soduko problem), but we just call it "recursive"

    the train of thought is:
        1. sort the candidates
        2. use recursive to get a result combination
            for problem { candidates[0..length] , target }, 
                first, we try to add candidate[0] to combination set,
                then the problem become { candidates[0..length] , target - candidate[0]}
                    if the sub problem has no answer, then pop out candidate[0] from combination set
                    else, we must got a full combination set at the deepest recursive calling stack

                then, we can try to add candidate[1] to combination set
                then the problem become { candidates[1..length] , target - candidate[1]) }

                ...
                at last, we can try to add candidate[length-1] to combination set
                then the problem become { candidates[length-1] , target - candidate[length-1] }


    so, the difference between DFS+recall and simple recursive is :
        1. in DFS, we have to store the processing status at each level of recursive call
        2. when we find out that a recursive branch is bad, we need to erase the wrong step from our processing status store
        3. when the recursive calling reach the success end, we have to store the whole processing status
    
    or name the "processing status" as "walking path" could more understandable
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
                currentCombination.Add(candidates[i]);
                DFSAndRecall(candidates, i, target - candidates[i], currentCombination, combinations);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> combinations = new List<IList<int>>();
            List<int> currentCombination = new List<int>();

            DFSAndRecall(candidates, 0, target, currentCombination, combinations);

            return combinations;
        }
    }
}