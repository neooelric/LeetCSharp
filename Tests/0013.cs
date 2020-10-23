
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests._0013
{
    public class TestCase
    {
        public string S { get; set; }
        public int Output { get; set; }

        public override string ToString()
        {
            return string.Format("S:\"{0}\", Output:{1}", S, Output);
        }

        public static List<TestCase> ParseTestCaseFromTextFile(string filePath)
        {
            string[] fileContent = System.IO.File.ReadAllLines(filePath);

            List<TestCase> cases = new List<TestCase>();

            for (int i = 0; i < fileContent.Length; ++i)
            {
                string line = fileContent[i];

                switch(i % 3)
                {
                    case 0:
                        cases.Add(new TestCase());
                        cases.Last().S = line;
                        break;
                    case 1:
                        cases.Last().Output = int.Parse(line);
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
            Solutions._0013.Solution solution = new Solutions._0013.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0013.txt");

            foreach (TestCase c in cases)
            {
                int result = solution.RomanToInt(c.S);

                Assert.True(
                    result == c.Output,
                    string.Format("Case{{{0}}}, Result:{{{1}}}", c, result)
                );
            }
        }

    }
}
