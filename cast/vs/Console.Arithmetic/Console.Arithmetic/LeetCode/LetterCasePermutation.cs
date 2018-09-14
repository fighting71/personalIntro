using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:
    /// 典型 BFS / DFS 问题 【】 ***
    /// </summary>
    public class LetterCasePermutation
    {
        //Description:
        //Given a string S, we can transform every letter individually to be lowercase or uppercase to create another string.
        //Return a list of all possible strings we could create.

        //Note:

        //S will be a string with length at most 12.
        //S will consist only of letters or digits.

        public IList<string> Simple(string str)
        {
            IList<string> list = new List<string>();

            IList<int> numList = new List<int>();

            char[] charArr = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                var item = str[i];
                if ((item >= 65 && item <= 90) || (item >= 97 && item <= 122))
                {
                    numList.Add(i);
                    charArr[i] = (char) (item > 90 ? (item - 32) : item);
                }
                else
                {
                    charArr[i] = item;
                }
            }

            list.Add(new string(charArr));
            for (int i = 0; i < numList.Count; i++) //error 组装方式不对  
            {
                charArr[numList[i]] = (char) (charArr[numList[i]] + 32);
                list.Add(new string(charArr));

                char[] newChar = (char[]) charArr.Clone();
                for (int j = 0; j < i - 1; j++)
                {
                    newChar[j] = (char) (newChar[numList[j]] - 32);
                    list.Add(new string(newChar));
                }
            }

            return list;
        }

        //abc
        //abc Abc 0 
        //abc aBc Abc ABc 1 
        //abc abC aBc aBC Abc AbC ABc ABC 2
        //source:https://leetcode.com/problems/letter-case-permutation/discuss/115485/Java-Easy-BFS-DFS-solution-with-explanation

        /// <summary>
        /// source:https://www.jianshu.com/p/70952b51f0c8
        ///
        /// type:learning
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public IList<string> BFSSolution(string str)
        {

            Queue<string> queue = new Queue<string>();

            queue.Enqueue(str);//加入顶点  置灰

            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] >= 48 && str[i] < 58) continue;

                int size = queue.Count;
                for (int j = 0; j < size; j++)
                {
                    var peek = queue.Dequeue();//取出灰点  置黑

                    var charArray = peek.ToCharArray();

                    //找到领点  置灰

                    charArray[i] = char.ToUpper(charArray[i]);
                    queue.Enqueue(new string(charArray));

                    charArray[i] = char.ToLower(charArray[i]);
                    queue.Enqueue(new string(charArray));

                }
            }

            return queue.ToArray();

        }

        public IList<string> DFSSolution(string str)
        {
            if (str == null)
            {
                return new List<string>();
            }

            IList<string> res = new List<string>();
            Helper(str, res, 0);
            return res;
        }

        public void Helper(string s, IList<string> res, int pos)
        {
            if (pos == s.Length)//所有顶点已全部访问过
            {
                res.Add(s);
                return;
            }
            if (s[pos] >= 48 && s[pos] <= 57)
            {
                Helper(s, res, pos + 1);
                return;
            }

            char[] chs = s.ToCharArray();
            chs[pos] = char.ToLower(chs[pos]);
            Helper(new string(chs), res, pos + 1);

            chs[pos] = char.ToUpper(chs[pos]);
            Helper(new string(chs), res, pos + 1);
        }

    }
}