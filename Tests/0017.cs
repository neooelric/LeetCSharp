
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Tests._0017
{
    public class TestCase
    {
        public string Digits { get; set; }
        public string[] Output { get; set; }

        public override string ToString()
        {
            return string.Format("Digits:{0}, Output:{1}", Digits, Helper.FormatStringArray(Output));
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
                        cases.Last().Digits = Helper.ParseString(line);
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
            Solutions._0017.Solution solution = new Solutions._0017.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0017.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.LetterCombinations(c.Digits);

                Assert.True(
                    Helper.StringArrayEqualsRegardlessOfOrder(result.ToArray(), c.Output),
                    string.Format("Case{{{0}}}, Result:{{{1}}}", c, Helper.FormatStringArray(result.ToArray()))
                    );
            }
        }

    }
}
