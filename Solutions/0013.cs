
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0013
{
    /*
    the trick is to treat 4/9/40/90/400/900 as a single symbol
    */

    public class Solution
    {
        public int RomanToInt(string s)
        {
            Dictionary<string, int> valueOfRomanSymbol = new Dictionary<string, int>
            {
                {"I", 1},
                {"IV", 4},
                {"V", 5},
                {"IX", 9},
                {"X", 10},
                {"XL", 40},
                {"L", 50},
                {"XC", 90},
                {"C", 100},
                {"CD", 400},
                {"D", 500},
                {"CM", 900},
                {"M", 1000}
            };

            int res = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                string oneCharSymbol = "" + s[i];
                string twoCharSymbol = i + 1 < s.Length ? "" + s[i] + s[i + 1] : oneCharSymbol;
                if (valueOfRomanSymbol.ContainsKey(twoCharSymbol))
                {
                    res += valueOfRomanSymbol[twoCharSymbol];
                    ++i;
                }
                else if (valueOfRomanSymbol.ContainsKey(oneCharSymbol))
                {
                    res += valueOfRomanSymbol[oneCharSymbol];
                }
            }

            return res;
        }
    }
}
