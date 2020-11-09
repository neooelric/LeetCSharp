using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0044
{
    public class TestCase
    {
        public string S { get; set; }
        public string P { get; set; }
        public bool Output { get; set; }

        public override string ToString()
        {
            return string.Format("S:\"{0}\", P:\"{1}\", Output:{2}", S, P, Output);
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
                        cases.Last().P = Helper.ParseString(line);
                        break;
                    case 2:
                        cases.Last().Output = Helper.ParseBool(line);
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
            Solutions._0044.Solution solution = new Solutions._0044.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0044.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.IsMatch(c.S, c.P);

                Assert.True(
                    Helper.Equals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}