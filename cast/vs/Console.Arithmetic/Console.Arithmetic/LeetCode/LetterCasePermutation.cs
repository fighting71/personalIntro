using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
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
            for (int i = 0; i < numList.Count; i++) //error
            {
                charArr[numList[i]] = (char) (charArr[numList[i]] + 32);
                list.Add(new string(charArr));

                char[] newChar = (char[])charArr.Clone();
                for (int j = 0; j < i - 1; j++)
                {
                    newChar[j] = (char) (newChar[numList[j]] - 32);
                    list.Add(new string(newChar));
                }
            }

            return list;
        }
    }
}