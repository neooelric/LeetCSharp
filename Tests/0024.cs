using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._0024
{
    public class TestCase
    {
        public ListNode Head { get; set; }
        public ListNode Output { get; set; }

        public override string ToString()
        {
            return string.Format("Head:{0}, Output{1}", 
            Helper.FormatLinkedList(Head),
            Helper.FormatLinkedList(Output));
        }

        public static List<TestCase> ParseTestCaseFromTextFile(string filePath)
        {
            string[] fileContent = System.IO.File.ReadAllLines(filePath);

            List<TestCase> cases = new List<TestCase>();

            for(int i = 0; i < fileContent.Length; ++i)
            {
                string line = fileContent[i];

                switch(i % 3)
                {
                    case 0:
                        cases.Add(new TestCase());
                        cases.Last().Head = Helper.ParseLinkedList(line);
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
            Solutions._0024.Solution solution = new Solutions._0024.Solution();

            List<TestCase> cases = TestCase.ParseTestCaseFromTextFile(@"./0024.txt");

            foreach (TestCase c in cases)
            {
                var result = solution.SwapPairs(Helper.DupLinkedList(c.Head));

                Assert.True(
                    Helper.Equals(result, c.Output),
                    string.Format("Case{{{0}}}, Result:{{{1}}}", c, Helper.FormatLinkedList(result))
                    );
            }
        }
        
    }
}