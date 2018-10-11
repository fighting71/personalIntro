using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    /// <summary>
    /// source:https://leetcode.com/problems/power-of-three/description/
    /// </summary>
    public class PowerOfThree //PowerOfNumber
    {
        //Description:
        //Given an integer, write a function to determine if it is a power of three.

        public bool IsPowerOfThree(int n)
        {
            int num = n;
            int remainder = 0;


            while (num >= 3 && ((remainder = num % 3) == 0) && (num = num / 3) != 1)
            {
            }

            return num == 1 && remainder == 0;
        }

        public bool IsPowerOfNumber(int n, int number)
        {
            while (n >= number && ((n % number) == 0) && (n = n / number) != 1)
            {
            }

            return n == 1;
        }

        public bool OtherSolution(int n, int number)
        {
            int num = n;
            int remainder = 0;


            while (num >= number && ((remainder = num % number) == 0) && (num = num / number) != 1)
            {
            }

            return num == 1 && remainder == 0;
        }
    }
}