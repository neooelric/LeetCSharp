using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0048
{
    public class TestCase
    {
        public int[][] Matrix { get; set; }
        public int[][] Output { get; set; }

        public override string ToString()
        {
            return string.Format("Matrix:{0}, Output:{1}", Helper.FormatInt2DArray(Matrix), Helper.FormatInt2DArray(Output));
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
                        cases.Last().Matrix = Helper.ParseInt2DArray(line);
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
            Solutions._0048.Solution solution = new Solutions._0048.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0048.txt");

            foreach (TestCase c in cases)
            {
                var result = Helper.DupInt2DArray(c.Matrix);
                solution.Rotate(result);

                Assert.True(
                    Helper.Equals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, Helper.FormatInt2DArray(result))
                    );
            }
        }

    }
}