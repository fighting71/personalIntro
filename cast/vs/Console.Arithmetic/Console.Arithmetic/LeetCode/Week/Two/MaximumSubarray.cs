using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    /// <summary>
    /// @source:https://leetcode.com/problems/maximum-subarray/description/
    /// </summary>
    public class MaximumSubarray
    {
        //Description:

        //Given an integer array nums,
        //find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

        //Follow up:

        //If you have figured out the O(n) solution,
        // try coding another solution using the divide and conquer approach,
        // which is more subtle.


        public int Simple(int[] nums)
        {
            int largeNum = 0;


            # region cut arr

            int positiveSum = 0;

            int minusSum = 0;

            List<int> cutList = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    if (minusSum < 0)
                    {
                        cutList.Add(minusSum);

                        minusSum = 0;
                    }

                    positiveSum += nums[i]; //cut positive arr
                }
                else
                {
                    if (positiveSum > 0)
                    {
                        cutList.Add(positiveSum);
                        positiveSum = 0;
                    }

                    minusSum += nums[i]; //cut minus arr
                }
            }

            #endregion

            int firstIndex = -1;
            int lastIndex = -1;

            for (int i = 1; i < cutList.Count; i += 2)
            {
                if (cutList[i] + cutList[i - 1] >= 0)
                {
                    if (firstIndex == -1)
                    {
                        if (cutList[i - 1] > 0)
                        {
                            firstIndex = i - 1;
                            largeNum += cutList[i] + cutList[i - 1];
                        }
                        else
                        {
                            firstIndex = i;
                            largeNum += cutList[i];
                        }
                    }
                    else
                    {
                        if (i == cutList.Count - 1)
                        {
                            //...
                        }
                    }
                }
                //....
            }

            //... I give up =-=

            return largeNum;
        }

        /// <summary>
        /// source:https://leetcode.com/problems/maximum-subarray/discuss/20193/DP-solution-and-some-thoughts
        ///
        /// intro:amazing
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int OtherSoulution(int[] A)
        {
            int n = A.Length;
            int[] dp = new int[n];//dp[i] means the maximum subarray ending with A[i];
            dp[0] = A[0];
            int max = dp[0];

            for (int i = 1; i < n; i++)
            {
                dp[i] = A[i] + (dp[i - 1] > 0 ? dp[i - 1] : 0);//太神奇了...
                max = Math.Max(max, dp[i]);
            }

            return max;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int OtherSoulution2(int[] A)
        {
            int maxSoFar = A[0], maxEndingHere = A[0];
            for (int i = 1; i < A.Length; ++i)
            {
                maxEndingHere = Math.Max(maxEndingHere + A[i], A[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }
            return maxSoFar;
        }

    }
}