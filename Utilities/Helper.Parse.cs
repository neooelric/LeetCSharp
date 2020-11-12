using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Utilities
{
    public static partial class Helper
    {
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

        public static char[] ParseCharArray(string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split(",");
            List<char> res = new List<char>();
            foreach (string elementStr in elementStrs)
            {
                if (string.IsNullOrEmpty(elementStr) || elementStr.Length < 2)
                {
                    continue;
                }
                res.Add(elementStr[1]);
            }

            return res.ToArray();
        }

        public static char[][] ParseChar2DArray(string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split("],");
            List<char[]> res = new List<char[]>();
            foreach (string elementStr in elementStrs)
            {
                if (string.IsNullOrEmpty(elementStr))
                {
                    continue;
                }
                if (elementStr.EndsWith("]"))
                {
                    res.Add(ParseCharArray(elementStr));
                }
                else
                {
                    res.Add(ParseCharArray(elementStr + "]"));
                }
            }

            return res.ToArray();
        }

        public static string[][] ParseString2DArray(string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split("],");
            List<string[]> res = new List<string[]>();
            foreach (string elementStr in elementStrs)
            {
                if (string.IsNullOrEmpty(elementStr))
                {
                    continue;
                }
                if (elementStr.EndsWith("]"))
                {
                    res.Add(ParseStringArray(elementStr));
                }
                else
                {
                    res.Add(ParseStringArray(elementStr + "]"));
                }
            }

            return res.ToArray();
        }


        public static string[] ParseStringArray(string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split(",");
            List<string> res = new List<string>();
            foreach (string elementStr in elementStrs)
            {
                if (string.IsNullOrEmpty(elementStr) || elementStr.Length < 2)
                {
                    continue;
                }
                res.Add(elementStr.Substring(1, elementStr.Length - 2));
            }
            return res.ToArray();
        }

        public static int[] ParseIntArray(string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split(",");
            List<int> res = new List<int>();
            foreach (string elementStr in elementStrs)
            {
                if (string.IsNullOrEmpty(elementStr))
                {
                    continue;
                }
                res.Add(int.Parse(elementStr));
            }

            return res.ToArray();
        }

        public static ListNode[] ParseLinkedListArray(string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split("],");
            List<ListNode> res = new List<ListNode>();
            foreach (string elementStr in elementStrs)
            {
                if (string.IsNullOrEmpty(elementStr))
                {
                    continue;
                }
                if (elementStr.EndsWith("]"))
                {
                    res.Add(ParseLinkedList(elementStr));
                }
                else
                {
                    res.Add(ParseLinkedList(elementStr + "]"));
                }
            }

            return res.ToArray();
        }

        public static int[][] ParseInt2DArray(string line)
        {
            string[] elementStrs = line.Substring(1, line.Length - 2).Split("],");
            List<int[]> res = new List<int[]>();
            foreach (string elementStr in elementStrs)
            {
                if (string.IsNullOrEmpty(elementStr))
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

        public static ListNode ParseLinkedList(string line)
        {
            ListNode head = null;
            ListNode tail = null;

            string[] elementStrs = line.Substring(1, line.Length - 2).Split(",");
            foreach (string elementStr in elementStrs)
            {
                if (string.IsNullOrEmpty(elementStr))
                {
                    continue;
                }

                int number = int.Parse(elementStr);
                if (head == null)
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
    }
}
