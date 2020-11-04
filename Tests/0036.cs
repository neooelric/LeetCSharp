
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Tests._0036
{
    public class TestCase
    {
        public char[][] Board { get; set; }
        public bool Output { get; set; }

        public override string ToString()
        {
            return string.Format("Board:\r\n{0}\r\nOutput:{1}", Helper.FormatChar2DArray(Board), Output);
        }

        public static List<TestCase> ParseTestCaseFromTextFile(string filePath)
        {
            string[] fileContent = System.IO.File.ReadAllLines(filePath);

            List<TestCase> cases = new List<TestCase>();

            string matrixStr = "";
            for (int i = 0; i < fileContent.Length; ++i)
            {
                string line = fileContent[i];

                if(line.StartsWith("-----"))
                {
                    continue;
                }

                if(line.StartsWith("[[") || line.StartsWith(",["))
                {
                    matrixStr += line;
                    continue;
                }

                cases.Add(new TestCase());
                cases.Last().Board = Helper.ParseChar2DArray(matrixStr);
                cases.Last().Output = Helper.ParseBool(line);
                matrixStr = "";
            }

            return cases;
        }
    }

    public class Test
    {
        [Fact]
        public void RunTestCases()
        {
            Solutions._0036.Solution solution = new Solutions._0036.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0036.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.IsValidSudoku(c.Board);

                Assert.True(
                    Helper.Equals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}
