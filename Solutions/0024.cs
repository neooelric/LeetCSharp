using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0024
{
    /*
    pretty simple and basic linked list operation
    */

    public class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            for(
                ListNode p = head, prev = null; 
                p != null && p.next != null;
                p = p.next)
            {
                ListNode q = p.next;

                p.next = q.next;
                q.next = p;

                if(prev != null)
                {
                    prev.next = q;
                }
                else
                {
                    head = q;
                }
                
                prev = p;
            }

            return head;
        }
    }
}