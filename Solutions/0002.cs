using System;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0002
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode resHead = null;
            ListNode resTail = null;

            int currentDigitSum = 0;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                if (l1 != null && l2 != null)
                {
                    currentDigitSum = l1.val + l2.val + carry;
                }
                else if (l1 == null && l2 == null)
                {
                    currentDigitSum = carry;
                }
                else
                {
                    currentDigitSum = (l1 != null ? l1.val : l2.val) + carry;
                }

                if (currentDigitSum >= 10)
                {
                    currentDigitSum %= 10;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }

                if (resHead == null)
                {
                    resHead = resTail = new ListNode(currentDigitSum, null);
                }
                else
                {
                    resTail.next = new ListNode(currentDigitSum, null);
                    resTail = resTail.next;
                }

                if (l1 != null)
                {
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }

            return resHead;
        }
    }
}