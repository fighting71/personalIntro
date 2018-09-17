using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    /// <summary>
    /// source:https://leetcode.com/problems/valid-parentheses/description/
    /// </summary>
    public class ValidParentheses
    {
        //Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

        //        An input string is valid if:
        //
        //        Open brackets must be closed by the same type of brackets.
        //            Open brackets must be closed in the correct order.
        //            Note that an empty string is also considered valid.

        //(        40
        //)        41
        //[        91
        //]        93
        //{        123
        //}        125

        public bool Simple(string s)
        {
            var needChar = new Stack<int>();

            foreach (var item in s)
            {
                if (item == 40 || item == 91 || item == 123)
                {
                    needChar.Push(item + (item % 10 == 0 ? 1 : 2));
                }
                else if (needChar.Count == 0 || item != needChar.Pop())
                {
                    return false;
                }
            }

            return needChar.Count == 0;
        }

        /// <summary>
        /// perference 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Solution(string s)
        {

            //first so clear~
            var needChar = new Stack<int>();

            foreach (var item in s)
                if (item == 40 || item == 91 || item == 123)
                    needChar.Push(item + (item % 10 == 0 ? 1 : 2));
                else if (needChar.Count == 0 || item != needChar.Pop())
                    return false;

            return needChar.Count == 0;
        }
    }
}