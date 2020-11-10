using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0048
{
    /*
    not to diffcult, you just have to figure out how the index changes during rotate

    here is my way:
        01 02 03 04     01 02 03 04     
        05 06 07 08 --> 05       08 +   06 07
        09 10 11 12 --> 09       12 +   10 11
        13 14 15 16     13 14 15 16
    
    just imagine that a matrix is a union : from outer side to insider, many layers

    what I trying to do, is to rotate each layer 90% degree as clockwise

    for a layer, it can split into four parts:
        01 02 03 04     01 02 03        04                  
        05       08 -->          +      08 +             +  05
        09       12 -->          +      12 +             +  09
        13 14 15 16                             14 15 16    13
    
    so it's pretty clear now :
        tmp = 01
        01 = 13
        13 = 16
        16 = 04
        04 = 01

    */

    public class Solution
    {
        public void Rotate(int[][] matrix)
        {
            int matrixSize = matrix.Length;

            for (int layer = 0; layer < matrixSize / 2; ++layer)
            {
                for (int i = layer; i < matrixSize - layer - 1; ++i)
                {
                    int tmp = matrix[layer][i];
                    matrix[layer][i] = matrix[matrixSize - i - 1][layer];
                    matrix[matrixSize - i - 1][layer] = matrix[matrixSize - layer - 1][matrixSize - i - 1];
                    matrix[matrixSize - layer - 1][matrixSize - i - 1] = matrix[i][matrixSize - layer - 1];
                    matrix[i][matrixSize - layer - 1] = tmp;
                }
            }
        }
    }
}