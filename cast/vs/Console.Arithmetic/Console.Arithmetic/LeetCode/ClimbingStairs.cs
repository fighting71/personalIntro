using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// soruce:https://leetcode.com/problems/climbing-stairs/description/
    ///
    /// description:
    ///      You are climbing a stair case. It takes n steps to reach to the top.
    ///      Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
    ///
    /// Note: Given n will be a positive integer.
    /// 
    /// </summary>
    public class ClimbingStairs
    {
        /// <summary>
        /// 最简版本  不过执行时间不符合=-=
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Simple(int n)
        {
            //通过计算
            //发现匹配值符合林辉三角。。。

            if (n <= 1) return 1;

            return Simple(n - 1) + Simple(n - 2);
        }

        /// <summary>
        /// 想到了一些思路 但没有完全实现出
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Solution(int n)
        {

            if (n <= 2) return n;

            int one_step_before = 2, two_step_before = 1, step_count = 0;

            for (int i = 2; i < n; i++)
            {
                step_count = one_step_before + two_step_before;
                two_step_before = one_step_before;
                one_step_before = step_count;
            }

            return step_count;

        }

        /// <summary>
        /// amazing 
        /// source:https://leetcode.com/problems/climbing-stairs/discuss/25299/Basically-it's-a-fibonacci.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int OtherSolution(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            int one_step_before = 2;
            int two_steps_before = 1;
            int all_ways = 0;

            for (int i = 2; i < n; i++)
            {
                all_ways = one_step_before + two_steps_before;
                two_steps_before = one_step_before;
                one_step_before = all_ways;

                Console.WriteLine(
                    $"{nameof(one_step_before)}:{one_step_before},{nameof(two_steps_before)}:{two_steps_before},{nameof(all_ways)}:{all_ways}");
            }

            return all_ways;
        }
    }
}