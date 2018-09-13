using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/reverse-bits/description/
    ///
    /// intro:Reverse bits of a given 32 bits unsigned integer.
    /// 
    /// </summary>
    public class ReverseBits
    {
        //十进制转二进制
//        Console.WriteLine(Convert.ToString(69, 2));
////十进制转八进制
//        Console.WriteLine(Convert.ToString(69, 8));
////十进制转十六进制
//        Console.WriteLine(Convert.ToString(69, 16));
//
////二进制转十进制
//        Console.WriteLine(Convert.ToInt32(”100111101″, 2));
////八进制转十进制
//        Console.WriteLine(Convert.ToInt32(”76″, 8));
////十六进制转十进制
//        Console.WriteLine(Convert.ToInt32(”FF”, 16));

        public uint Solution(uint n)
        {

            var str = Convert.ToString(n, 2);

            Console.WriteLine("二进制值:" + str);

            while (str.Length < 32)
            {
                str = "0" + str; //自动补0
            }

            var result = Convert.ToInt32(new string(str.Reverse().ToArray()), 2);

            Console.WriteLine("反转结果:" + result);

            return (uint)result;

        }

    }
}