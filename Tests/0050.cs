using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0050
{
    public class TestCase
    {
        public double X { get; set; }
        public int N { get; set; }
        public double Output { get; set; }

        public override string ToString()
        {
            return string.Format("X:{0}, N:{1}, Output:{2}", X, N, Output);
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
                        cases.Last().X = Helper.ParseDouble(line);
                        break;
                    case 1:
                        cases.Last().N = Helper.ParseInt(line);
                        break;
                    case 2:
                        cases.Last().Output = Helper.ParseDouble(line);
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
            Solutions._0050.Solution solution = new Solutions._0050.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0050.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.MyPow(c.X, c.N);

                Assert.True(
                    Helper.ValueEquals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}