using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    class Compare : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return x == y;
        }

        public int GetHashCode(int obj)
        {
            return obj.GetHashCode();
        }
    }

    public class RelativeRanks
    {
        //Description:
        //
        //Given scores of N athletes,
        //
        //find their relative ranks and the people with the top three highest scores,
        //
        //who will be awarded medals: "Gold Medal", "Silver Medal" and "Bronze Medal".

        //Note:
        //        N is a positive integer and won't exceed 10,000.
        //        All the scores of athletes are guaranteed to be unique.

        public string[] Simple(int[] nums)
        {
            string[] nameArr = {"Gold Medal", "Silver Medal", "Bronze Medal"};

            var map = nums.Distinct(new Compare()).OrderByDescending(u => u)
                .Select((value, index) =>
                    new {value, showName = (index < nameArr.Length ? nameArr[index] : (index + 1).ToString())})
                .ToDictionary(u => u.value);

            return nums.Select(u => map[u].showName).ToArray();
        }

        /// <summary>
        /// source:https://leetcode.com/problems/relative-ranks/discuss/98468/Easy-Java-Solution-Sorting.
        /// 无法处理同分。。。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public String[] OtherSolution(int[] nums)
        {
            int[][] pair = new int[nums.Length][];

            for (int i = 0; i < nums.Length; i++)
            {
                pair[i] = new int[2];
                pair[i][0] = nums[i];
                pair[i][1] = i;
            }

            Array.Sort(pair, (a, b) => (b[0] - a[0]));

            String[] result = new String[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    result[pair[i][1]] = "Gold Medal";
                }
                else if (i == 1)
                {
                    result[pair[i][1]] = "Silver Medal";
                }
                else if (i == 2)
                {
                    result[pair[i][1]] = "Bronze Medal";
                }
                else
                {
                    result[pair[i][1]] = (i + 1) + "";
                }
            }

            return result;
        }
    }
}