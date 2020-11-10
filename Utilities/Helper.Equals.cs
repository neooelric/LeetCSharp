using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Utilities
{
    public static partial class Helper
    {
        public static bool Equals(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return true;
            }

            if (l1 == null || l2 == null)
            {
                return false;
            }

            while (l1 != null && l2 != null)
            {
                if (l1.val != l2.val)
                {
                    return false;
                }

                l1 = l1.next;
                l2 = l2.next;
            }

            if (l1 == null && l2 == null)
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
            if (arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if (arrA.Length != arrB.Length)
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
            if (arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if (arrA.Length != arrB.Length)
            {
                return false;
            }

            List<string> listA = new List<string>(arrA);
            List<string> listB = new List<string>(arrB);

            listA.Sort();
            listB.Sort();

            for (int i = 0; i < listA.Count; ++i)
            {
                if (!Equals(listA[i], listB[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Int2DArrayEqualsRegardlessOfOuterOrder(IList<IList<int>> IListArrA, int[][] arrB)
        {
            if (IListArrA == null && arrB == null)
            {
                return true;
            }
            if (IListArrA == null || arrB == null)
            {
                return false;
            }

            List<int[]> IListIntArrA = new List<int[]>();
            foreach (IList<int> subArr in IListArrA)
            {
                IListIntArrA.Add(subArr.ToArray());
            }

            return Int2DArrayEqualsRegardlessOfOuterOrder(IListIntArrA.ToArray(), arrB);
        }

        public static bool Int2DArrayEqualsRegardlessOfOuterOrder(int[][] arrA, int[][] arrB)
        {
            if (arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if (arrA.Length != arrB.Length)
            {
                return false;
            }

            List<int[]> listA = new List<int[]>(arrA);
            List<int[]> listB = new List<int[]>(arrB);

            IComparer<int[]> comparer = Comparer<int[]>.Create((int[] left, int[] right) =>
            {
                if (left == null && right == null)
                {
                    return 0;
                }
                if (left == null || right == null)
                {
                    return left == null ? -1 : 1;
                }
                if (left.Length != right.Length)
                {
                    return left.Length - right.Length;
                }
                for (int i = 0; i < left.Length; ++i)
                {
                    int res = left[i] - right[i];
                    if (res != 0)
                    {
                        return res;
                    }
                }

                return 0;
            });

            listA.Sort(comparer);
            listB.Sort(comparer);

            for (int i = 0; i < listA.Count; ++i)
            {
                if (!Equals(listA[i], listB[i]))
                {
                    return false;
                }
            }

            return true;

        }

        public static bool Int2DArrayEqualsRegardlessOfOrder(IList<IList<int>> IListArrA, int[][] arrB)
        {
            if (IListArrA == null && arrB == null)
            {
                return true;
            }
            if (IListArrA == null || arrB == null)
            {
                return false;
            }

            List<int[]> IListIntArrA = new List<int[]>();
            foreach (IList<int> subArr in IListArrA)
            {
                IListIntArrA.Add(subArr.ToArray());
            }

            return Int2DArrayEqualsRegardlessOfOrder(IListIntArrA.ToArray(), arrB);
        }

        public static bool Int2DArrayEqualsRegardlessOfOrder(int[][] arrA, int[][] arrB)
        {
            if (arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if (arrA.Length != arrB.Length)
            {
                return false;
            }

            List<int[]> listA = new List<int[]>(arrA);
            List<int[]> listB = new List<int[]>(arrB);

            IComparer<int[]> comparer = Comparer<int[]>.Create((int[] left, int[] right) =>
            {
                if (left == null && right == null)
                {
                    return 0;
                }
                if (left == null || right == null)
                {
                    return left == null ? -1 : 1;
                }
                if (left.Length != right.Length)
                {
                    return left.Length - right.Length;
                }
                for (int i = 0; i < left.Length; ++i)
                {
                    int res = left[i] - right[i];
                    if (res != 0)
                    {
                        return res;
                    }
                }

                return 0;
            });

            listA.Sort(comparer);
            listB.Sort(comparer);

            for (int i = 0; i < listA.Count; ++i)
            {
                if (!IntArrayEqualsRegardlessOfOrder(listA[i], listB[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Equals(int[] arrA, int[] arrB)
        {
            if (arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if (arrA.Length != arrB.Length)
            {
                return false;
            }

            List<int> listA = new List<int>(arrA);
            List<int> listB = new List<int>(arrB);

            return Enumerable.SequenceEqual(listA, listB);
        }

        public static bool Equals(string[] arrA, int[] arrB)
        {
            if (arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if (arrA.Length != arrB.Length)
            {
                return false;
            }

            for (int i = 0; i < arrA.Length; ++i)
            {
                if (!Equals(arrA[i], arrB[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Equals(int[][] arrA, int[][] arrB)
        {
            if (arrA == null && arrB == null)
            {
                return true;
            }
            if (arrA == null || arrB == null)
            {
                return false;
            }

            if (arrA.Length != arrB.Length)
            {
                return false;
            }

            for (int i = 0; i < arrA.Length; ++i)
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
    }
}
