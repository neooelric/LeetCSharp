
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Tests._0022
{
    public class TestCase
    {
        public int N { get; set; }
        public string[] Output { get; set; }

        public override string ToString()
        {
            return string.Format("N:{0}, Output:{1}", N, Helper.FormatStringArray(Output));
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
                        cases.Last().Output = Helper.ParseStringArray(line);
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
            Solutions._0022.Solution solution = new Solutions._0022.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0022.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.GenerateParenthesis(c.N);

                Assert.True(
                    Helper.StringArrayEqualsRegardlessOfOrder(result.ToArray(), c.Output),
                    string.Format("Case{{{0}}}, Result:{{{1}}}", c, Helper.FormatStringArray(result.ToArray()))
                    );
            }
        }

    }
}
