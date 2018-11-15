using System;
using Newtonsoft.Json;
using PartitionToKEqualSumSubsets.Solution;

namespace PartitionToKEqualSumSubsets
{
    /// <summary>
    /// source:
    ///     https://leetcode.com/problems/partition-to-k-equal-sum-subsets/
    ///
    /// description:
    ///     Given an array of integers nums and a positive integer k, find whether it's possible to divide this array into k non-empty subsets whose sums are all equal.
    ///
    /// Note:
    ///     1 &lt;= k &lt;= len(nums) &lt;= 16.
    ///     0 &lt; nums[i] &lt; 10000.
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            SimpleSolution solution = new SimpleSolution();

            var info = new Temp(){remark = "remark"};

            Console.WriteLine(JsonConvert.SerializeObject(info));

            Console.ReadKey(true);

            //            var clearUp = solution.ClearUp(new[] {4, 3, 2, 3, 5, 2, 1}, 4);
            //
            //            Console.WriteLine(clearUp);

            Console.WriteLine(solution.ClearUp(new[] { 4, 3, 6, 3, 5, 2, 1 }, 4));

            Console.ReadKey(true);

            Console.WriteLine("Hello World!");
        }
    }
}