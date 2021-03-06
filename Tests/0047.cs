using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0047
{
    public class TestCase
    {
        public int[] Nums { get; set; }
        public int[][] Output { get; set; }

        public override string ToString()
        {
            return string.Format("Nums:{0}, Output:{1}", Helper.FormatIntArray(Nums), Helper.FormatInt2DArray(Output));
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
                        cases.Last().Nums = Helper.ParseIntArray(line);
                        break;
                    case 1:
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
            Solutions._0047.Solution solution = new Solutions._0047.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0047.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.PermuteUnique(c.Nums);

                Assert.True(
                    Helper.TwoDArrayEqualsRegardlessOfOuterOrder(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, Helper.FormatInt2DArray(result))
                    );
            }
        }

    }
}