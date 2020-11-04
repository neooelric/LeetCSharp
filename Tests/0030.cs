
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Tests._0030
{
    public class TestCase
    {
        public string S { get; set; }
        public string[] Words { get; set; }
        public int[] Output { get; set; }

        public override string ToString()
        {
            return string.Format("S:{0}, Words:{1}, Output:{2}", S, Helper.FormatStringArray(Words), Helper.FormatIntArray(Output));
        }

        public static List<TestCase> ParseTestCaseFromTextFile(string filePath)
        {
            string[] fileContent = System.IO.File.ReadAllLines(filePath);

            List<TestCase> cases = new List<TestCase>();

            for (int i = 0; i < fileContent.Length; ++i)
            {
                string line = fileContent[i];

                switch (i % 4)
                {
                    case 0:
                        cases.Add(new TestCase());
                        cases.Last().S = Helper.ParseString(line);
                        break;
                    case 1:
                        cases.Last().Words = Helper.ParseStringArray(line);
                        break;
                    case 2:
                        cases.Last().Output = Helper.ParseIntArray(line);
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
            Solutions._0030.Solution solution = new Solutions._0030.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0030.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.FindSubstring(c.S, c.Words);

                Assert.True(
                    Helper.Equals(result.ToArray(), c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, Helper.FormatIntArray(result.ToArray()))
                    );
            }
        }

    }
}