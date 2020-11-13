
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Tests._0037
{
    public class TestCase
    {
        public char[][] Board { get; set; }
        public char[][] Output { get; set; }

        public override string ToString()
        {
            return string.Format("Board:\r\n{0}\r\nOutput:\r\n{1}\r\n", Helper.FormatChar2DArrayAsMatrix(Board), Helper.FormatChar2DArrayAsMatrix(Output));
        }

        public static List<TestCase> ParseTestCaseFromTextFile(string filePath)
        {
            string[] fileContent = System.IO.File.ReadAllLines(filePath);

            List<TestCase> cases = new List<TestCase>();

            string matrixStr = "";
            for (int i = 0; i < fileContent.Length; ++i)
            {
                string line = fileContent[i];

                if (i == 0 || (line.StartsWith("[[") && fileContent[i - 1].StartsWith("-----")))
                {
                    cases.Add(new TestCase());
                }

                matrixStr += line;

                if (line.EndsWith("]]") && (i == fileContent.Length - 1 || fileContent[i + 1].StartsWith("-----")))
                {
                    cases.Last().Output = Helper.ParseChar2DArray(matrixStr);
                    matrixStr = "";
                }
                else if (line.EndsWith("]]"))
                {
                    cases.Last().Board = Helper.ParseChar2DArray(matrixStr);
                    matrixStr = "";
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
            Solutions._0037.Solution solution = new Solutions._0037.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0037.txt");

            foreach (TestCase c in cases)
            {
                var result = Helper.Dup2DArray(c.Board);
                solution.SolveSudoku(result);

                Assert.True(
                    Helper.ValueEquals(Helper.FormatChar2DArrayAsMatrix(result), Helper.FormatChar2DArrayAsMatrix(c.Output)),
                    string.Format("Case:\r\n{{\r\n{0}\r\n}}\r\nResult:\r\n{{\r\n{1}\r\n}}", c, Helper.FormatChar2DArrayAsMatrix(result))
                    );
            }
        }

    }
}
