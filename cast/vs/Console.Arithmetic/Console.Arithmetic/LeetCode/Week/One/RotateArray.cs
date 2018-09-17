using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/rotate-array/description/
    ///
    /// explain:Given an array, rotate the array to the right by k steps, where k is non-negative.
    /// 
    /// </summary>
    public class RotateArray
    {
//        Note:
//
//        Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
//            Could you do it in-place with O(1) extra space?

        public void Simple(int[] nums, int k)
        {
            int[] newArr = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
                newArr[i] = nums[(k + i) % nums.Length];

            Array.Copy(newArr, nums, newArr.Length);

            for (int i = 0; i < nums.Length; i++)
                nums[i] = newArr[i];
        }

        public void Solution(int[] nums, int k)
        {
            k = k % nums.Length;

            if (k == 0)
                return;

            int[] arr = new int[k];

            for (int i = 0; i < k; i++)
                arr[k - i - 1] = nums[nums.Length - 1 - i];

            for (int i = nums.Length - 1; i >= k; i--)
                nums[i] = nums[i - k];

            for (int i = 0; i < k; i++)
                nums[i] = arr[i];

        }

        public void OtherSolution(int[] nums, int k)//12345678  2 
        {
            k = k % nums.Length;
            int count = 0;
            for (int start = 0; count < nums.Length; start++)
            {
                int current = start;
                int prev = nums[start];
                do
                {
                    int next = (current + k) % nums.Length;
                    int temp = nums[next];
                    nums[next] = prev;
                    prev = temp;
                    current = next;
                    count++;

                    Console.WriteLine(JsonConvert.SerializeObject(nums));

                } while (start != current);
            }

        }
    }
}