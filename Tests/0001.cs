using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;
using Xunit.Abstractions;

namespace Tests._0001
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
                Helper.FormatIntArray(Output)
            );
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
                        cases.Last().Nums = Helper.ParseIntArray(line);
                        break;
                    case 1:
                        cases.Last().Target = Helper.ParseInt(line);
                        break;
                    case 2:
                        cases.Last().Output = Helper.ParseIntArray(line); ;
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
            Solutions._0001.Solution solution = new Solutions._0001.Solution();
            List<TestCase> cases = TestCase.ParseTestCasesFromTextFile(@"./0001.txt");

            foreach (TestCase c in cases)
            {
                int[] result = solution.TwoSum(c.Nums, c.Target);

                Assert.True(
                    Helper.IntArrayEqualsRegardlessOfOrder(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, Helper.FormatIntArray(result))
                    );
            }
        }
    }
}
