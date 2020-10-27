
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0019
{
    /*
    if you dont use extra facility to record the mapping relationship between node and index
    you have to traverse the list twice : once for calc the length of list, the other for locate the node which to be delete

    */

    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            List<ListNode> nodes = new List<ListNode>();

            for(ListNode i = head; i != null; i = i.next)
            {
                nodes.Add(i);
            }

            if(n > nodes.Count)
            {
                return head;
            }

            if(n == nodes.Count)
            {
                return head.next;
            }

            ListNode tobeDeleteNode = nodes[nodes.Count - n];
            ListNode tobeDeletePrevNode = nodes[nodes.Count - n - 1];

            tobeDeletePrevNode.next = tobeDeleteNode.next;

            return head;
        }
    }
}
