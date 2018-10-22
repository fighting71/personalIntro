using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Middle
{
    /// <summary>
    /// source:https://leetcode.com/problems/minimum-time-difference/
    ///
    /// description:
    ///     Given a list of 24-hour clock time points in "Hour:Minutes" format,
    ///     find the minimum minutes difference between any two time points in the list.
    ///
    /// Note:
    ///     The number of time points in the given list is at least 2 and won't exceed 20000.
    ///     The input time is legal and ranges from 00:00 to 23:59.
    ///
    /// remark:no enjoy   /./ feel unfunny
    /// 
    /// </summary>
    public class MinimumTimeDifference
    {
        public int Simple(IList<string> timePoints)
        {
            var enumerable = timePoints.Distinct().Select(u =>
            {
                var arr = u.Split(":");

                return int.Parse(arr[0]) * 60 + int.Parse(arr[1]);
            });

            return enumerable.Max() - enumerable.Min();

        }

        public int Solution(IList<string> timePoints)
        {

            int max = 0, min = 0;

            foreach (var item in timePoints)
            {
                var times = item.Split(":");

                var info = int.Parse(times[0]) * 60 + int.Parse(times[1]);



            }

            var enumerable = timePoints.Select(u =>
            {
                var arr = u.Split(":");

                var hour = int.Parse(arr[0]) * 60;

                return int.Parse(arr[0]) * 60 + int.Parse(arr[1]);
            });

            return enumerable.Max() - enumerable.Min();

        }

        /// <summary>
        /// source:https://leetcode.com/problems/minimum-time-difference/discuss/100640/Verbose-Java-Solution-Bucket
        /// </summary>
        /// <param name="timePoints"></param>
        /// <returns></returns>
        public int OtherSolution(List<String> timePoints)
        {
            bool[] mark = new bool[24 * 60];
            foreach (string time in timePoints)
            {
                String[] t = time.Split(":");
                int h = int.Parse(t[0]);
                int m = int.Parse(t[1]);
                if (mark[h * 60 + m]) return 0;
                mark[h * 60 + m] = true;
            }

            int prev = 0, min = int.MaxValue;
            int first = int.MaxValue, last = int.MinValue;
            for (int i = 0; i < 24 * 60; i++)
            {
                if (mark[i])
                {
                    if (first != int.MaxValue)
                    {
                        min = Math.Min(min, i - prev);
                    }
                    first = Math.Min(first, i);
                    last = Math.Min(last, i);
                    prev = i;
                }
            }

            min = Math.Min(min, (24 * 60 - last + first));

            return min;
        }

    }
}