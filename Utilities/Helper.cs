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
            if(arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

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

        public static bool StringArrayEqualsRegardlessOfOrder(string[] arrA, string[] arrB)
        {
            if(arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if(arrA.Length != arrB.Length)
            {
                return false;
            }

            List<string> listA = new List<string>(arrA);
            List<string> listB = new List<string>(arrB);

            listA.Sort();
            listB.Sort();

            for(int i = 0; i < listA.Count; ++i)
            {
                if(!Equals(listA[i], listB[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Int2DArrayEqualsRegardlessOfOrder(IList<IList<int>> IListArrA, int[][] arrB)
        {
            if(IListArrA == null && arrB == null)
            {
                return true;
            }
            if (IListArrA == null || arrB == null)
            {
                return false;
            }

            List<int[]> IListIntArrA = new List<int[]>();
            foreach(IList<int> subArr in IListArrA)
            {
                IListIntArrA.Add(subArr.ToArray());
            }

            return Int2DArrayEqualsRegardlessOfOrder(IListIntArrA.ToArray(), arrB);
        }

        public static bool Int2DArrayEqualsRegardlessOfOrder(int[][] arrA, int[][] arrB)
        {
            if(arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if(arrA.Length != arrB.Length)
            {
                return false;
            }

            List<int[]> listA = new List<int[]>(arrA);
            List<int[]> listB = new List<int[]>(arrB);

            IComparer<int[]> comparer = Comparer<int[]>.Create((int[] left, int[] right) =>
            {
                if(left == null && right == null)
                {
                    return 0;
                }
                if(left == null || right == null)
                {
                    return left == null ? -1 : 1;
                }
                if(left.Length != right.Length)
                {
                    return left.Length - right.Length;
                }
                for(int i = 0; i < left.Length; ++i)
                {
                    int res = left[i] - right[i];
                    if(res != 0)
                    {
                        return res;
                    }
                }

                return 0;
            });

            listA.Sort(comparer);
            listB.Sort(comparer);

            for(int i = 0; i < listA.Count; ++i)
            {
                if(!IntArrayEqualsRegardlessOfOrder(listA[i], listB[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Equals(int[] arrA, int[] arrB)
        {
            if(arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if(arrA.Length != arrB.Length)
            {
                return false;
            }

            List<int> listA = new List<int>(arrA);
            List<int> listB = new List<int>(arrB);

            return Enumerable.SequenceEqual(listA, listB);
        }

        public static bool Equals(string[] arrA, int[] arrB)
        {
            if(arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if(arrA.Length != arrB.Length)
            {
                return false;
            }

            for(int i = 0; i < arrA.Length; ++i)
            {
                if (!Equals(arrA[i], arrB[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Equals(double a, double b)
        {
            return Math.Abs(a - b) < 0.00000001;
        }

        public static bool Equals(string a, string b)
        {
            return string.Compare(a, b) == 0;
        }

        public static bool Equals(int a, int b)
        {
            return a == b;
        }

        public static bool Equals(bool a, bool b)
        {
            return a == b;
        }

        public static string ParseString(string line)
        {
            return line.Substring(1, line.Length - 2);
        }

        public static int ParseInt(string line)
        {
            return int.Parse(line);
        }

        public static double ParseDouble(string line)
        {
            return double.Parse(line);
        }

        public static bool ParseBool(string line)
        {
            return bool.Parse(line);
        }

        public static string[] ParseStringArray(string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split(",");
            List<string> res = new List<string>();
            foreach (string elementStr in elementStrs)
            {
                if(string.IsNullOrEmpty(elementStr) || elementStr.Length < 2)
                {
                    continue;
                }
                res.Add(elementStr.Substring(1, elementStr.Length - 2));
            }
            return res.ToArray();
        }

        public static int[] ParseIntArray (string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split(",");
            List<int> res = new List<int>();
            foreach(string elementStr in elementStrs) 
            {
                if(string.IsNullOrEmpty(elementStr))
                {
                    continue;
                }
                res.Add(int.Parse(elementStr));
            }

            return res.ToArray();
        }

        public static int[][] ParseInt2DArray(string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split("],");
            List<int[]> res = new List<int[]>();
            foreach(string elementStr in elementStrs) 
            {
                if(string.IsNullOrEmpty(elementStr))
                {
                    continue;
                }
                if (elementStr.EndsWith("]"))
                {
                    res.Add(ParseIntArray(elementStr));
                }
                else
                {
                    res.Add(ParseIntArray(elementStr + "]"));
                }
            }

            return res.ToArray();

        }

        public static string FormatStringArray(string[] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for(int i = 0; i < array.Length; ++i)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }

                sb.AppendFormat("\"{0}\"", array[i]);
            }
            
            sb.Append("]");

            return sb.ToString();
        }

        public static string FormatIntArray (int[] array)
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

        public static string FormatInt2DArray(IList<IList<int>> array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for(int i = 0; i < array.Count; ++i)
            {
                if(i != 0)
                {
                    sb.Append(",");
                }

                sb.Append(FormatIntArray(array[i].ToArray()));
            }

            sb.Append("]");

            return sb.ToString();

        }

        public static string FormatInt2DArray(int[][] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for(int i = 0; i < array.Length; ++i)
            {
                if(i != 0)
                {
                    sb.Append(",");
                }

                sb.Append(FormatIntArray(array[i]));
            }

            sb.Append("]");

            return sb.ToString();
        }

        public static ListNode ParseLinkedList(string line)
        {
            ListNode head = null;
            ListNode tail = null;

            string[] elementStrs = line.Substring(1, line.Length - 2).Split(",");
            foreach(string elementStr in elementStrs) 
            {
                if(string.IsNullOrEmpty(elementStr))
                {
                    continue;
                }

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

        public static string FormatLinkedList(ListNode head)
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