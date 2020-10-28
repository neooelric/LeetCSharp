
using System.Collections.Generic;
using System.Linq;
using Utilities;
using Xunit;

namespace Tests._0004
{
    public class TestCase
    {
        public int[] Nums1 { get; set; }
        public int[] Nums2 { get; set; }
        public double Median { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Nums1:{0}, Nums2:{1}, Median:{2}",
                Helper.FormatIntArray(Nums1),
                Helper.FormatIntArray(Nums2),
                Median);
        }

        public static List<TestCase> ParseTestCasesFromTextFile(string filePath)
        {
            string[] fileContent = System.IO.File.ReadAllLines(filePath);

            List<TestCase> cases = new List<TestCase>();

            for(int i = 0; i < fileContent.Length; ++i)
            {
                string line = fileContent[i];

                switch(i % 4)
                {
                    case 0:
                        cases.Add(new TestCase());
                        cases.Last().Nums1 = Helper.ParseIntArray(line);
                        break;
                    case 1:
                        cases.Last().Nums2 = Helper.ParseIntArray(line);
                        break;
                    case 2:
                        cases.Last().Median = Helper.ParseDouble(line);
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
            Solutions._0004.Solution solution = new Solutions._0004.Solution();

            List<TestCase> cases = TestCase.ParseTestCasesFromTextFile(@"./0004.txt");

            foreach (TestCase c in cases)
            {
                double result = solution.FindMedianSortedArrays(c.Nums1, c.Nums2);

                Assert.True(
                    Helper.Equals(result, c.Median),
                    string.Format("Case:{{{0}}}, Result:{{{1}}}", c, result)
                    );
            }
        }
    }
}