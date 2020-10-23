
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0012
{
    /*
    the trick is to treat 4/9/40/90/400/900 as a single symbol
    */

    public class Solution
    {
        public string IntToRoman(int num)
        {
            SortedDictionary<int, string> romanSymbolOfNumber = new SortedDictionary<int, string>
            {
                {1, "I" },
                {4,"IV" },
                {5,"V" },
                {9,"IX" },
                {10,"X" },
                {40,"XL" },
                {50,"L" },
                {90,"XC" },
                {100,"C" },
                {400,"CD" },
                {500,"D" },
                {900,"CM" },
                {1000,"M" }
            };
            StringBuilder sb = new StringBuilder();

            while(num > 0)
            {
                foreach(KeyValuePair<int,string> kvp in romanSymbolOfNumber.Reverse())
                {
                    if(num >= kvp.Key)
                    {
                        num -= kvp.Key;
                        sb.Append(kvp.Value);
                        break;
                    }
                }

            }

            return sb.ToString();
        }
    }
}
