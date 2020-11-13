using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0051
{
    /*
    N-Queens problem is a very classic problem, you can find many algorithms on internet to solve it.

    i'll gonna use the most straightforward way : DFS

    i'll use a hashset to store all currently legal positions, a trick is to encode the row and col, two numbers, encode them into one number

        since the problem didn't give a constraint about N, although we all know N-Queens problem's will extremly complex when N is very large
        but i'll just assume that N will in the range of [1, int.MAX_VALUE]
        so the element type of hashset will be unsigned long

    then at each row, pick a col as queen's position, recursively DFS all possible cols

    tips:
        1. in N-Queens problem, each row must have a queen, and each col must have a queen
           that's why our DFS logic is to "find the right col in next row", instead of "find next legal position"

    */

    public class Solution
    {



        private UInt64 EncodeRowAndCol(int row, int col)
        {
            UInt64 u64row = (UInt64)(row);
            UInt64 u64col = (UInt64)(col);
            return (u64row << 32) | u64col;
        }

        private void DecodeRowAndCol(UInt64 code, out int row, out int col)
        {
            row = (int)((code & 0xffffffff00000000) >> 32);
            col = (int)(code & 0x00000000ffffffff);
        }

        private HashSet<UInt64> NewBag(int n)
        {
            HashSet<UInt64> bag = new HashSet<UInt64>();

            for (int row = 0; row < n; ++row)
            {
                for (int col = 0; col < n; ++col)
                {
                    bag.Add(EncodeRowAndCol(row, col));
                }
            }

            return bag;
        }

        private HashSet<UInt64> DupBag(HashSet<UInt64> bag)
        {
            return new HashSet<UInt64>(bag);
        }

        private HashSet<UInt64> EraseIllegalPositionsFromBag(HashSet<UInt64> bag, int n, int row, int col)
        {
            HashSet<UInt64> erased = new HashSet<UInt64>();

            if (bag.Remove(EncodeRowAndCol(row, col)))
            {
                erased.Add(EncodeRowAndCol(row, col));
            }

            for (int i = 0; i < n; ++i)
            {
                if (bag.Remove(EncodeRowAndCol(row, i)))
                {
                    erased.Add(EncodeRowAndCol(row, i));
                }
                if (bag.Remove(EncodeRowAndCol(i, col)))
                {
                    erased.Add(EncodeRowAndCol(i, col));
                }
            }

            int[] r = new int[4] { row, row, row, row };
            int[] c = new int[4] { col, col, col, col };
            while (true)
            {
                bool eraseHappen = false;
                if (r[0] + 1 < n && c[0] + 1 < n)
                {
                    r[0]++;
                    c[0]++;
                    if (bag.Remove(EncodeRowAndCol(r[0], c[0])))
                    {
                        erased.Add(EncodeRowAndCol(r[0], c[0]));
                    }
                    eraseHappen = true;
                }

                if (r[1] + 1 < n && c[1] - 1 >= 0)
                {
                    r[1]++;
                    c[1]--;
                    if (bag.Remove(EncodeRowAndCol(r[1], c[1])))
                    {
                        erased.Add(EncodeRowAndCol(r[1], c[1]));
                    }
                    eraseHappen = true;
                }

                if (r[2] - 1 >= 0 && c[2] + 1 < n)
                {
                    r[2]--;
                    c[2]++;
                    if (bag.Remove(EncodeRowAndCol(r[2], c[2])))
                    {
                        erased.Add(EncodeRowAndCol(r[2], c[2]));
                    }
                    eraseHappen = true;
                }

                if (r[3] - 1 >= 0 && c[3] - 1 >= 0)
                {
                    r[3]--;
                    c[3]--;
                    if (bag.Remove(EncodeRowAndCol(r[3], c[3])))
                    {
                        erased.Add(EncodeRowAndCol(r[3], c[3]));
                    }
                    eraseHappen = true;
                }

                if (!eraseHappen)
                {
                    break;
                }
            }

            return erased;
        }

        private void DFSAndRecall(
            int n,
            HashSet<HashSet<UInt64>> allSolutions,
            HashSet<UInt64> solution,
            int row,
            int col,
            HashSet<UInt64> bag
        )
        {
            solution.Add(EncodeRowAndCol(row, col));

            HashSet<UInt64> erasedPositions = EraseIllegalPositionsFromBag(bag, n, row, col);

            if (solution.Count == n)
            {
                allSolutions.Add(solution.ToHashSet());
                solution.Remove(EncodeRowAndCol(row, col));
                bag.UnionWith(erasedPositions);
                return;
            }

            if (bag.Count == 0)
            {
                solution.Remove(EncodeRowAndCol(row, col));
                bag.UnionWith(erasedPositions);
                return;
            }

            for (int i = 0; i < n; ++i)
            {
                if (!bag.Contains(EncodeRowAndCol(row + 1, i)))
                {
                    continue;
                }
                DFSAndRecall(n, allSolutions, solution, row + 1, i, bag);
            }

            solution.Remove(EncodeRowAndCol(row, col));
            bag.UnionWith(erasedPositions);
        }

        private IList<string> ConvertSolutionFormat(HashSet<UInt64> solution, int n)
        {
            List<StringBuilder> res = new List<StringBuilder>();
            for (int i = 0; i < n; ++i)
            {
                res.Add(new StringBuilder(new string('.', n)));
            }

            foreach (UInt64 encodedRowAndCol in solution)
            {
                DecodeRowAndCol(encodedRowAndCol, out int row, out int col);
                res[row][col] = 'Q';
            }

            return res.Select(sb => sb.ToString()).ToList();
        }

        private IList<IList<string>> ConvertSolutionsFormat(HashSet<HashSet<UInt64>> solutions, int n)
        {
            List<IList<string>> res = new List<IList<string>>();
            foreach (HashSet<UInt64> sln in solutions)
            {
                res.Add(ConvertSolutionFormat(sln, n));
            }

            return res;
        }

        public IList<IList<string>> SolveNQueens(int n)
        {
            HashSet<HashSet<UInt64>> allSolutions = new HashSet<HashSet<UInt64>>();

            for (int col = 0; col < n; ++col)
            {
                HashSet<UInt64> bag = NewBag(n);
                for (int colInner = col - 1; colInner >= 0; --colInner)
                {
                    bag.Remove(EncodeRowAndCol(0, colInner));
                }

                DFSAndRecall(n, allSolutions, new HashSet<UInt64>(), 0, col, NewBag(n));
            }


            return ConvertSolutionsFormat(allSolutions, n);
        }
    }
}