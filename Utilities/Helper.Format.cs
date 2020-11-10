using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Utilities
{
    public static partial class Helper
    {
        public static string FormatLinkedList(ListNode head)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (ListNode i = head; i != null; i = i.next)
            {
                if (i != head)
                {
                    sb.Append(",");
                }

                sb.AppendFormat("{0}", i.val);
            }

            sb.Append("]");

            return sb.ToString();
        }

        public static string FormatLinkedListArray(ListNode[] lists)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < lists.Length; ++i)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }

                sb.AppendFormat("{0}", FormatLinkedList(lists[i]));
            }

            sb.Append("]");

            return sb.ToString();
        }

        public static string FormatStringArray(string[] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < array.Length; ++i)
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

        public static string FormatChar2DArray(char[][] array)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            for (int i = 0; i < array.Length; ++i)
            {
                if (i != 0)
                {
                    sb.AppendLine();
                    sb.Append(",");
                }

                sb.Append(FormatCharArray(array[i]));
            }

            sb.Append("]");

            return sb.ToString();
        }

        public static string FormatCharArray(char[] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < array.Length; ++i)
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

        public static string FormatIntArray(int[] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            for (int i = 0; i < array.Length; ++i)
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

            for (int i = 0; i < array.Count; ++i)
            {
                if (i != 0)
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

            for (int i = 0; i < array.Length; ++i)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }

                sb.Append(FormatIntArray(array[i]));
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}