
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0036
{
    /*
    the most intuitive thought is : gather 9 chars of each row/column/square, then to check whether it contains repeated numeric char.

    you need to gather 27 sets : 9 for rows, 9 for columns, 9 for squares

    a better way is to use bitset like things to quick judge whether a set contains repeated numeric char

    use row as example:
        first, you initialize a boolean array with capacity 9, full of default value -- that is false
            var boolArr = new bool[9];
        second, when you traverse a row like this:
            foreach (char c in rowStr)
            {
                ...
            }
        you can map each numeric char to a number between [0..8], like
            int index = c - '1';
        then just check 'boolArr[index]', if it is false, then turn it to true
        if it is true, then prove that this char 'c' has been already appeared before!
    */

    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            bool[,] boolArrForRows = new bool[9, 9];
            bool[,] boolArrForColumns = new bool[9, 9];
            bool[,,] boolArrForSquares = new bool[3, 3, 9];

            for(int row = 0; row < 9; ++row)
            {
                for(int column = 0; column < 9; ++column)
                {
                    char c = board[row][column];

                    if(c == '.')
                    {
                        continue;
                    }

                    int index = c - '1';

                    if(boolArrForRows[row,index])
                    {
                        return false;
                    }
                    if(boolArrForColumns[column, index])
                    {
                        return false;
                    }

                    if(boolArrForSquares[row/3, column/3, index])
                    {
                        return false;
                    }

                    boolArrForRows[row, index] = true;
                    boolArrForColumns[column, index] = true;
                    boolArrForSquares[row / 3, column / 3, index] = true;
                }
            }

            return true;
        }
    }
}
