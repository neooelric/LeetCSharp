using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0043
{
    /*
    it's not so hard, it just kind of tedious.
    we have to implement the Multiply by digit, like we learned from our 3nd grade math class

    number 1: 123
    number 2: 456

    step 1: digit 6 from num2[2] multiply num1, get res1 = 738
        123
          6
        ``
        ---
        738
    
    step 2: digit 5 from num1[2] multiply num1, get res2 = 615
        123
          5
        `` 
        ---
        615
    
    step 3: digit 4 from num2[0] mutiply num1, get res3 = 492
        123
          4
         ` 
        ---
        492
    
    find step : res = res1 + res2*10 + res3*100

            738
           6150
          49200
          ``   
          -----
          56088
    
    so, the pseudocode would be like:
        for(int i = num2.Length-1; i >= 0; ++i)
        {
            res[i] = num2[i] multiply num1;
        }
        for(int i = 0; i < res.Length; ++i)
        {
            res[i].append(i "0"(s));

            res = res add res[i];
        }
    
    so, in order to make our code more clear, we'd better to implement two sub functions:
        1. a char digit multiply a stringify number, return stringify result
        2. two stringify number add together, return stringify result
    
    when calculating a digit multiply a digit, we can use a mutiply table like Dictionary<char, Dictionary<char, string>> MultiplyTable
    just access MultiplyTable[digit1][digit2] to get the multiply result
    the only ugly thing is the definition of MultiplyTable is pretty tedious and long

    as the same, we should define a AddTable for single digits

    actually you can convert each digit char to numeric type then use * and + operator to do single digit multiply and sum
    the problem don't allow you to convert num1 and num2 to numeric type directly
    but for digit multiply, i think it won't mind if we use numeric type.

    nah, i chose to use multiply table and add table
    */

    public class Solution
    {
        private static Dictionary<char, Dictionary<char, string>> AddTable = new Dictionary<char, Dictionary<char, string>>{
            {
                '0',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "1"},
                    {'2', "2"},
                    {'3', "3"},
                    {'4', "4"},
                    {'5', "5"},
                    {'6', "6"},
                    {'7', "7"},
                    {'8', "8"},
                    {'9', "9"},
                }
            },
            {
                '1',
                new Dictionary<char, string>
                {
                    {'0', "1"},
                    {'1', "2"},
                    {'2', "3"},
                    {'3', "4"},
                    {'4', "5"},
                    {'5', "6"},
                    {'6', "7"},
                    {'7', "8"},
                    {'8', "9"},
                    {'9', "10"},
                }
            },
            {
                '2',
                new Dictionary<char, string>
                {
                    {'0', "2"},
                    {'1', "3"},
                    {'2', "4"},
                    {'3', "5"},
                    {'4', "6"},
                    {'5', "7"},
                    {'6', "8"},
                    {'7', "9"},
                    {'8', "10"},
                    {'9', "11"},
                }
            },
            {
                '3',
                new Dictionary<char, string>
                {
                    {'0', "3"},
                    {'1', "4"},
                    {'2', "5"},
                    {'3', "6"},
                    {'4', "7"},
                    {'5', "8"},
                    {'6', "9"},
                    {'7', "10"},
                    {'8', "11"},
                    {'9', "12"},
                }
            },
            {
                '4',
                new Dictionary<char, string>
                {
                    {'0', "4"},
                    {'1', "5"},
                    {'2', "6"},
                    {'3', "7"},
                    {'4', "8"},
                    {'5', "9"},
                    {'6', "10"},
                    {'7', "11"},
                    {'8', "12"},
                    {'9', "13"},
                }
            },
            {
                '5',
                new Dictionary<char, string>
                {
                    {'0', "5"},
                    {'1', "6"},
                    {'2', "7"},
                    {'3', "8"},
                    {'4', "9"},
                    {'5', "10"},
                    {'6', "11"},
                    {'7', "12"},
                    {'8', "13"},
                    {'9', "14"},
                }
            },
            {
                '6',
                new Dictionary<char, string>
                {
                    {'0', "6"},
                    {'1', "7"},
                    {'2', "8"},
                    {'3', "9"},
                    {'4', "10"},
                    {'5', "11"},
                    {'6', "12"},
                    {'7', "13"},
                    {'8', "14"},
                    {'9', "15"},
                }
            },
            {
                '7',
                new Dictionary<char, string>
                {
                    {'0', "7"},
                    {'1', "8"},
                    {'2', "9"},
                    {'3', "10"},
                    {'4', "11"},
                    {'5', "12"},
                    {'6', "13"},
                    {'7', "14"},
                    {'8', "15"},
                    {'9', "16"},
                }
            },
            {
                '8',
                new Dictionary<char, string>
                {
                    {'0', "8"},
                    {'1', "9"},
                    {'2', "10"},
                    {'3', "11"},
                    {'4', "12"},
                    {'5', "13"},
                    {'6', "14"},
                    {'7', "15"},
                    {'8', "16"},
                    {'9', "17"},
                }
            },
            {
                '9',
                new Dictionary<char, string>
                {
                    {'0', "9"},
                    {'1', "10"},
                    {'2', "11"},
                    {'3', "12"},
                    {'4', "13"},
                    {'5', "14"},
                    {'6', "15"},
                    {'7', "16"},
                    {'8', "17"},
                    {'9', "18"},
                }
            },
        };

        private static Dictionary<char, Dictionary<char, string>> MultiplyTable = new Dictionary<char, Dictionary<char, string>>{
            {
                '0',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "0"},
                    {'2', "0"},
                    {'3', "0"},
                    {'4', "0"},
                    {'5', "0"},
                    {'6', "0"},
                    {'7', "0"},
                    {'8', "0"},
                    {'9', "0"},
                }
            },
            {
                '1',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "1"},
                    {'2', "2"},
                    {'3', "3"},
                    {'4', "4"},
                    {'5', "5"},
                    {'6', "6"},
                    {'7', "7"},
                    {'8', "8"},
                    {'9', "9"},
                }
            },
            {
                '2',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "2"},
                    {'2', "4"},
                    {'3', "6"},
                    {'4', "8"},
                    {'5', "10"},
                    {'6', "12"},
                    {'7', "14"},
                    {'8', "16"},
                    {'9', "18"},
                }
            },
            {
                '3',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "3"},
                    {'2', "6"},
                    {'3', "9"},
                    {'4', "12"},
                    {'5', "15"},
                    {'6', "18"},
                    {'7', "21"},
                    {'8', "24"},
                    {'9', "27"},
                }
            },
            {
                '4',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "4"},
                    {'2', "8"},
                    {'3', "12"},
                    {'4', "16"},
                    {'5', "20"},
                    {'6', "24"},
                    {'7', "28"},
                    {'8', "32"},
                    {'9', "36"},
                }
            },
            {
                '5',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "5"},
                    {'2', "10"},
                    {'3', "15"},
                    {'4', "20"},
                    {'5', "25"},
                    {'6', "30"},
                    {'7', "35"},
                    {'8', "40"},
                    {'9', "45"},
                }
            },
            {
                '6',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "6"},
                    {'2', "12"},
                    {'3', "18"},
                    {'4', "24"},
                    {'5', "30"},
                    {'6', "36"},
                    {'7', "42"},
                    {'8', "48"},
                    {'9', "54"},
                }
            },
            {
                '7',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "7"},
                    {'2', "14"},
                    {'3', "21"},
                    {'4', "28"},
                    {'5', "35"},
                    {'6', "42"},
                    {'7', "49"},
                    {'8', "56"},
                    {'9', "63"},
                }
            },
            {
                '8',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "8"},
                    {'2', "16"},
                    {'3', "24"},
                    {'4', "32"},
                    {'5', "40"},
                    {'6', "48"},
                    {'7', "56"},
                    {'8', "64"},
                    {'9', "72"},
                }
            },
            {
                '9',
                new Dictionary<char, string>
                {
                    {'0', "0"},
                    {'1', "9"},
                    {'2', "18"},
                    {'3', "27"},
                    {'4', "36"},
                    {'5', "45"},
                    {'6', "54"},
                    {'7', "63"},
                    {'8', "72"},
                    {'9', "81"},
                }
            },
        };

        private string NumberMultiplyDigit(string num, char digit)
        {

            string res = "";

            char carry = '0';
            for (int i = num.Length - 1; i >= 0; --i)
            {
                string sum = MultiplyTable[digit][num[i]];
                sum = NumberAddNumber(sum, carry + "");

                carry = (sum.Length == 1) ? '0' : sum[0];
                res = "" + sum.Last() + res;
            }

            if (carry != '0')
            {
                res = "" + carry + res;
            }

            return res;
        }

        private string NumberAddNumber(string num1, string num2)
        {
            string res = "";
            char carry = '0';
            for (int i = num1.Length - 1, j = num2.Length - 1; i >= 0 || j >= 0; --i, --j)
            {
                string sum;
                if (i >= 0 && j >= 0)
                {
                    sum = AddTable[num1[i]][num2[j]];
                }
                else if (i >= 0)
                {
                    sum = "" + num1[i];
                }
                else
                {
                    sum = "" + num2[j];
                }

                if (sum.Length == 1)
                {
                    sum = AddTable[sum[0]][carry];
                }
                else
                {
                    sum = "" + sum[0] + AddTable[sum[1]][carry];
                }

                carry = (sum.Length == 1) ? '0' : sum[0];
                res = "" + sum.Last() + res;
            }

            if (carry != '0')
            {
                res = "" + carry + res;
            }

            return res;

        }
        public string Multiply(string num1, string num2)
        {
            string[] midRes = new string[num2.Length];

            for (int i = num2.Length - 1, j = 0; i >= 0; --i, ++j)
            {
                midRes[j] = NumberMultiplyDigit(num1, num2[i]);
                for (int k = 0; k < j; k++)
                {
                    midRes[j] += '0';
                }
            }

            string res = "0";
            for (int i = 0; i < midRes.Length; ++i)
            {
                res = NumberAddNumber(res, midRes[i]);
            }

            int firstNonZeroDigitIndex = 0;
            while (firstNonZeroDigitIndex < res.Length && res[firstNonZeroDigitIndex] == '0')
            {
                firstNonZeroDigitIndex++;
            }

            if (firstNonZeroDigitIndex == res.Length)
            {
                return "0";
            }
            else
            {
                return res.Substring(firstNonZeroDigitIndex);
            }
        }
    }
}
