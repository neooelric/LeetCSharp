using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.LeetCodeDefinitions;

namespace Solutions._0049
{
    /*
    according the problem's description, if we want to solve this problem in a efficient way
    we should have the ability to search string with a set of chatacters
    
    like we have a set of {'a', 't', 'e'}, we should find all strings that matches this set

    yeah, Dictionary can do this.

    considering the chatacter set may have repeated character, so the key of Dictionary should not be a HashSet

    a good idea is to encode all the characters and it's appear count into a string

    so, for {'a', 't', 'e'} we could encoded it as "a1e1t1"
    for {'a', 'a', 'p', 'l', 'e'} we could encoded it as "a2e1l1p1"

    */

    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> res = new List<IList<string>>();
            Dictionary<string, int> resIndexOfCharset = new Dictionary<string, int>();

            SortedDictionary<char, int> charsetWithAppearCount = new SortedDictionary<char, int>();
            StringBuilder sb = new StringBuilder();
            foreach (string str in strs)
            {
                charsetWithAppearCount.Clear();
                sb.Clear();

                foreach (char c in str)
                {
                    if (!charsetWithAppearCount.ContainsKey(c))
                    {
                        charsetWithAppearCount.Add(c, 0);
                    }
                    charsetWithAppearCount[c]++;
                }
                foreach (KeyValuePair<char, int> charAndCount in charsetWithAppearCount)
                {
                    sb.AppendFormat("{0}{1}", charAndCount.Key, charAndCount.Value);
                }

                int indexInRes;
                if (!resIndexOfCharset.ContainsKey(sb.ToString()))
                {
                    indexInRes = res.Count;
                    res.Add(new List<string>());
                    resIndexOfCharset.Add(sb.ToString(), indexInRes);
                }
                else
                {
                    indexInRes = resIndexOfCharset[sb.ToString()];
                }

                res[indexInRes].Add(str);

            }

            return res;
        }
    }
}