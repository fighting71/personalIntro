using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    public class ArrangingCoins
    {
        //Description:
        //You have a total of n coins that you want to form in a staircase shape, where every k-th row must have exactly k coins.

        //Given n, find the total number of full staircase rows that can be formed.

        //n is a non-negative integer and fits within the range of a 32-bit signed integer.

        public int Solution(int n)
        {
            int height = 0;

            while ((n -= ++height) > 0)
            {
            }

            return n == 0 ? height : --height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int OtherSolution(int n)
        {
            return (int) ((-1 + Math.Sqrt(1 + 8 * (long) n)) / 2);
        }
    }
}