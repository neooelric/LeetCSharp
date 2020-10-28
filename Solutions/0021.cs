
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0021
{
    /*
    pretty simple linked list operation
    */

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode res = null;
            ListNode resTail = null;

            ListNode p = l1;
            ListNode q = l2;
            while(p != null && q != null)
            {
                ListNode tmp = null;
                if(p.val <= q.val)
                {
                    tmp = p;
                    p = p.next;
                }
                else
                {
                    tmp = q;
                    q = q.next;
                }

                tmp.next = null;

                if(res == null)
                {
                    res = tmp;
                    resTail = tmp;
                }
                else
                {
                    resTail.next = tmp;
                    resTail = resTail.next;
                }
            }

            if(p != null || q != null)
            {
                ListNode lastPart = (p != null) ? p : q;

                if (res != null)
                {
                    resTail.next = lastPart;
                }
                else
                {
                    res = lastPart;
                }
            }

            return res;
        }
    }
}
