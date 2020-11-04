
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Tests._0012
{
    public class TestCase
    {
        public int Num { get; set; }
        public string Output { get; set; }

        public override string ToString()
        {
            return string.Format("Num:{0}, Output:{1}", Num, Output);
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
                        cases.Last().Num = Helper.ParseInt(line);
                        break;
                    case 1:
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
            Solutions._0012.Solution solution = new Solutions._0012.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0012.txt");

            foreach (TestCase c in cases)
            {
                string result = solution.IntToRoman(c.Num);

                Assert.True(
                    Helper.Equals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}
