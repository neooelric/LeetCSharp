using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using Xunit;

namespace Tests._0006
{
    public class TestCase
    {
        public string S { get; set; }
        public int NumRows { get; set; }
        public string Output { get; set; }

        public override string ToString()
        {
            return string.Format("S:{0}, NumRows:{1}, Output:{2}", S, NumRows, Output);
        }

        public static List<TestCase> ParseTestCasesFromTextFile(string filePath)
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
                        cases.Last().NumRows = Helper.ParseInt(line);
                        break;
                    case 2:
                        cases.Last().Output = Helper.ParseString(line);
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
            Solutions._0006.Solution solution = new Solutions._0006.Solution();

            List<TestCase> cases = TestCase.ParseTestCasesFromTextFile(@"./0006.txt");

            foreach (TestCase c in cases)
            {
                string result = solution.Convert(c.S, c.NumRows);

                Assert.True(
                    Helper.ValueEquals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }

}
