
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0032
{
    /*
    This problem has been marked as a "hard" problem, but actually it's pretty simple.

    One classic class of problems of leetcode is to find the Longest Substring which meet certain conditions
    the common way to solve this kind of problem is dynamic programming
    but this problem is actually not like that, you can solve this problem in a one-time traverse

    the key points is : 
        1. a valid parentheses always begin with '(' and ends with ')'
        2. there are two kinds of valid form:
            2.1 simple 'nested valid'
                (), (()), ((())), (((())))
            2.2 'combination of nested'
                ()(), ()(()), ((()))()() 

    I tried to explain this simple algorithm, i've been re-write this comment several times
    and finally I realize that the best way to explain, is to manually simulate the algorithm

    here is the logic:

        a stack to store index
        a 'start-index' variable
        we traverse the string one-time
            1. '(' push the index to a stack
            2. ')'
                2.1. if the stack is empty, refresh 'start-index' to i+1
                2.2. if the stack is empty after pop, then s[start-index, i] is a valid paretheses
                2.3. if the stack is not empty after pop, then s[stack.Peek() + 1, i] is a valid paretheses



    current-index   start-index     stack           )()((())()
        0               1             -             )               ) and stack is empty, let start-index = 0+1
        1               1             1             )(              push
        2               1             -             )()             after pop stack is empty, so s[1..2] is valid parentheses
        3               1             3             )()(            push
        4               1             3,4           )()((           push
        5               1             3,4,5         )()(((          push
        6               1             3,4           )()((()         after pop stack is not empty, so s[4+1, 6] is valid parentheses
        7               1             3             )()((())        after pop stack is not empty, so s[3+1, 7] is valid parentheses
        8               1             3,8           )()((())(       push
        9               1             3             )()((())()      after pop stack is not empty, so s[3+1, 9] is valid parentheses
    */

    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            int startIndex = 0;
            int res = 0;

            Stack<int> stack = new Stack<int>();
            for(int i = 0; i < s.Length; ++i)
            {

                if(s[i] == '(')
                {
                    stack.Push(i);
                    continue;
                }

                if(stack.Count == 0)
                {
                    startIndex = i + 1;
                    continue;
                }

                stack.Pop();

                if(stack.Count == 0)
                {
                    if(i - startIndex + 1 > res)
                    {
                        res = i - startIndex + 1;
                    }
                }
                else
                {
                    if(i - stack.Peek() > res)
                    {
                        res = i - stack.Peek();
                    }

                }
            }

            return res;
        }

    }
}
