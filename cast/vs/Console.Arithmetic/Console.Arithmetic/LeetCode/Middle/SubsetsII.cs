using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Middle
{
    /// <summary>
    /// source:https://leetcode.com/problems/subsets-ii/
    ///
    /// description:
    ///     Given a collection of integers that might contain duplicates, nums, return all possible subsets (the power set).
    ///
    /// Note: The solution set must not contain duplicate subsets.
    /// 
    /// </summary>
    public class SubsetsII
    {
        public IList<string> GetArrage(IList<int> list)
        {
            IList<string> arrageList = new List<string>();

            string firstChar;

            for (int i = 0; i < list.Count; i++)
            {
                firstChar = list[i].ToString();

                for (int j = 0; j < list.Count - i; j++)
                {



                }
            }

            return arrageList;
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            list.Add(new List<int>());

            if (nums.Length == 0)
            {
                return list;
            }

            var distinct = nums.Distinct();

            foreach (var item in distinct)
            {
                list.Add(new List<int>()
                {
                    item
                });
            }

            return list;
        }
    }
}