using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{

    class Sort : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x - y;
        }
    }

    /// <summary>
    /// source:https://leetcode.com/problems/reverse-only-letters/description/
    /// </summary>
    public class ReverseOnlyLetters
    {

        //intro: 
        //Given a string S, return the "reversed" string where all characters that are not a letter stay in the same place, and all letters reverse their positions.

        //Note:

        //S.length <= 100
        //33 <= S[i].ASCIIcode <= 122 
        //S doesn't contain \ or "

        public string Simple(string str)
        {

            List<char> list = new List<char>();

            SortedDictionary<int, char> map = new SortedDictionary<int, char>(new Sort());

            for(int i = str.Length - 1; i >=0; i--)
            {

                if((str[i] <= (int)'z' && str[i]>= (int)'a') || (str[i] <= (int)'Z' && str[i] >= (int)'A'))
                {
                    list.Add(str[i]);
                }
                else
                {
                    map.Add(i, str[i]);
                }
            }

            foreach(var item in map)
            {
                list.Insert(item.Key, item.Value);
            }

            return new string(list.ToArray());

        }

        public string Solution(string str)
        {

            List<char> list = new List<char>();

            SortedDictionary<int, char> map = new SortedDictionary<int, char>(new Sort());

            for(int i = str.Length - 1; i >=0; i--)
            {
                if(char.IsLetter(str[i]))
                {
                    list.Add(str[i]);
                }
                else
                {
                    map.Add(i, str[i]);
                }
            }

            foreach(var item in map)
            {
                list.Insert(item.Key, item.Value);
            }

            return new string(list.ToArray());

        }

        /// <summary>
        /// source:https://leetcode.com/problems/reverse-only-letters/discuss/178419/C++JavaPython-Two-Pointers
        /// remark:amazing.
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string OtherSolution(string S)
        {
            StringBuilder sb = new StringBuilder(S);
            for (int i = 0, j = S.Length - 1; i < j; ++i, --j)
            {
                while (i < j && !char.IsLetter(sb[i])) ++i;//排除非字母位置
                while (i < j && !char.IsLetter(sb[j])) --j;//排除非字母位置
                if (i < j)
                {//执行首尾交换
                    sb[i] = S[j];
                    sb[j] = S[i];
                }
            }
            return sb.ToString();
        }

    }
}
