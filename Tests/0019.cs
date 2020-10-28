
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0019
{
    public class TestCase
    {
        public ListNode Head { get; set; }
        public int N { get; set; }
        public ListNode Output { get; set; }

        public override string ToString()
        {
            return string.Format("Head:{0}, N:{1}, Output:{2}", Helper.FormatLinkedList(Head), N, Helper.FormatLinkedList(Output));
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
                        cases.Last().Head = Helper.ParseLinkedList(line);
                        break;
                    case 1:
                        cases.Last().N = Helper.ParseInt(line);
                        break;
                    case 2:
                        cases.Last().Output = Helper.ParseLinkedList(line);
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
            Solutions._0019.Solution solution = new Solutions._0019.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0019.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.RemoveNthFromEnd(Helper.DupLinkedList(c.Head), c.N);

                Assert.True(
                    Helper.Equals(result, c.Output),
                    string.Format("Case{{{0}}}, Result:{{{1}}}", c, Helper.FormatLinkedList(result))
                    );
            }
        }

    }
}
