using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Utilities
{
    public class Helper
    {
        public static bool LinkedListEquals(ListNode l1, ListNode l2)
        {
            if(l1 == null && l2 == null)
            {
                return true;
            }

            if(l1 == null || l2 == null)
            {
                return false;
            }

            while(l1 != null && l2 != null)
            {
                if(l1.val != l2.val)
                {
                    return false;
                }

                l1 = l1.next;
                l2 = l2.next;
            }

            if(l1 == null && l2 == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IntArrayEqualsRegardlessOfOrder(int[] arrA, int[] arrB)
        {
            if(arrA.Length != arrB.Length)
            {
                return false;
            }

            List<int> listA = new List<int>(arrA);
            List<int> listB = new List<int>(arrB);

            listA.Sort();
            listB.Sort();

            return Enumerable.SequenceEqual(listA, listB);
        }

        public static bool IntArrayEquals(int[] arrA, int[] arrB)
        {
            if(arrA.Length != arrB.Length)
            {
                return false;
            }

            List<int> listA = new List<int>(arrA);
            List<int> listB = new List<int>(arrB);

            return Enumerable.SequenceEqual(listA, listB);
        }

        public static bool DoubleEquals(double a, double b)
        {
            return Math.Abs(a - b) < 0.00000001;
        }

        public static int[] StringToIntArray (string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split(",");
            List<int> res = new List<int>();
            foreach(string elementStr in elementStrs) {
                if(string.IsNullOrEmpty(elementStr))
                {
                    continue;
                }
                res.Add(int.Parse(elementStr));
            }

            return res.ToArray();
        }

        public static string IntArrayToString (int[] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for(int i = 0; i < array.Length; ++i)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }

                sb.AppendFormat("{0}", array[i]);
            }
            
            sb.Append("]");

            return sb.ToString();
        }

        public static ListNode StringToLinkedList(string line)
        {
            ListNode head = null;
            ListNode tail = null;

            string[] elementStrs = line.Substring(1, line.Length - 2).Split(",");
            foreach(string elementStr in elementStrs) {
                int number = int.Parse(elementStr);
                if(head == null)
                {
                    tail = head = new ListNode(number, null);
                }
                else
                {
                    tail.next = new ListNode(number, null);
                    tail = tail.next;
                }
            }

            return head;
        }

        public static string LinkedListToString(ListNode head)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for(ListNode i = head; i != null; i = i.next)
            {
                if(i != head)
                {
                    sb.Append(",");
                }

                sb.AppendFormat("{0}", i.val);
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}