using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0025
{
    /*
    pretty simple and basic linked list operation

    tips: use a stack to store the k nodes need to reverse in each iteration
    */

    public class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            for(ListNode prev=null, p = head; p != null; p = p.next)
            {
                Stack<ListNode> s = new Stack<ListNode>();

                ListNode q = p;
                while(q != null && s.Count != k) 
                {
                    s.Push(q);
                    q = q.next;
                }

                if(s.Count != k)
                {
                    break;
                }

                if(prev != null)
                {
                    prev.next = s.Peek();
                }
                else
                {
                    head = s.Peek();
                }

                while (s.Count != 0)
                {
                    ListNode tmp = s.Pop();
                    tmp.next = s.Count == 0 ? q : s.Peek();
                }

                prev = p;
            }

            return head;
        }
    }
}