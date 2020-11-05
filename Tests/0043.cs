using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0043
{
    public class TestCase
    {
        public string Num1 { get; set; }
        public string Num2 { get; set; }
        public string Output { get; set; }

        public override string ToString()
        {
            return string.Format("Num1:\"{0}\", Num2:\"{1}\", Output:\"{2}\"", Num1, Num2, Output);
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
                        cases.Last().Num1 = Helper.ParseString(line);
                        break;
                    case 1:
                        cases.Last().Num2 = Helper.ParseString(line);
                        break;
                    case 2:
                        cases.Last().Output = Helper.ParseString(line);
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
            Solutions._0043.Solution solution = new Solutions._0043.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0043.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.Multiply(c.Num1, c.Num2);

                Assert.True(
                    Helper.Equals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{\"{1}\"}}", c, result)
                    );
            }
        }

    }
}