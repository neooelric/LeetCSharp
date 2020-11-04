
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Tests._0028
{
    public class TestCase
    {
        public string Haystack { get; set; }
        public string Needle { get; set; }
        public int Output { get; set; }


        public override string ToString()
        {
            return string.Format("Haystack:{0}, Needle:{1}, Output:{2}", Haystack, Needle, Output);
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
                        cases.Last().Haystack = Helper.ParseString(line);
                        break;
                    case 1:
                        cases.Last().Needle = Helper.ParseString(line);
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
            Solutions._0028.Solution solution = new Solutions._0028.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0028.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.StrStr(c.Haystack, c.Needle);

                Assert.True(
                    Helper.Equals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }

    }
}
