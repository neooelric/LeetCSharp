using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0034
{
    public class TestCase
    {
        public int[] Nums { get; set; }
        public int Target { get; set; }
        public int[] Output { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Nums:{0}, Target:{1}, Output:{2}",
                Helper.FormatIntArray(Nums),
                Target,
                Helper.FormatIntArray(Output));
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
                        cases.Last().Nums = Helper.ParseIntArray(line);
                        break;
                    case 1:
                        cases.Last().Target = Helper.ParseInt(line);
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
            Solutions._0034.Solution solution = new Solutions._0034.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0034.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.SearchRange(c.Nums, c.Target);

                Assert.True(
                    Helper.ArrayEquals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, Helper.FormatIntArray(result))
                    );
            }
        }

    }
}