using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Utilities
{
    public static partial class Helper
    {
        public static bool ValueEquals<T>(T left, T right)
        {
            if (Nullable.GetUnderlyingType(typeof(T)) != null)
            {
                if (left == null && right == null)
                {
                    return true;
                }
                if (left == null || right == null)
                {
                    return false;
                }
            }

            return Comparer<T>.Default.Compare(left, right) == 0;
        }

        public static bool ListEquals(ListNode l1, ListNode l2)
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

        public static bool ArrayEquals<T>(T[] left, T[] right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            for (int i = 0; i < left.Length; ++i)
            {
                if (!ValueEquals<T>(left[i], right[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ArrayEqualsRegardlessOfOrder<T>(T[] left, T[] right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            T[] dupLeft = DupArray(left);
            T[] dupRight = DupArray(right);

            Array.Sort(dupLeft);
            Array.Sort(dupRight);

            return ArrayEquals(dupLeft, dupRight);
        }

        public static bool TwoDArrayEquals<T>(T[][] left, T[][] right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            if (left == null || right == null)
            {
                return false;
            }
            if (left.Length != right.Length)
            {
                return false;
            }
            for (int i = 0; i < left.Length; ++i)
            {
                if (!ArrayEquals<T>(left[i], right[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool TwoDArrayEqualsRegardlessOfOuterOrder<T>(T[][] left, T[][] right)
        {
            return TwoDArrayEqualsRegardlessOfOrder(left, right, true);
        }

        public static bool TwoDArrayEqualsRegardlessOfOuterOrder<T>(IList<IList<T>> leftList, T[][] right)
        {
            if (leftList == null && right == null)
            {
                return true;
            }
            if (leftList == null || right == null)
            {
                return false;
            }
            if (leftList.Count != right.Length)
            {
                return false;
            }

            T[][] left = new T[leftList.Count][];

            for (int i = 0; i < leftList.Count; ++i)
            {
                left[i] = leftList[i] == null ? null : leftList[i].ToArray();
            }

            return TwoDArrayEqualsRegardlessOfOuterOrder(left, right);
        }

        public static bool TwoDArrayEqualsRegardlessOfOrder<T>(T[][] left, T[][] right)
        {
            return TwoDArrayEqualsRegardlessOfOrder(left, right, false);
        }

        public static bool TwoDArrayEqualsRegardlessOfOrder<T>(IList<IList<T>> leftList, T[][] right)
        {
            if (leftList == null && right == null)
            {
                return true;
            }
            if (leftList == null || right == null)
            {
                return false;
            }
            if (leftList.Count != right.Length)
            {
                return false;
            }

            T[][] left = new T[leftList.Count][];

            for (int i = 0; i < leftList.Count; ++i)
            {
                left[i] = leftList[i] == null ? null : leftList[i].ToArray();
            }

            return TwoDArrayEqualsRegardlessOfOrder(left, right);
        }

        private static bool TwoDArrayEqualsRegardlessOfOrder<T>(T[][] left, T[][] right, bool onlyOuterOrder)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            T[][] dupLeft = Dup2DArray(left);
            T[][] dupRight = Dup2DArray(right);

            IComparer<T[]> comparer = Comparer<T[]>.Create((T[] left, T[] right) =>
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
                    int res = Comparer<T>.Default.Compare(left[i], right[i]);
                    if (res != 0)
                    {
                        return res;
                    }
                }

                return 0;
            });

            Array.Sort(dupLeft, comparer);
            Array.Sort(dupRight, comparer);

            for (int i = 0; i < dupLeft.Length; ++i)
            {
                if (onlyOuterOrder)
                {
                    if (!ArrayEquals(dupLeft[i], dupRight[i]))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!ArrayEqualsRegardlessOfOrder(dupLeft[i], dupRight[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool TwoDArrayEqualsRegardlessOfOrder<T>(IList<IList<T>> leftList, T[][] right, bool onlyOuterOrder)
        {
            if (leftList == null && right == null)
            {
                return true;
            }
            if (leftList == null || right == null)
            {
                return false;
            }
            if (leftList.Count != right.Length)
            {
                return false;
            }

            T[][] left = new T[leftList.Count][];

            for (int i = 0; i < leftList.Count; ++i)
            {
                left[i] = leftList[i] == null ? null : leftList[i].ToArray();
            }

            return TwoDArrayEqualsRegardlessOfOrder(left, right, onlyOuterOrder);
        }
    }
}
