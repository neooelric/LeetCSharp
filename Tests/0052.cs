using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0052
{
    public class TestCase
    {
        public int N { get; set; }
        public int Output { get; set; }

        public override string ToString()
        {
            return string.Format("N:{0}, Output:{1}", N, Output);
        }

        public static List<TestCase> ParseTestCaseFromTextFile(string filePath)
        {
            string[] fileContent = System.IO.File.ReadAllLines(filePath);

            List<TestCase> cases = new List<TestCase>();

            for (int i = 0; i < fileContent.Length; ++i)
            {
                string line = fileContent[i];

                switch (i % 3)
                {
                    case 0:
                        cases.Add(new TestCase());
                        cases.Last().N = Helper.ParseInt(line);
                        break;
                    case 1:
                        cases.Last().Output = Helper.ParseInt(line);
                        break;
                    default:
                        break;
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
            Solutions._0052.Solution solution = new Solutions._0052.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0052.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.TotalNQueens(c.N);

                Assert.True(
                    Helper.ValueEquals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}