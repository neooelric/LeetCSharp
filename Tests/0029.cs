
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Tests._0029
{
    public class TestCase
    {
        public int Dividend { get; set; }
        public int Divisor { get; set; }
        public int Output { get; set; }

        public override string ToString()
        {
            return string.Format("Dividend:{0}, Divisor:{1}, Output:{2}", Dividend, Divisor, Output);
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
                        cases.Last().Dividend = Helper.ParseInt(line);
                        break;
                    case 1:
                        cases.Last().Divisor = Helper.ParseInt(line);
                        break;
                    case 2:
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
            Solutions._0029.Solution solution = new Solutions._0029.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0029.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.Divide(c.Dividend, c.Divisor);

                Assert.True(
                    Helper.Equals(result, c.Output),
                    string.Format("Case{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}
