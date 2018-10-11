using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-integer/description/
    /// </summary>
    public class ReverseInteger
    {
        //Description:
        //Given a 32-bit signed integer, reverse digits of an integer.

        public int Solution(int num)
        {
            var sum = 0;

            while (num != 0)
            {
                if (sum > 0 && (sum > int.MaxValue / 10 || (sum == int.MaxValue / 10 && num % 10 > 7)))
                {
                    return 0;
                }
                else if (sum < int.MinValue / 10 || (sum == int.MaxValue / 10 && num % 10 < -8))
                {
                    return 0;
                }

                sum *= 10;
                sum += num % 10;
                num = num / 10;
            }

            return sum;
        }

        /// <summary>
        /// https://leetcode.com/problems/reverse-integer/discuss/4060/My-accepted-15-lines-of-code-for-Java?page=2
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int OtherSolution(int x)
        {
            int result = 0;

            while (x != 0)
            {
                int tail = x % 10;
                int newResult = result * 10 + tail;
                if (newResult / 10 != result)//溢出后无法复原与上一次向匹配 当数字溢出时 会进行重新计算。
                {
                    return 0;
                }

                result = newResult;
                x = x / 10;
            }

            return result;
        }
    }
}