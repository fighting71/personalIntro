using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// 
    ///author:Monster
    /// source:https://leetcode.com/problems/non-decreasing-array/description/
    /// 
    ///question:
    ///  Given an array with n integers, your task is to check if it could become non-decreasing by modifying at most 1 element.
    ///  We define an array is non-decreasing if array[i] &lt;= array[i + 1] holds for every i(1 &lt;= i&lt;n).
    /// 
    /// summary:最后一个处理时间最少。，
    /// 
    /// </summary>
    public class NonDecreasingArray
    {
        public bool Simple(int[] nums)
        {
            int count = 0;

            if (nums.Length < 3)
            {
                return true;
            }

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (count > 1)
                {
                    return false;
                }

                if (nums[i] > nums[i + 1])
                {
                    count++;
                    nums[i + 1] = nums[i]; // 3 2 4
                }
            }

            return count < 2;
        }

        public bool CheckPossibility(int[] nums)
        {
            int count = 0; //[463,724,774,972,994,2,82,447]

            if (nums.Length < 3)
            {
                return true;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                if (count > 1)
                {
                    return false;
                }

                if (nums[i] < nums[i - 1])
                {
                    count++;

                    if (i != nums.Length - 1 && nums[i - 1] > nums[i + 1])
                    {
                        return false;
                    }

                    nums[i - 1] = nums[i];
                }
            }

            return count < 2;
        }

        /// <summary>
        /// source:https://leetcode.com/problems/non-decreasing-array/discuss/106818/Java-solution-7-liner.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool OtherSolution(int[] nums)
        {
            int n = nums.Length, count = 0;

            for (int i = 0; i + 1 < n; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    count++;
                    if (i > 0 && nums[i + 1] < nums[i - 1]) nums[i + 1] = nums[i];
                    else nums[i] = nums[i + 1];
                }
            }

            return count <= 1;
        }

        /// <summary>
        /// source:https://leetcode.com/problems/non-decreasing-array/discuss/106826/JavaC++-Simple-greedy-like-solution-with-explanation
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool OtherSolution2(int[] nums)
        {
            int cnt = 0; //the number of changes
            for (int i = 1; i < nums.Length && cnt <= 1; i++)
            {
                if (nums[i - 1] > nums[i]) //  4 3 1 
                {
                    cnt++;
                    if (i - 2 < 0 || nums[i - 2] <= nums[i]) nums[i - 1] = nums[i]; //modify nums[i-1] of a priority
                    else nums[i] = nums[i - 1]; //have to modify nums[i]
                }
            }

            return cnt <= 1;
        }
    }
}