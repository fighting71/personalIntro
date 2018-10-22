using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Middle
{
    /// <summary>
    /// source:https://leetcode.com/problems/is-subsequence/
    ///
    /// description:
    ///     Given a string s and a string t, check if s is subsequence of t.
    ///     You may assume that there is only lower case English letters in both s and t.
    ///     t is potentially a very long (length ~= 500,000) string, and s is a short string (&lt;=100).
    ///     A subsequence of a string is a new string which is formed from
    ///     the original string by deleting some(can be none) of the characters without disturbing the relative positions of the remaining characters.
    ///     (ie, "ace" is a subsequence of "abcde" while "aec" is not).
    ///
    /// Follow up:
    ///     If there are lots of incoming S, say S1, S2, ... ,
    ///     Sk where k >= 1B, and you want to check one by one to see if T has its subsequence.In this scenario, how would you change your code?
    /// 
    /// </summary>
    public class IsSubsequence
    {
        public bool Simple(string s, string t)
        {
            foreach (var item in s)
                if (!t.Contains(item))
                    return false;

            return true;
        }

        /// <summary>
        ///
        /// source:https://leetcode.com/problems/is-subsequence/discuss/87302/Binary-search-solution-for-follow-up-with-detailed-comments
        ///
        /// Follow-up: O(N) time for pre-processing, O(Mlog?) for each S.
        /// Eg-1. s="abc", t="bahbgdca"
        /// idx=[a={1,7}, b={0,3}, c={6}]
        ///  i=0 ('a'): prev=1
        ///  i=1 ('b'): prev=3
        ///  i=2 ('c'): prev=6 (return true)
        /// Eg-2. s="abc", t="bahgdcb"
        /// idx=[a={1}, b={0,6}, c={5}]
        ///  i=0 ('a'): prev=1
        ///  i=1 ('b'): prev=6
        ///  i=2 ('c'): prev=? (return false)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool OtherSolution(String s, String t)
        {
//            List<Integer>[] idx = new List[256]; // Just for clarity
//            for (int i = 0; i < t.length(); i++)
//            {
//                if (idx[t.charAt(i)] == null)
//                    idx[t.charAt(i)] = new ArrayList<>();
//                idx[t.charAt(i)].add(i);
//            }
//
//            int prev = 0;
//            for (int i = 0; i < s.length(); i++)
//            {
//                if (idx[s.charAt(i)] == null) return false; // Note: char of S does NOT exist in T causing NPE
//                int j = Collections.binarySearch(idx[s.charAt(i)], prev);
//                if (j < 0) j = -j - 1;
//                if (j == idx[s.charAt(i)].size()) return false;
//                prev = idx[s.charAt(i)].get(j) + 1;
//            }

            List<int>[] list = new List<int>[256];

            for (int i = 0; i < t.Length; i++)
            {
                if (list[t[i]] == null)
                    list[t[i]] = new List<int>();

                list[t[i]].Add(i);
            }

            int prev = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (list[s[i]] == null) return false;
                int j = Array.BinarySearch(list[s[i]].ToArray(), prev);
                if (j < 0) j = -j - 1;
                if (j == list[s[i]].Count) return false;
                prev = list[s[i]][j] + 1;
            }

            return true;
        }
    }
}