
using System.Collections.Generic;

namespace Solutions._0003
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> lastIndexOfChar = new Dictionary<char, int>();

            int maxLength = 0;

            for (int left = -1, right = 0; right < s.Length; ++right)
            {
                int currentLength;

                if (!lastIndexOfChar.ContainsKey(s[right]))
                {
                    currentLength = right - left;
                    lastIndexOfChar.Add(s[right], right);
                }
                else
                {

                    if (lastIndexOfChar[s[right]] < left)
                    {
                        currentLength = right - left;
                    }
                    else
                    {
                        left = lastIndexOfChar[s[right]];
                        currentLength = right - left;
                    }

                    lastIndexOfChar[s[right]] = right;
                }

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }
            }

            return maxLength;
        }
    }

}