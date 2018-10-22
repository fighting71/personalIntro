using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/heaters/description/
    ///
    /// description:
    ///
    ///     Winter is coming! Your first job during the contest is to design a standard heater with fixed warm radius to warm all the houses.
    ///     Now, you are given positions of houses and heaters on a horizontal line, find out minimum radius of heaters so that all houses could be covered by those heaters.
    ///     So, your input will be the positions of houses and heaters seperately, and your expected output will be the minimum radius standard of heaters.
    ///
    /// Note:
    ///    Numbers of houses and heaters you are given are non-negative and will not exceed 25000.
    ///    Positions of houses and heaters you are given are non-negative and will not exceed 10^9.
    ///    As long as a house is in the heaters' warm radius range, it can be warmed.
    ///    All the heaters follow your radius standard and the warm radius will the same.
    ///
    /// remark: has skip
    /// 
    /// </summary>
    public class Heaters
    {
        /// <summary>
        /// error
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="heaters"></param>
        /// <returns></returns>
        public int Simple(int[] houses, int[] heaters)
        {
            int maxBothLen = 0, maxLen, leftLen, rightLen, minBorderLen = 0;

            //step 1:获取暖气之间的最大距离

            for (var i = 0; i < heaters.Length; i++)
            {
                if (heaters[i] > houses[houses.Length - 1])
                    break;

                if (i < heaters.Length - 1 && heaters[i + 1] <= houses[houses.Length - 1] &&
                    maxBothLen < heaters[i + 1] - heaters[i] - 1)
                    maxBothLen = heaters[i + 1] - heaters[i] - 1;

                leftLen = Math.Abs(heaters[i] - houses[0]);
                rightLen = Math.Abs(heaters[i] - houses[houses.Length - 1]);
                maxLen = leftLen < rightLen ? leftLen : rightLen;
                if (i == 0 || maxLen < minBorderLen) minBorderLen = maxLen;
            }

            //step 2:获取暖气距离边界的最大距离
//            var maxLen = Math.Abs(heaters[0] - houses[0] > houses[houses.Length - 1] - heaters[heaters.Length - 1]
//                ? heaters[0] - houses[0]
//                : houses[houses.Length - 1] - heaters[heaters.Length - 1]);

            maxBothLen = maxBothLen / 2 + (maxBothLen % 2 == 0 ? 0 : 1);

            return minBorderLen > maxBothLen ? minBorderLen : maxBothLen;
        }

        public int Solution(int[] houses, int[] heaters)
        {

            Array.Sort(houses);

            Array.Sort(heaters);

            //step 1 :找出最大间距
            var maxSpace = 0;

            var i = 1;

            for (; i < heaters.Length; i++)
            {
                if (heaters[i] > houses[houses.Length - 1]) break;

                if (heaters[i] - heaters[i - 1] - 1 > maxSpace) maxSpace = heaters[i] - heaters[i - 1] - 1;
            }

            //step 2 :找出边界最少需要的距离
            var leftLen = Math.Abs(heaters[0] - houses[0]);
            var rightLen = Math.Abs(heaters[i - 1] - houses[houses.Length - 1]);
            var maxLen = leftLen > rightLen ? leftLen : rightLen;

            maxSpace = (maxSpace % 2 == 0 ? 0 : 1) + maxSpace / 2;

            return maxLen > maxSpace ? maxLen : maxSpace;
        }
    }
}