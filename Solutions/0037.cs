
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Utilities;

namespace Solutions._0037
{
    /*
    using recursive to solve this kind of problem is pretty natural
    the basic thought is:
        uncomplete board -> put a possible number on a unknow position -> recursive solve this uncomplete board

    the terminate condition is:
        1. if there is a unknow position which can not find any possible number, solve failed
        2. if traverse all possible numbers still can not solve the soduko, solve failed
        3. if there is no unknow position, solve success

    -----

    another way is to maintain a data structure, it store all unknow positions' possible answer
    then iterate like this:
        while(there are still some unknow positions)
        {
            find the positions which only have one possible answer
            put that only possible answer to these positions
            refresh the data structure which store all unknow positions' possible answer
        }
    the key point is how to design the special "data structure", it should:
        1. quick as possible to find out which position has the most few possible answers
        2. refresh is quick
    so, this way is a little bit complex when coding, from the understandable perspective, 
    both this way and the recursive way are pretty simple

    -----

    I chose to use the recursive way
    */

    public class Solution
    {
        private HashSet<char> FindPossibleNumbersOfAPosition(char[][] board, int row, int column)
        {
            HashSet<char> res = new HashSet<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < 9; ++i)
            {
                res.Remove(board[i][column]);
                res.Remove(board[row][i]);
            }

            for (int i = row / 3 * 3 ; i < row / 3 * 3 + 3; ++i)
            {
                for (int j = column / 3 * 3; j < column / 3 * 3 + 3; ++j)
                {
                    res.Remove(board[i][j]);
                }
            }

            return res;

        }
        private bool TryToSolveSudoku(char[][] board)
        {
            for (int row = 0; row < 9; ++row)
            {
                for (int column = 0; column < 9; ++column)
                {
                    if (board[row][column] != '.')
                    {
                        continue;
                    }

                    HashSet<char> possibleNumbers = FindPossibleNumbersOfAPosition(board, row, column);

                    if (possibleNumbers.Count == 0)
                    {
                        return false;
                    }

                    foreach (char possibleNumber in possibleNumbers)
                    {
                        board[row][column] = possibleNumber;
                        if (TryToSolveSudoku(board))
                        {
                            return true;
                        }
                    }

                    board[row][column] = '.';

                    return false;
                }
            }

            return true;
        }

        public void SolveSudoku(char[][] board)
        {
            TryToSolveSudoku(board);
        }
    }
}
