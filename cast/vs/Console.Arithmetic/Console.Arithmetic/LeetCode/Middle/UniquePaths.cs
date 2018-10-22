using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Middle
{
    /// <summary>
    /// source:https://leetcode.com/problems/unique-paths/
    ///
    /// description:
    ///     A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
    ///     The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).
    ///     How many possible unique paths are there?
    ///
    /// Note: m and n will be at most 100.
    /// 
    /// </summary>
    public class UniquePaths
    {
        /// <summary>
        /// 经手动分析,形成的步骤符合杨辉三角...
        ///
        /// result:Runtime: 40 ms, faster than 93.42% of C# online submissions for Unique Paths.
        ///
        /// 运气好吗？  感觉中级的意外的轻松~
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Simple(int m, int n)
        {
            var sum = 1; //最后一层

            int[][] arr = new int[n - 1][]; //考虑note 话 此次数组大小并不算太大

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[m - 1];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (j == 0 || i == 0)
                        arr[i][j] = 1;
                    else
                        arr[i][j] = arr[i][j - 1] + arr[i - 1][j];

                    sum += arr[i][j];
                }
            }

            return sum;
        }
    }
}