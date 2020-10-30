
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions._0030
{
    /*
    dont get fooled, this actually not a string matching problem, you dont need get algorithms like KMP to solve this problem.

    the possible answer is in range [0, s.Length - singleWordLength * wordsCount]

    so the most intuitive thought is to traverse number in range [0, s.Length - singleWordLength * wordsCount]
    test each of the number is legal or not

    so the main shape of solution is like:
        for(int i = 0; i <= s.Length - singleWordLength * wordsCount; ++i) {
            if(i is a valid answer) {
                res.Add(i);
            }
        }

    then, in each loop iteration, the thing you need to judge is actually: 
        s.subString(i, i + singleWordLength * wordsCount) whether contains all words and each word only once
    in another word, is to:
        just to judge string array
            [
                s.subString(i, i + singleWordLength),
                s.subString(i+singleWordLength, i+2*singleWordLength),
                ...
            ]
        and string array "words" is, or is not equals, regardless of order
    */

    public class Solution
    {
        private bool IsSubstringContainsAllWords(
            string s,
            int beginIndex,
            Dictionary<string, int> wordCountDict,
            int singleWordLength,
            int wordsCount)
        {
            Dictionary<string, int> wordCountInHere = new Dictionary<string, int>();

            for(int i = 0; i < wordsCount; ++i)
            {
                string word = s.Substring(beginIndex + i * singleWordLength, singleWordLength);
                if(!wordCountInHere.ContainsKey(word))
                {
                    wordCountInHere.Add(word, 1);
                }
                else
                {
                    wordCountInHere[word]++;
                }

                if(!wordCountDict.ContainsKey(word) || wordCountDict[word] < wordCountInHere[word])
                {
                    return false;
                }

            }

            return true;

        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> res = new List<int>();

            if(words.Length == 0)
            {
                return res;
            }

            Dictionary<string, int> wordCountDict = new Dictionary<string, int>();
            foreach(string word in words)
            {
                if(!wordCountDict.ContainsKey(word))
                {
                    wordCountDict.Add(word, 0);
                }
                wordCountDict[word]++;
            }


            int singleWordLength = words[0].Length;
            int wordsCount = words.Length;

            for(int i = 0; i <= s.Length - singleWordLength * wordsCount; ++i)
            {
                if(IsSubstringContainsAllWords(s, i, wordCountDict, singleWordLength, wordsCount))
                {
                    res.Add(i);
                }
            }


            return res;
        }
    }
}
