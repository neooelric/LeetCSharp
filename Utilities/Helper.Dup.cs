using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Utilities
{
    public static partial class Helper
    {
        public static T[][] Dup2DArray<T>(T[][] twoDArray)
        {
            if (twoDArray == null)
            {
                return null;
            }
            return twoDArray.Select(arr => arr == null ? null : arr.ToArray()).ToArray();
        }

        public static T[] DupArray<T>(T[] array)
        {
            return array == null ? null : array.ToArray();
        }

        public static ListNode DupLinkedList(ListNode l)
        {
            if (l == null)
            {
                return l;
            }

            ListNode dupL = new ListNode(l.val, null);

            for (ListNode p = l.next, q = dupL; p != null; p = p.next, q = q.next)
            {
                q.next = new ListNode(p.val, null);
            }

            return dupL;
        }

        public static ListNode[] DupLinkedListArray(ListNode[] lists)
        {
            if (lists == null)
            {
                return null;
            }

            if (lists.Length == 0)
            {
                return new ListNode[0];
            }

            ListNode[] res = new ListNode[lists.Length];
            for (int i = 0; i < lists.Length; ++i)
            {
                res[i] = DupLinkedList(lists[i]);
            }

            return res;
        }
    }
}