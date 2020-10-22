using System;

namespace Solutions._0005
{
    /*
    This is a simple and classic DP problem,
    I mean it can use DP to solve this problem in a very simple way,
    but DP is absolutely not the only way.

    here is the logic:
    if substring s[i..j] is a palindrome string, then if (s[i-1] == s[j+1]), s[i-1..j+1] is also a palindrome string,

    we can use a 2-d array(matrix) to record, for each (i, j), s[i..j] is, or is not a palindrome
        matrix[i][j] == 1  ----- palindrome
        matrix[i][j] == -1 ----- not palindrome
        matrix[i][j] == 0  ----- unknow yet

    when s[i..j].Length <= 3, we can directly judge this substring is, or is not palindrome
    when s[i..j].Length > 3, we have to judge this substring based on matrix[i+1, j-1]

    so as this train of thoughts, when iterate come to (i, j), we have to ensure that (i+1, j-1) is iterated

    so we can design our loop like this:
        for(int j = 0; j < s.Length; ++j)
            for(int i = 0; i <= j; ++i)

    or like this:
        for(int j = 0; j < s.Length; ++j)
            for(int i = j; i >= 0; --i)
        

    after we generate the whole matrix using DP iteration, we'll know the answer

    */
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            int[,] matrix = new int[s.Length, s.Length];

            int startIndexOfLongestPalindrome = 0;
            int longestPalindromeLength = 0;

            for(int j = 0; j < s.Length; ++j)
            {
                //for(int i = 0; i <= j; ++i)
                for(int i = j; i >= 0; --i)
                {
                    if(
                        (i == j) ||
                        ((i + 1 == j) && s[i] == s[j]) ||
                        ((i + 2 == j) && s[i] == s[j]) ||
                        (s[i] == s[j] && matrix[i+1, j-1] == 1)
                        )
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = -1;
                    }

                    if(matrix[i, j] == 1)
                    {
                        if(j - i + 1 > longestPalindromeLength)
                        {
                            longestPalindromeLength = j - i + 1;
                            startIndexOfLongestPalindrome = i;
                        }
                    }
                }
            }

            return s.Substring(startIndexOfLongestPalindrome, longestPalindromeLength);
        }
    }
}