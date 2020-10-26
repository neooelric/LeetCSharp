
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Solutions._0017
{
    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            Dictionary<char, string> charsOfDigit = new Dictionary<char, string> {
                {'2', "abc"},
                {'3', "def"},
                {'4', "ghi"},
                {'5', "jkl"},
                {'6', "mno"},
                {'7', "pqrs"},
                {'8', "tuv"},
                {'9', "wxyz"},
            };

            List<StringBuilder> res = new List<StringBuilder>();

            foreach(char digit in digits)
            {
                string currentChars = charsOfDigit[digit];

                if (res.Count == 0)
                {
                    foreach (char c in currentChars)
                    {
                        res.Add(new StringBuilder().Append(c));
                    }
                }
                else
                {
                    List<StringBuilder> middleRes = new List<StringBuilder>();
                    for (int i = 0; i < currentChars.Length; ++i)
                    {
                        foreach (StringBuilder sb in res)
                        {
                            if (i != currentChars.Length - 1)
                            {
                                sb.Append(currentChars[i]);
                                middleRes.Add(new StringBuilder(sb.ToString()));
                                sb.Remove(sb.Length - 1, 1);
                            }
                            else
                            {
                                sb.Append(currentChars[i]);
                                middleRes.Add(sb);
                            }
                        }
                    }

                    res = middleRes;
                }
            }

            return res.Select(sb => sb.ToString()).ToList();
        }

    }
}
