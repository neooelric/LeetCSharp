
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Tests._0027
{
    public class TestCase
    {
        public int[] Nums { get; set; }
        public int Val { get; set; }
        public int Output { get; set; }
        public int[] ModifiedNums { get; set; }

        public override string ToString()
        {
            return string.Format("Nums:{0}, Val:{1}, Output:{2}, ModifiedNums{3}",
                Helper.FormatIntArray(Nums),
                Val,
                Output,
                Helper.FormatIntArray(ModifiedNums));
        }

        public static List<TestCase> ParseTestCaseFromTextFile(string filePath)
        {
            string[] fileContent = System.IO.File.ReadAllLines(filePath);

            List<TestCase> cases = new List<TestCase>();

            for (int i = 0; i < fileContent.Length; ++i)
            {
                string line = fileContent[i];

                switch (i % 5)
                {
                    case 0:
                        cases.Add(new TestCase());
                        cases.Last().Nums = Helper.ParseIntArray(line);
                        break;
                    case 1:
                        cases.Last().Val = Helper.ParseInt(line);
                        break;
                    case 2:
                        cases.Last().Output = Helper.ParseInt(line);
                        break;
                    case 3:
                        cases.Last().ModifiedNums = Helper.ParseIntArray(line);
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
            Solutions._0027.Solution solution = new Solutions._0027.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0027.txt");

            foreach (TestCase c in cases)
            {
                int[] dupNums = Helper.DupIntArray(c.Nums);
                var result = solution.RemoveElement(dupNums, c.Val);

                Assert.True(
                    Helper.Equals(result, c.Output)
                    && Helper.IntArrayEqualsRegardlessOfOrder(dupNums.Skip(0).Take(result).ToArray(), c.ModifiedNums),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}
