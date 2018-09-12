using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    ///
    /// source:https://leetcode.com/problems/buddy-strings/description/
    /// intro:Given two strings A and B of lowercase letters, return true if and only if we can swap two letters in A so that the result equals B.
    /// </summary>
    public class BuddyStrings
    {
        //        Note:
        //
        //        0 <= A.length <= 20000
        //        0 <= B.length <= 20000
        //        A and B consist only of lowercase letters.

        public bool Simple(string str1, string str2)
        {
            if (str1.Length != str2.Length || str1.Length < 2 || str2.Length < 2)
            {
                return false;
            }

            int diffCount = 0;

            Dictionary<char, int> str1Map = new Dictionary<char, int>();

            char diffChar1 = default(char), diffChar2 = default(char);

            bool hasRepetition = false;

            for (int i = 0;
                i < str1.Length &&
                (diffCount < 2);
                i++)
            {
                var char1 = str1[i];
                var char2 = str2[i];

                if (!char1.Equals(char2))
                {
                    if (diffCount == 0)
                    {
                        diffChar1 = char1;
                        diffChar2 = char2;
                        diffCount++;
                    }
                    else if (diffCount == 1)
                    {
                        if (!(char2.Equals(diffChar1) && char1.Equals(diffChar2)))
                        {
                            return false;
                        }

                        diffCount++;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (!str1Map.TryAdd(char1, i))
                {
                    hasRepetition = true;
                }
            }

            if (diffCount == 0 && hasRepetition) //想复杂了。
            {
                return true;
            }

            return diffCount == 2;
        }

        public bool Solution(string str1, string str2)
        {
            if (str1.Length != str2.Length || str1.Length < 2 || str2.Length < 2)
                return false;

            if (str1.Equals(str2))
            {
                ISet<char> set = new HashSet<char>();
                foreach (var item in str1)
                    if (!set.Add(item))
                        return true;
                return false;
            }

            IList<int> diff = new List<int>();

            for (int i = 0; i < str1.Length; i++)
                if (str1[i] != str2[i])
                    diff.Add(i);

            return diff.Count == 2 && str1[diff[0]] == str2[diff[1]] && str1[diff[1]] == str2[diff[0]];

        }

        /// <summary>
        /// https://leetcode.com/problems/buddy-strings/discuss/141780/Easy-Understood
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public bool OtherSolution(string A, string B)
        {
            if (A.Length != B.Length) return false;
            if (A.Equals(B))
            {
                ISet<char> s = new HashSet<char>();
                foreach (char c in A) s.Add(c);
                return s.Count < A.Length;
            }

            List<int> dif = new List<int>();
            for (int i = 0; i < A.Length; ++i)
                if (A[i] != B[i])
                    dif.Add(i);
            return dif.Count == 2 && A[(dif[0])] == B[(dif[1])] && A[(dif[(1)])] == B[(dif[(0)])];
        }
    }
}