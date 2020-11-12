
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Tests._0007
{
    public class TestCase
    {
        public int X { get; set; }
        public int Output { get; set; }

        public override string ToString()
        {
            return string.Format("X:{0}, Output:{1}", X, Output);
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
                        cases.Last().X = Helper.ParseInt(line);
                        break;
                    case 1:
                        cases.Last().Output = Helper.ParseInt(line);
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
            Solutions._0007.Solution solution = new Solutions._0007.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0007.txt");

            foreach (TestCase c in cases)
            {
                int result = solution.Reverse(c.X);

                Assert.True(
                    Helper.ValueEquals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}
