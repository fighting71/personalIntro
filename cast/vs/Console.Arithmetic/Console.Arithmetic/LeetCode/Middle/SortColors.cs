using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Middle
{
    /// <summary>
    /// source:https://leetcode.com/problems/sort-colors/
    ///
    /// description:
    ///
    ///     Given an array with n objects colored red,
    ///     white or blue, sort them in-place so that objects of the same color are adjacent,
    ///     with the colors in the order red, white and blue.
    ///     Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.
    ///
    /// Note: You are not suppose to use the library's sort function for this problem.
    ///
    /// Follow up:
    ///    A rather straight forward solution is a two-pass algorithm using counting sort.
    ///    First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.
    ///    Could you come up with a one-pass algorithm using only constant space?
    /// 
    /// </summary>
    public class SortColors
    {
        public void Simple(int[] nums)
        {
            bool hasChange = false;
            int temp;
            for (int i = 0; i < nums.Length; i++)
            {
                hasChange = false;
                for (int j = 0; j < nums.Length - i - 1; j++)
                {

                    if (nums[j] > nums[j + 1])
                    {
                        temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                        if (!hasChange)
                        {
                            hasChange = true;
                        }
                    }

                }

                if (!hasChange)
                {
                    return;
                }

            }
        }

    }
}