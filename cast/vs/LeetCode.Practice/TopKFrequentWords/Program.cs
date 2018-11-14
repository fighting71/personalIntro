using System;
using Newtonsoft.Json;
using TopKFrequentWords.Solution;

namespace TopKFrequentWords
{
    /// <summary>
    /// source:https://leetcode.com/problems/top-k-frequent-words/
    ///
    /// intro:
    ///     Given a non-empty list of words, return the k most frequent elements.
    ///     Your answer should be sorted by frequency from highest to lowest.If two words have the same frequency, then the word with the lower alphabetical order comes first.
    ///
    /// Note:
    ///     You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
    ///     Input words contain only lowercase letters.
    ///
    /// Follow up:
    ///    Try to solve it in O(n log k) time and O(n) extra space.
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

//            ["i", "love", "leetcode", "i", "love", "coding"]
//            3
//            Output
//                ["i", "love", "leetcode"]
//            Expected
//                ["i", "love", "coding"]

            Simple demo = new Simple();
            var list = demo.TopKFrequent(new[]
            {
                "i", "love", "leetcode", "i", "love", "coding"
            }, 3);

            Console.WriteLine(JsonConvert.SerializeObject(list));

//            var strArr = "i,you,me,love,take,think,like".Split(",");
//            var rand = new Random();
//            for (int i = 0; i < 10; i++)
//            {
//                var arrLen = rand.Next(20) + 1;
//
//                string[] arr = new string[arrLen];
//
//                for (int j = 0; j < arrLen; j++)
//                {
//                    arr[j] = strArr[rand.Next(strArr.Length)];
//                }
//
//                var showCount = rand.Next(4) + 1;
//
//                var topKFrequent = demo.TopKFrequent(arr, showCount);
//
//                Console.WriteLine($@"
//words:{JsonConvert.SerializeObject(arr)}
//showCount:{showCount}
//result:{JsonConvert.SerializeObject(topKFrequent)}
//");
//            }

            Console.ReadKey(true);
        }
    }
}