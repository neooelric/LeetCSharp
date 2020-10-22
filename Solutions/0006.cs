using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions._0006
{
    /*
    using a matrix to represent the ZigZag shape is very natural and intuitive.

    the train of mind is to traverse the original string, 
    put each character in a matrix as the ZigZag rule,
    then traverse the matrix and combine those characters, that's the answer


    the trick thing is, if the numRows is a very big number, like 1000

    if we truly construct a 2-d array [1000, 1000] and place the ZigZag shape in it, 
    then after we build the ZigZag shape, we have to traverse 1 million elements.

    the matrix it so sparse...

    a better way is using SortedDictionary to represent this sparse matrix

    using 2 level nested SortedDictionary, like this:
        matrix = new SortedDictionary<int, SortedDictionary<int, char>>();
        matrix[row][column]
    
    or using a 1 level SortedDictionary, then combine row&num into one number
    (the constraints of this problem pointed out, numRows will not bigger than 1000)
        matrix = new SortedDictionary<int, char>();
        combinedKey = row * 10000 + column;

    i'll use the later one


    tip:
        be careful when numRows == 1
    */

    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            SortedDictionary<int, char> matrix = new SortedDictionary<int, char>();

            int currentRow = 0;
            int currentCol = 1;

            bool currentDirectionIsDown = true;

            for (int i = 0; i < s.Length; ++i)
            {
                char c = s[i];

                if (
                    (currentDirectionIsDown && currentRow == numRows) ||
                    (!currentDirectionIsDown && currentRow == 1)
                    )
                {
                    currentDirectionIsDown = !currentDirectionIsDown;
                }

                if (currentDirectionIsDown)
                {
                    currentRow++;
                }
                else
                {
                    currentRow--;
                    currentCol++;
                }

                int matrixKey = currentRow * 10000 + currentCol;
                matrix.Add(matrixKey, c);
            }

            StringBuilder sb = new StringBuilder();

            foreach (char c in matrix.Values)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
