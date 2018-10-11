using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    public class TwoSum
    {
        //Description:
        //Given an array of integers, return indices of the two numbers such that they add up to a specific target.

        //You may assume that each input would have exactly one solution, and you may not use the same element twice.

        public int[] Simple(int[] nums, int target)
        {

            Dictionary<int,int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
                if (dictionary.ContainsKey((target - nums[i])))
                    return new[] {dictionary[(target - nums[i])], i};
                else
                    dictionary.TryAdd(nums[i], i);

            return null;

        }

    }
}