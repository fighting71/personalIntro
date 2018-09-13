using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/can-place-flowers/description/
    ///
    /// intro:
    /// 
    /// </summary>
    public class CanPlaceFlowers
    {
        //Description:
        //        Suppose you have a long flowerbed in which some of the plots are planted and some are not.However, flowers cannot be planted in adjacent plots - they would compete for water and both would die.

        //            Given a flowerbed(represented as an array containing 0 and 1, where 0 means empty and 1 means not empty), and a number n, return if n new flowers can be planted in it without violating the no-adjacent-flowers rule.

//        Note:
//        The input array won't violate no-adjacent-flowers rule.
//            The input array size is in the range of[1, 20000].
//        n is a non-negative integer which won't exceed the input array size.

        public bool Simple(int[] flowerbed, int n)
        {
            //每三个空白处可放置一个花圃
            //五个空白处可放置二个花圃
            //七个空白处可放置三个花圃
            //3 + (n-1)*2 可放置n个花圃
            //3 + (n-1)*2 >> Place #n flower bed

            //特殊：边界处可视为增加一个
            //special: The border can be seen as adding one

            int placeLength = 0;

            int count = 0;

            for (int i = 0; i < flowerbed.Length && placeLength < n; i++)
                if (flowerbed[i] == 0) //blank
                {
                    if (i == 0)
                        count++;

                    if (i == flowerbed.Length - 1)
                        count++;

                    count++;

                    for (i++; i < flowerbed.Length; i++)
                        if (flowerbed[i] == 0)
                            if (i == flowerbed.Length - 1)
                                count += 2;
                            else
                                count++;
                        else
                            break;

                    if (count >= 3)
                        placeLength += (count - 3) / 2 + 1; //record length

                    count = 0; //repetition count
                }

            return placeLength >= n;
        }

        /// <summary>
        /// source:https://leetcode.com/problems/can-place-flowers/discuss/103898/Java-Greedy-solution-O(flowerbed)-beats-100
        ///
        /// remark:很不错的解决方案 容易理解
        /// diff：此方法改变了原数组 复杂度低于Simple 但Simple尚未改变原数组
        /// </summary>
        /// <param name="flowerbed"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool OtherSolution(int[] flowerbed, int n)
        {
            int count = 0;
            for (int i = 0; i < flowerbed.Length && count < n; i++)
            {
                if (flowerbed[i] == 0)
                {
                    //get next and prev flower bed slot values. If i lies at the ends the next and prev are considered as 0. 
                    int next = (i == flowerbed.Length - 1) ? 0 : flowerbed[i + 1];
                    int prev = (i == 0) ? 0 : flowerbed[i - 1];
                    if (next == 0 && prev == 0)
                    {
                        flowerbed[i] = 1;
                        count++;
                    }
                }
            }

            return count == n;
        }
    }
}