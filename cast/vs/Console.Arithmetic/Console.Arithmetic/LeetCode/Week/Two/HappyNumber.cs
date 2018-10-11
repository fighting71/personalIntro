using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    /// <summary>
    /// source:https://leetcode.com/problems/happy-number/description/
    /// </summary>
    public class HappyNumber
    {
        //Description:

        //Write an algorithm to determine if a number is "happy".

        //A happy number is a number defined by the following process:
        // Starting with any positive integer,
        // replace the number by the sum of the squares of its digits,
        // and repeat the process until the number equals 1 (where it will stay),
        // or it loops endlessly in a cycle which does not include
        // 1. Those numbers for which this process ends in 1 are happy numbers.

        #region Simple

        public int count = 0;

        /// <summary>
        /// Accept~
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool Simple(int n)
        {
            count++;

            int sum = GetNextNum(n);

            if (sum != 1)
            {
                if (count > 1024)
                {
                    count = 0;
                    return false;
                }
                else
                {
                    return Simple(sum);
                }
            }

            return true;
        }

        public int GetNextNum(int num)
        {
            int sum = 0, remainder;

            while (num != 0)
            {
                remainder = num % 10;

                num = num / 10;

                sum += remainder * remainder;
            }

            return sum;
        }

        #endregion

        #region OtherSolution
        
        /// <summary>
        /// source: https://leetcode.com/problems/happy-number/discuss/56917/My-solution-in-C(-O(1)-space-and-no-magic-math-property-involved-)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool OtherSolution(int n)
        {
            int slow, fast;
            slow = fast = n;
            do
            {
                slow = GetNextNum(slow);
                fast = GetNextNum(GetNextNum(fast));
            } while (slow != fast);//Brilliant

            return slow == 1;
        }

        #endregion
    }
}