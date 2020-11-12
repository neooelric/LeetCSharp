using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0049
{
    public class TestCase
    {
        public string[] Strs { get; set; }
        public string[][] Output { get; set; }

        public override string ToString()
        {
            return string.Format("Strs:{0}, Output:{1}",
            Helper.FormatStringArray(Strs),
            Helper.FormatString2DArray(Output));
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
                        cases.Last().Strs = Helper.ParseStringArray(line);
                        break;
                    case 1:
                        cases.Last().Output = Helper.ParseString2DArray(line);
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
            Solutions._0049.Solution solution = new Solutions._0049.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0049.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.GroupAnagrams(c.Strs);

                Assert.True(
                    Helper.String2DArrayEqualsRegardlessOfOrder(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, Helper.FormatString2DArray(result))
                    );
            }
        }

    }
}