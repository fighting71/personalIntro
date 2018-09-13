using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/jewels-and-stones/description/
    /// </summary>
    public class JewelsAndStones
    {
        //Description:

        //You're given strings J representing the types of stones that are jewels, and S representing the stones you have.  Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.

        //The letters in J are guaranteed distinct, and all characters in J and S are letters.Letters are case sensitive, so "a" is considered a different type of stone from "A".

        //Note:
        //S and J will consist of letters and have length at most 50.
        //The characters in J are distinct.

        public int Simple(string jewels, string stones)
        {
            int count = 0;

            ISet<char> set = new HashSet<char>();

            foreach (var jewel in jewels)
            {
                set.Add(jewel);
            }

            foreach (var stone in stones)
            {
                if (set.Contains(stone))
                {
                    count++;
                }
            }

            return count;
        }

        public int OtherSolution(String J, String S)
        {
            bool[] arr = new bool[128];
            int count = 0;
            for (int i = 0; i < J.Length; i++)
            {
                arr[J[i]] = true;
            }

            for (int j = 0; j < S.Length; j++)
            {
                if (arr[S[j]])
                    count++;
            }

            return count;
        }
    }
}