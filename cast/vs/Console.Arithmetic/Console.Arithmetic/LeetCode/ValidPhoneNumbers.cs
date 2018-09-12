using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/valid-phone-numbers/description/
    /// </summary>
    public class ValidPhoneNumbers
    {
        //Given a text file file.txt that contains list of phone numbers (one per line), write a one liner bash script to print all valid phone numbers.
        //
        //You may assume that a valid phone number must appear in one of the following two formats: (xxx) xxx-xxxx or xxx-xxx-xxxx. (x means a digit)
        //
        //You may also assume each line in the text file must not contain leading or trailing white spaces.

        //analysis:

        //rules:(xxx) xxx-xxxx or xxx-xxx-xxxx.

        public string[] rules = new[] {"(xxx) xxx-xxxx", "xxx-xxx-xxxx"};

        /// <summary>
        /// convention
        ///
        /// first step:暴力破解...
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string Simple(string phone)
        {
            phone = phone.Trim();

            var arr = phone.Split(' ');

            if (arr.Length == 1)
            {
                if (phone.Length != rules[rules.Length - 1].Length)
                {
                    return string.Empty;
                }

                for (int i = 0; i < phone.Length; i++)
                {
                    var item = phone[0];

                    if (item.Equals('-'))
                    {
                        if (!(i == 3 || item == 6))
                        {
                            return string.Empty;
                        }
                    }
                    else if (!(item >= 49 && item < 59))
                    {
                        return string.Empty;
                    }
                }

                return phone;
            }
            else if (arr.Length == 2)
            {
                var str1 = arr[0];
                var str2 = arr[1];

                if (str1.Length != 5 || str2.Length != 8)
                {
                    return string.Empty;
                }

                for (int i = 0; i < str1.Length; i++)
                {
                    var item = str1[i];

                    if ((item.Equals('(') && i == 0) || item.Equals(')') && i == str1.Length - 1)
                    {
                    }
                    else if (!(item >= 49 && item < 59))
                    {
                        return string.Empty;
                    }
                }

                for (int i = 0; i < str2.Length; i++)
                {
                    var item = str2[i];
                    if (item.Equals('-') && i == 3)
                    {
                    }
                    else if (!(item >= 48 && item < 59))
                    {
                        return string.Empty;
                    }
                }

                return phone;
            }

            return string.Empty;
        }

        /// <summary>
        /// 优化算法  效率提升了~
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string Solution(string phone)
        {
            string[] ruleArr = new[] {"(xxx) xxx-xxxx", "xxx-xxx-xxxx"};

            phone = phone.Trim();

            if (phone.Length != ruleArr[0].Length && phone.Length != ruleArr[1].Length)
            {
                return string.Empty;
            }

            var index = 0;

            for (int i = 0; i < phone.Length; i++, index++)
            {
                var item = phone[i];

                if ((item.Equals('(') && i == 0 ||
                     item.Equals(')') && i == 4) ||
                    (item.Equals(' ') && i == 5) ||
                    (i != 0 && item.Equals('-') && index % 3 == 0))
                {
                    index--;
                }
                else if (item < 48 || item > 57)
                {
                    return string.Empty;
                }
            }

            return index == 10 ? phone : string.Empty;
        }

        /// <summary>
        /// 使用其他语言的=-=
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public string OtherSolution(string phone)
        {
            return string.Empty;
        }

    }
}