using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0040
{
    public class TestCase
    {
        public int[] Candidates { get; set; }
        public int Target { get; set; }
        public int[][] Output { get; set; }

        public override string ToString()
        {
            return string.Format("Candidates:{0}, Target:{1}, Output:{2}", Helper.FormatIntArray(Candidates), Target, Helper.FormatInt2DArray(Output));
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
                        cases.Last().Candidates = Helper.ParseIntArray(line);
                        break;
                    case 1:
                        cases.Last().Target = Helper.ParseInt(line);
                        break;
                    case 2:
                        cases.Last().Output = Helper.ParseInt2DArray(line);
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
            Solutions._0040.Solution solution = new Solutions._0040.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0040.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.CombinationSum2(Helper.DupArray(c.Candidates), c.Target);

                Assert.True(
                    Helper.TwoDArrayEqualsRegardlessOfOrder(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, Helper.FormatInt2DArray(result))
                    );
            }
        }

    }
}