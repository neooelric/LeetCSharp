using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using Utilities.LeetCodeDefinitions;
using Xunit;

namespace Tests._Helper.Dup
{
    public class Test
    {
        [Fact]
        public void TestDup2DArray()
        {
            int[][] int2DArray = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            int[][] dupInt2DArray = Helper.Dup2DArray(int2DArray);

            dupInt2DArray[1][1] = 10;

            Assert.True(dupInt2DArray[1][1] == 10 && int2DArray[1][1] == 5);

            int[][] nullInt2DArray = null;
            int[][] dupNullInt2DArray = Helper.Dup2DArray(nullInt2DArray);

            Assert.True(nullInt2DArray == null && dupNullInt2DArray == null);

            int[][] int2DArrayContainsNull = new int[][] { new int[] { 1, 2, 3 }, null, new int[] { 7, 8, 9 } };
            int[][] dupInt2DArrayContainsNull = Helper.Dup2DArray(int2DArrayContainsNull);

            int2DArrayContainsNull[1] = new int[] { 4, 5, 6 };
            dupInt2DArrayContainsNull[1] = new int[] { 40, 50, 60 };

            Assert.True(dupInt2DArrayContainsNull[1][1] == 50 && int2DArrayContainsNull[1][1] == 5);

            string[][] string2DArray = new string[][] { new string[] { "aa", "bb", "cc" }, new string[] { "dd", "ee", "ff" }, new string[] { "gg", "hh", "ii" } };
            string[][] dumpString2DArray = Helper.Dup2DArray(string2DArray);

            dumpString2DArray[1][1] = "zz";

            Assert.True(dumpString2DArray[1][1] == "zz" && string2DArray[1][1] == "ee");

            string[][] nullString2DArray = null;
            string[][] dupNullString2DArray = Helper.Dup2DArray(nullString2DArray);

            Assert.True(nullString2DArray == null && dupNullString2DArray == null);

            string[][] string2DArrayContainsNull = new string[][] { new string[] { "aa", "bb", "cc" }, null, new string[] { "gg", "hh", "ii" } };
            string[][] dupString2DArrayContainsNull = Helper.Dup2DArray(string2DArrayContainsNull);

            string2DArrayContainsNull[1] = new string[] { "dd", "ee", "ff" };
            dupString2DArrayContainsNull[1] = new string[] { "dddd", "eeee", "ffff" };

            Assert.True(dupString2DArrayContainsNull[1][1] == "eeee" && string2DArrayContainsNull[1][1] == "ee");
        }

        [Fact]
        public void TestDupArray()
        {
            int[] intArray = new int[] { 1, 2, 3 };
            int[] dupIntArray = Helper.DupArray(intArray);

            dupIntArray[1] = 20;

            Assert.True(dupIntArray[1] == 20 && intArray[1] == 2);

            int[] intNullArray = null;
            int[] dupIntNullArray = Helper.DupArray(intNullArray);

            Assert.True(intNullArray == null && dupIntNullArray == null);

            string[] stringArray = new string[] { "aa", "bb", "cc" };
            string[] dupStringArray = Helper.DupArray(stringArray);

            dupStringArray[1] = "bbbb";

            Assert.True(dupStringArray[1] == "bbbb" && stringArray[1] == "bb");

            string[] stringNullArray = null;
            string[] dupStringNullArray = Helper.DupArray(stringNullArray);

            Assert.True(stringNullArray == null && dupStringNullArray == null);
        }

        [Fact]
        public void TestDupLinkedList()
        {
            ListNode l1 = new ListNode(1, new ListNode(2, new ListNode(3, null)));
            ListNode dupL1 = Helper.DupLinkedList(l1);
            dupL1.next.val = 20;

            Assert.True(l1.next.val == 2 && dupL1.next.val == 20 && l1 != dupL1);

            ListNode l2 = null;
            ListNode dupL2 = Helper.DupLinkedList(l2);

            Assert.True(l2 == null && dupL2 == null);
        }

        [Fact]
        public void TestDupLinkedListArray()
        {
            ListNode[] arr = new ListNode[]{
                new ListNode(1, new ListNode(2, new ListNode(3, null))),
                new ListNode(4, new ListNode(5, new ListNode(6, null))),
                new ListNode(7, new ListNode(8, new ListNode(9, null))),
            };

            ListNode[] dupArr = Helper.DupLinkedListArray(arr);
            dupArr[0].next.val = 20;
            dupArr[1].next.val = 50;
            dupArr[2].next.val = 80;

            Assert.True(
                arr[0].next.val == 2 && dupArr[0].next.val == 20
                && arr[1].next.val == 5 && dupArr[1].next.val == 50
                && arr[2].next.val == 8 && dupArr[2].next.val == 80
                && arr[0] != dupArr[0]
                && arr[1] != dupArr[1]
                && arr[2] != dupArr[2]
            );

            ListNode[] nullArr = null;
            ListNode[] dupNullArr = Helper.DupLinkedListArray(nullArr);

            Assert.True(nullArr == null && dupNullArr == null);

            ListNode[] arrContainsNull = new ListNode[] {
                new ListNode(1, new ListNode(2, new ListNode(3, null))),
                null,
                new ListNode(7, new ListNode(8, new ListNode(9, null))),
            };
            ListNode[] dupArrContainsNull = Helper.DupLinkedListArray(arrContainsNull);

            arrContainsNull[0].val = 10;
            arrContainsNull[2].val = 70;

            Assert.True(arrContainsNull[1] == null
                && dupArrContainsNull[1] == null
                && arrContainsNull[0].val == 10
                && dupArrContainsNull[0].val == 1
                && arrContainsNull[2].val == 70
                && dupArrContainsNull[2].val == 7
            );

        }
    }
}