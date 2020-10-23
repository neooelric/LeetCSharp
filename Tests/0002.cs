using System.Collections.Generic;
using System.Linq;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0002
{
    public class TestCase
    {
        public ListNode L1 { get; set; }
        public ListNode L2 { get; set; }

        public ListNode Output { get; set; }

        public override string ToString()
        {
            return string.Format(
                "L1:{0}, L2:{1}, Output:{2}",
                Helper.FormatLinkedList(L1),
                Helper.FormatLinkedList(L2),
                Helper.FormatLinkedList(Output)
            );
        }

        public static List<TestCase> ParseTestCasesFromTextFile(string filePath)
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
                        cases.Last().L1 = Helper.ParseLinkedList(line);
                        break;
                    case 1:
                        cases.Last().L2 = Helper.ParseLinkedList(line);
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
            Solutions._0002.Solution solution = new Solutions._0002.Solution();
            List<TestCase> cases = TestCase.ParseTestCasesFromTextFile(@"./0002.txt");

            foreach(TestCase c in cases)
            {
                ListNode result = solution.AddTwoNumbers(c.L1, c.L2);

                Assert.True(
                    Helper.LinkedListEquals(result, c.Output),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, Helper.FormatLinkedList(result))
                    );
            }

        }
    }
}