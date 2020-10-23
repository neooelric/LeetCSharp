
using System.Collections.Generic;
using System.Linq;
using Utilities;
using Xunit;

namespace Tests._0005
{
    public class TestCase
    {
        public string S { get; set; }
        public string[] PossibleOutput { get; set; }

        public override string ToString()
        {
            return string.Format("S:{0}, PossibleOutput:{1}", S, PossibleOutput);
        }

        public static List<TestCase> ParseTestCasesFromTextFile(string filePath)
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
                        cases.Last().S = Helper.ParseString(line);
                        break;
                    case 1:
                        cases.Last().PossibleOutput = Helper.ParseStringArray(line);
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
            Solutions._0005.Solution solution = new Solutions._0005.Solution();

            List<TestCase> cases = TestCase.ParseTestCasesFromTextFile(@"./0005.txt");

            foreach(TestCase c in cases)
            {
                string result = solution.LongestPalindrome(c.S);

                Assert.True(
                    c.PossibleOutput.Contains(result),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}
