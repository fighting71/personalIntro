using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    ///
    /// source:https://leetcode.com/problems/add-strings/description/
    ///
    /// Description:
    ///     Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.
    ///
    /// Note:
    ///    The length of both num1 and num2 is &lt; 5100.
    ///    Both num1 and num2 contains only digits 0-9.
    ///    Both num1 and num2 does not contain any leading zero.
    ///    You must not use any built-in BigInteger library or convert the inputs to integer directly.
    /// 
    /// </summary>
    public class AddStrings
    {

        /// <summary>
        /// 初版
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Simple(string num1, string num2)
        {
            int char1, char2, step = 0;

            string sum = "";

            for (int i = 1;; i++)
            {
                if (num1.Length > i)
                {
                    char1 = num1[num1.Length - i] - (int) '0';
                }
                else
                {
                    char1 = 0;
                }

                if (num2.Length > i)
                {
                    char2 = num2[num2.Length - i] - (int) '0';
                }
                else
                {
                    char2 = 0;
                }

                sum = (char1 + char2 + step) % 10 + sum;

                if (num1.Length <= i && num2.Length <= i)
                    break;

                step = (char1 + char2) / 10;
            }

            return sum;
        }

        /// <summary>
        /// 测试几遍就过了
        /// 处理没啥问题
        /// 可以简化一下~
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Solution(string num1, string num2)
        {
            int char1, char2, temp = 0;

            StringBuilder builder = new StringBuilder();

            for (int i = 1;; i++)
            {
                if (num1.Length < i && num2.Length < i)
                    break;

                if (num1.Length >= i)
                    char1 = num1[num1.Length - i] - (int) '0';
                else
                    char1 = 0;

                if (num2.Length >= i)
                    char2 = num2[num2.Length - i] - (int) '0';
                else
                    char2 = 0;

                builder.Insert(0, ((char1 + char2 + temp) % 10));

                temp = (char1 + char2 + temp) / 10;
            }

            if (temp == 1)
                builder.Insert(0, temp);

            return builder.ToString();
        }
    }
}