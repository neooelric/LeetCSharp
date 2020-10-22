
using System;

namespace Solutions._0004
{
    /*
    let "numsAll" be the merged array which has all numbers in "nums1" and "nums2",

    then the problem become : find the middle position number(s)(when the numsAll.Length is even, middle position has two numbers) in numsAll.

    if "numsAll" is truly exists, then the problem will be very easy:
        answer == (numsAll[(numsAll.Length - 1)/2] + numsAll[numsAll.Length/2]) / 2

    unforturnately, the merge operation's complexity is O(m+n), we can not truly have the "numsAll", we have to change our mind.

    ----------

    though, we can not have the really "numsAll", but let's assume it is there.

    let's cut it from the middle, split it into two part : "leftNumsAll" and "rightNumsAll", 
        leftNumsAll.Length == numsAll.Length / 2
        rightNumsAll.Length == (numsAll.Length + 1) / 2
    if "numsAll.Length" is a odd, then "rightNumsAll" has one more number than "leftNumsAll"

    apparently:
        numsAll.Length      == nums1.Length + nums2.Length;

        leftNumsAll.Length  == numsAll.Length / 2;
                            == (nums1.Length + nums2.Length) / 2;

        rightNumsAll.Length == (numsAll.Length + 1) / 2;
                            == (nums1.Length + nums2.Length + 1) / 2;
    
    here we introduce two unknows:
        "x" : it's the count of numbers which originally in "nums1" and now in "leftNumsAll"
        "y" : it's the count of numbers which originally in "nums2" and now in "leftNumsAll"
    so:
        leftNumsAll.Length == (nums1.Length + nums2.Length) / 2 
                           == x + y;
    so:
        y = (nums1.Length + nums2.Length) / 2 - x

    here is the intresting part: because all arrays we mentioned before are sorted, that means:
        leftNumsAll  == MERGE(nums1[0 .. x - 1], nums2[0 .. y - 1])
        rightNumsAll == MERGE(nums1[x .. ]     , nums2[y .. ])
            (in corner cases, like x == 0,            nums1[0 .. x - 1] should be an empty array)
            (in corner cases, like x == nums1.Length, nums1[x .. ]      should be an empty array)

        leftNumsAll.Last   == MAX(nums1[x-1], nums2[y-1])
        rightNumsAll.First == MIN(nums1[x], nums2[y])
        
        the final Median Value == rightNumsAll.Length > leftNumsAll.Length ? rightNumsAll.First : (leftNumsAll.Last + rightNumsAll.First) / 2.0;

    here, the problem become : find the correct value of "x" between range  [0 .. nums1.Length], we can iterate all posibility to find out,
    but under the problem's restriction, we have to find a way which complexity is under O(log(nums1.Length + nums2.Length))
    the most natural thought is : binary search

    in order to using binary search, we have to know : 
        when we guess a wrong value of "x", how to adjust it in next iteration, let it more closer to the real value ?

    here is the four key element:
        leftNumsAll.Last   == MAX(        nums1[x - 1],         nums2[y - 1]        )
        rightNumsAll.First == MIN(        nums1[x],             nums2[y]            )
    two values in first row shoule be all <= than two values in second row, because leftNumsAll[..] <= rightNumsAll[..]
    so, 
        if(x' > x) {
            nums1[x' - 1] will be greater than nums2[y'], which should be not
        }
        if(x' < x) {
            nums2[y' - 1] will be greater than nums1[x'], which should be not
        }

    so, the binary search iteration logic will be :
        if(leftNumsAll.Last > rightNumsAll.First) (
            if(nums1[x' - 1] > nums2[y']) {
                x' should be more less
            } else if(nums2[y' - 1] > nums1[x']) {
                x' should be more great
            }
        ) else {
            we found the real x
        }

    but be careful with the corner iteration :
        when iterate x' == 0 or x' == nums1.Length, please handle index of of range properly

    ----------
    */
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                int[] tmp = nums1;
                nums1 = nums2;
                nums2 = tmp;
            }

            if (nums1.Length == 0)
            {
                if(nums2.Length == 0)
                {
                    return 0.0;
                }

                return (nums2[(nums2.Length - 1) / 2] + nums2[nums2.Length / 2]) / 2.0;
            }

            int leftBoundOfX = 0;
            int rightBoundOfX = nums1.Length;

            while (leftBoundOfX <= rightBoundOfX)
            {
                int x = (leftBoundOfX + rightBoundOfX) / 2;
                int y = (nums1.Length + nums2.Length) / 2 - x;

                int leftNumsAll_Last;
                int rightNumsAll_First;

                if (x == 0)
                {
                    leftNumsAll_Last = nums2[y - 1];
                    rightNumsAll_First = (y == nums2.Length) ? nums1[x] : Math.Min(nums1[x], nums2[y]);
                }
                else if(x == nums1.Length)
                {
                    leftNumsAll_Last = (y == 0) ? nums1[x - 1] : Math.Max(nums1[x-1], nums2[y-1]);
                    rightNumsAll_First = nums2[y];
                }
                else
                {
                    rightNumsAll_First = Math.Min(nums1[x], nums2[y]);
                    leftNumsAll_Last = Math.Max(nums1[x-1], nums2[y-1]);
                }

                if (leftNumsAll_Last > rightNumsAll_First)
                {
                    if (x == 0 || nums2[y - 1] > nums1[x])
                    {
                        leftBoundOfX = x + 1;
                    }
                    else if (x == nums1.Length || nums1[x - 1] > nums2[y])
                    {
                        rightBoundOfX = x - 1;
                    }
                }
                else
                {
                    if ((nums1.Length + nums2.Length) % 2 == 0)
                    {
                        return (leftNumsAll_Last + rightNumsAll_First) / 2.0;
                    }
                    else
                    {
                        return rightNumsAll_First;
                    }
                }
            }

            return 0.0;
        }
    }
}