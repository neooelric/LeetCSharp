using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0023
{
    /*
    maintain a cursor for each list of K lists, so we got K cursor at first
    and each cursor is point to each lists' head node at the beginning

    then loop, in each loop:
        1. find the cursor who have the minimum val : min-cursor
        2. add node pointed by min-cursor to our result list
        3. if the node we just added to result, has a "next", then move min-cursor to point to that "next" node
           else, just delete the cursor from cursor set
        4. when cursor set is empty, break the loop, problem solved

    we can use SortedDictionary as the "cursor set", it has a great advantage: SortedDictionary are naturally sorted by element's Key

    it made the operation #2 mentioned above to O(log(n)), instead of traverse all cursors O(n) to find out who is the minimum

    */

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode res = null;
            ListNode resTail = null;

            SortedDictionary<int, List<ListNode>> candidateNodes = new SortedDictionary<int, List<ListNode>>();

            for(int i= 0; i < lists.Length; ++i)
            {
                ListNode node = lists[i];

                if(node == null)
                {
                    continue;
                }

                if(!candidateNodes.ContainsKey(node.val))
                {
                    candidateNodes.Add(node.val, new List<ListNode>());
                }

                candidateNodes[node.val].Add(node);
            }

            while(candidateNodes.Count != 0)
            {
                int candidateNodeVal = candidateNodes.First().Key;
                List<ListNode> minValNodesList = candidateNodes.First().Value;

                ListNode nodeToBeAddedToRes = minValNodesList.Last();

                if(res == null)
                {
                    res = nodeToBeAddedToRes;
                    resTail = nodeToBeAddedToRes;
                }
                else
                {
                    resTail.next = nodeToBeAddedToRes;
                    resTail = resTail.next;
                }

                if(minValNodesList.Count == 1)
                {
                    candidateNodes.Remove(candidateNodeVal);
                }
                else
                {
                    minValNodesList.RemoveAt(minValNodesList.Count - 1);
                }

                if(nodeToBeAddedToRes.next != null)
                {
                    ListNode newCandidate = nodeToBeAddedToRes.next;

                    if(!candidateNodes.ContainsKey(newCandidate.val))
                    {
                        candidateNodes.Add(newCandidate.val, new List<ListNode>());
                    }

                    candidateNodes[newCandidate.val].Add(newCandidate);
                }
            }

            return res;
        }
    }
}