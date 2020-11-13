using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0051
{
    public class TestCase
    {
        public int N { get; set; }
        public string[][] Output { get; set; }

        public override string ToString()
        {
            return string.Format("N:{0}, Output:{1}", N, Helper.FormatString2DArrayAsMatrix(Output));
        }

        public static List<TestCase> ParseTestCaseFromTextFile(string filePath)
        {
            string[] fileContent = System.IO.File.ReadAllLines(filePath);

            List<TestCase> cases = new List<TestCase>();

            string str2DArrayStr = "";
            int n = 0;
            for (int i = 0; i < fileContent.Length; ++i)
            {
                string line = fileContent[i];

                if (line.StartsWith("---") || string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (line.StartsWith("[") || line.StartsWith(" ") || line.StartsWith("]"))
                {
                    str2DArrayStr += line.Trim();
                    if (line == "]")
                    {
                        cases.Add(new TestCase());
                        cases.Last().N = n;
                        cases.Last().Output = Helper.ParseString2DArray(str2DArrayStr);
                        str2DArrayStr = "";
                    }
                }
                else
                {
                    n = Helper.ParseInt(line);
                }

            }

            return cases;
        }
    }

    public class Test
    {
        [Fact]
        public void RunTestCases()
        {
            Solutions._0051.Solution solution = new Solutions._0051.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0051.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.SolveNQueens(c.N);

                Assert.True(
                    Helper.TwoDArrayEqualsRegardlessOfOuterOrder(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, Helper.FormatString2DArrayAsMatrix(result.Select(a => a.ToArray()).ToArray()))
                    );
            }
        }

    }
}