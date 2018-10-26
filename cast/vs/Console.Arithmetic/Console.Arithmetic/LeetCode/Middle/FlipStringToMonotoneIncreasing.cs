using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Middle
{
    /// <summary>
    ///
    /// source:https://leetcode.com/problems/flip-string-to-monotone-increasing/
    ///
    /// description:
    ///
    ///     A string of '0's and '1's is monotone increasing if it consists of some number of '0's (possibly 0), followed by some number of '1's (also possibly 0.)
    ///     We are given a string S of '0's and '1's, and we may flip any '0' to a '1' or a '1' to a '0'.
    /// 
    ///     Return the minimum number of flips to make S monotone increasing.
    ///
    /// Note:
    ///     1 &lt;= S.length &lt;= 20000
    ///     S only consists of '0' and '1' characters.
    /// 
    /// </summary>
    public class FlipStringToMonotoneIncreasing
    {
        /// <summary>
        /// 存在bug....
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int Simple(string str)
        {
            //获取左右两边的0数  leftZeroNum  rightZeroNum  取最小值 minZeroNum

            //获取中间部分的0 和 1 数  centerZeroNum  centerOneNum 取最大值 

            //比较 centerZeroNum + minZeroNum 与 centerOneNum 的值   取最小值 则得到结果

            //跳过最后已排序好的数
            var len = str.Length;

            while (--len >= 0 && str[len] == '1')
            {
            }

            if (len < 1) return 0;

            int leftZeroNum = 0, rightZeroNum = 0;

            while (leftZeroNum <= len && str[leftZeroNum++] - '0' != 1)
            {
            }

            while (rightZeroNum++ <= len && str[len - rightZeroNum] - '0' != 1)
            {
            }

            int[] arr = new int[2];
            leftZeroNum--;

            for (int k = leftZeroNum; k <= len - (rightZeroNum); k++)
            {
                arr[str[k] - '0']++;
            }

            return Math.Min(arr[1], (rightZeroNum + arr[0]));
        }

        public int Solution(string str)
        {
            List<int> arr = new List<int>();
            var temp = 0;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == '1')
                {
                    if (temp > 0)
                    {
                        arr.Add(temp);
                        temp = 0;
                    }
                }
                else
                {
                    if (temp > 0)
                    {
                    }
                }

                temp++;
            }

            //            var needChangeZeroCount = 0;
            //            var needChangeOneCount = 0;
            //            var count = 0;
            //            bool hasStart = false;
            //
            //            for (int i = str.Length - 1; i >= 0; i--)
            //            {
            //                if (str[i] == '1')
            //                {
            //                    if (count > 0)
            //                    {
            //                        needChangeZeroCount += count;
            //                        count = 0;
            //                    }
            //
            //                    if (hasStart)
            //                    {
            //                        needChangeOneCount++;
            //                    }
            //                }
            //                else
            //                {
            //                    if (!hasStart)
            //                    {
            //                        hasStart = true;
            //                    }
            //
            //                    count++;
            //                }
            //            }
            //
            //            return Math.Min(needChangeOneCount, needChangeZeroCount);
            return 0;
        }

        /// <summary>
        /// source:https://leetcode.com/problems/flip-string-to-monotone-increasing/discuss/183896/Prefix-Suffix-Java-O(N)-One-Pass-Solution-Space-O(1)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int OtherSolution(string str)
        {
            if (str == null || str.Length <= 0)
                return 0;

            char[] sChars = str.ToCharArray();
            int flipCount = 0;
            int onesCount = 0;

            for (int i = 0; i < sChars.Length; i++)
            {
                if (sChars[i] == '0')
                {
                    if (onesCount == 0) continue;
                    flipCount++;
                }
                else
                {
                    onesCount++;
                }

                if (flipCount > onesCount)
                {
                    flipCount = onesCount;
                }
            }

            return flipCount;
        }

        /// <summary>
        /// source:https://leetcode.com/problems/flip-string-to-monotone-increasing/discuss/183851/C%2B%2BJava-4-lines-O(n)-or-O(1)-DP
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int OtherSolution2(string S)
        {
            int f0 = 0, f1 = 0;
            foreach (var t in S)
            {
                f0 += t - '0';
                f1 = Math.Min(f0, f1 + 1 - (t - '0'));
            }

            return f1;
        }
    }
}