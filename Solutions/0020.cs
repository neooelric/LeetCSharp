
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0020
{

    /*
    very classic and simple stack problem
    */

    public class Solution
    {
        public bool IsValid(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return true;
            }

            Stack<char> stack = new Stack<char>();
            foreach(char c in s)
            {
                if(c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    if(stack.Count == 0)
                    {
                        return false;
                    }

                    if(
                        (c == ')' && stack.Peek() == '(')
                        ||(c == ']' && stack.Peek() == '[')
                        ||(c == '}' && stack.Peek() == '{')
                        )
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
