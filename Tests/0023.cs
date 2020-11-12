using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0023
{
    public class TestCase
    {
        public ListNode[] Lists { get; set; }
        public ListNode Output { get; set; }

        public override string ToString()
        {
            return string.Format("Lists:{0}, Output{1}", Helper.FormatLinkedListArray(Lists), Helper.FormatLinkedList(Output));
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
                        cases.Last().Lists = Helper.ParseLinkedListArray(line);
                        break;
                    case 1:
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
            Solutions._0023.Solution solution = new Solutions._0023.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0023.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.MergeKLists(Helper.DupLinkedListArray(c.Lists));

                Assert.True(
                    Helper.ListEquals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, Helper.FormatLinkedList(result))
                    );
            }
        }

    }
}