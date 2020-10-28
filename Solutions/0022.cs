
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0022
{
    /*
    the most natrual way to solve this kind of problem is recursive.

    but for this problem, when n is a little bigger, recursive calling will consume a lot of performance, the problem's scale will grow Expoential,

    that means using recursive is very expensive.

    actually you can still using recursive calling to solve this problem

    ----------

    i'm going to use a brutal way to solve this problem, maybe it's more natural than recursive calling and more unstandable
    
    the train of thoughts is just to generate the "string" one char by one char

    image we've got a middle result, length == 5, like "((())" or "()()(" or "()((("

    the 6th character is whether "(" or ")", that's depends on how many left bracket in current middle result

    the rule is:
        leftCount == how many left bracket in current middle result
        rightCount == how many right bracket in current middle result
        
        if(leftCount == rightCount) {
            next char must be "("
        } else if(leftCount > rightCount) {
            next char can be "(" or ")"
        } else if(leftCount < rightCount) {
            this can not be happened, this already illegal
        }

    as your thought, there is not "a middle result", it's acutally "a bunch of middle results"

    i'll use a List of Tuple to represent this bunch of middle results, each tuple contains two items:
        1. middle result
        2. the leftCount of this middle result

    and using a loop like this:
        for(int i = 0; i < 2 * n; ++i)
        {
            // iterate the List of Tuple
        }

    final, using Lambda expression to convert this List of Tuple to List of String
    */

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<Tuple<StringBuilder, int>> res = new List<Tuple<StringBuilder, int>>();

            for(int i = 0; i < 2 * n; ++i)
            {
                if (i == 0)
                {
                    res.Add(new Tuple<StringBuilder, int>(new StringBuilder("("), 1));
                    continue;
                }

                List<Tuple<StringBuilder, int>> tmpRes = new List<Tuple<StringBuilder, int>>();

                foreach(Tuple<StringBuilder, int> strAndLeftCount in res)
                {
                    int leftCount = strAndLeftCount.Item2;
                    int rightCount = strAndLeftCount.Item1.Length - leftCount;

                    if(leftCount == rightCount)
                    {
                        tmpRes.Add(new Tuple<StringBuilder, int>(strAndLeftCount.Item1.Append("("), leftCount + 1));
                    }
                    else if(leftCount > rightCount && leftCount < n)
                    {
                        tmpRes.Add(new Tuple<StringBuilder, int>(new StringBuilder(strAndLeftCount.Item1.ToString()).Append("("), leftCount + 1));
                        tmpRes.Add(new Tuple<StringBuilder, int>(strAndLeftCount.Item1.Append(")"), leftCount));
                    }
                    else if(leftCount == n)
                    {
                        tmpRes.Add(new Tuple<StringBuilder, int>(strAndLeftCount.Item1.Append(")"), leftCount));
                    }
                }

                res = tmpRes;
            }

            return res.Select(item => item.Item1.ToString()).ToList();
        }
    }
}
