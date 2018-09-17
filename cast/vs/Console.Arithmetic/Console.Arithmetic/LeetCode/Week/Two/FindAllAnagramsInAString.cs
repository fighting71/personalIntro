using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    /// <summary>
    /// https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
    /// </summary>
    public class FindAllAnagramsInAString
    {
        //Description:

        //        Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.
        //
        //            Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.
        //
        //        The order of output does not matter.

        public List<int> Simple(string s, string p)
        {
            var list = new List<int>();

            if (s.Length < p.Length)
            {
                return list;
            }
            else if (s.Equals(p))
            {
                list.Add(0);
                return list;
            }

            var searchList = p.ToCharArray().ToList();

            var flagIndex = -1;

            for (var i = 0; i < s.Length; i++)
            {
                var item = s[i];

                if (searchList.Contains(item)) //是否存在选项
                {
                    if (flagIndex != -1 && i - flagIndex == p.Length - 1)
                    {
                        list.Add(flagIndex); //记录符合位置
                        searchList = p.ToCharArray().ToList(); //重置集合
                        i--; //重新执行
                        flagIndex = -1; //标记移除
                        continue;
                    }

                    if (searchList.Count == p.Length) flagIndex = i; //标记首位置

                    searchList.Remove(item); //移除已过滤选项
                }
                else
                {
                    if (searchList.Count != p.Length)
                    {
                        searchList = p.ToCharArray().ToList(); //重置集合
                        i--; //重新执行 -- 此处应根据移除项个数进行递减
                    }

                    flagIndex = -1; //标记移除
                }
            }

            return list;
        }

        public List<int> Solution(string s, string p)
        {
            List<int> list;

            if (s.Length < p.Length || (s.Length > 100 || p.Length > 20))
                return new List<int>();
            else if (s.Equals(p))
                return new List<int>() {0};

            list = new List<int>();

            var charList = p.ToCharArray().ToList();

            for (var i = 0; i < s.Length; i++)
                if (charList.Contains(s[i]))
                {
                    if (charList.Count == 1)
                    {
                        list.Add(i - p.Length + 1);
                        i -= p.Length - charList.Count;
                        charList = p.ToCharArray().ToList();
                        continue;
                    }

                    charList.Remove(s[i]);
                }
                else if (charList.Count < p.Length)
                {
                    i -= p.Length - charList.Count;
                    charList = p.ToCharArray().ToList();
                }

            return list;
        }

        public List<int> SubmitSolution(string s, string p)
        {
            List<int> list;

            if (s.Length < p.Length || (s.Length > 100 || p.Length > 20))
                return new List<int>();
            else if (s.Equals(p))
                return new List<int>() { 0 };

            list = new List<int>();

            var charList = p.ToCharArray().ToList();

            for (var i = 0; i < s.Length; i++)

                if (charList.Contains(s[i]))
                {
                    if (charList.Count == 1)
                    {
                        list.Add(i - p.Length + 1);
                        i -= p.Length - charList.Count;
                        charList = p.ToCharArray().ToList();
                        continue;
                    }

                    charList.Remove(s[i]);
                }
                else if (charList.Count < p.Length)
                {
                    i -= p.Length - charList.Count;
                    charList = p.ToCharArray().ToList();
                }

            return list;
        }

    }
}