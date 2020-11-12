using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0026
{
    public class TestCase
    {
        public int[] Nums { get; set; }
        public int Output { get; set; }
        public int[] ModifiedNums { get; set; }

        public override string ToString()
        {
            return string.Format("Nums:{0}, Output:{1}, ModifiedNums:{2}",
                Helper.FormatIntArray(Nums),
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

                switch (i % 4)
                {
                    case 0:
                        cases.Add(new TestCase());
                        cases.Last().Nums = Helper.ParseIntArray(line);
                        break;
                    case 1:
                        cases.Last().Output = Helper.ParseInt(line);
                        break;
                    case 2:
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
            Solutions._0026.Solution solution = new Solutions._0026.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0026.txt");

            foreach (TestCase c in cases)
            {
                var dupNums = Helper.DupArray(c.Nums);
                var result = solution.RemoveDuplicates(dupNums);

                Assert.True(
                    Helper.Equals(result, c.Output)
                    && Helper.Equals(dupNums.Skip(0).Take(result).ToArray(), c.ModifiedNums),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}