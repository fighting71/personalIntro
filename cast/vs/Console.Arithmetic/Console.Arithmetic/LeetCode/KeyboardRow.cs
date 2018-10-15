using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/keyboard-row/description/
    /// </summary>
    public class KeyboardRow
    {

        //Description:

        //Given a List of words, 

        //return the words that can be typed using letters of alphabet on only one row's of American keyboard like the image below.

//Note:
//You may use one character in the keyboard more than once.
//You may assume the input string will only contain letters of alphabet.

        string[] keyCodeArr = {
            "zxcvbnm",
            "asdfghjkl",
            "qwertyuiop"
        };

        public string[] Simple(string[] words)
        {

            List<string> arr = new List<string>();

            foreach(var item in words)
            {

                if(item.Length == 1)
                {
                    arr.Add(item);
                    continue;
                }

                var lowerItem = item.ToLower();

                int searchScope = 0;

                for (int i = 0; i < keyCodeArr.Length; i++)
                {
                    if (keyCodeArr[i].Contains(lowerItem[0])){
                        searchScope = i;
                        break;
                    }
                }

                for (int i = 1; i < lowerItem.Length; i++)
                {
                    if (!keyCodeArr[searchScope].Contains(lowerItem[i]))
                    {
                        break;
                    }else if(i == lowerItem.Length - 1)
                    {
                        arr.Add(item);
                    }
                }

            }

            return arr.ToArray();

        }

        public string[] Solution(string[] words)
        {

            List<string> arr = new List<string>();

            foreach (var item in words)
            {
                
                var lowerItem = item.ToLower();

                int searchScope = 0;

                for (int i = 0; i < keyCodeArr.Length; i++)
                {
                    if (keyCodeArr[i].Contains(lowerItem[0]))
                    {
                        searchScope = i;
                        break;
                    }
                }

                bool canInput = true;

                for (int i = 1; i < lowerItem.Length; i++)
                {
                    if (!keyCodeArr[searchScope].Contains(lowerItem[i]))
                    {
                        canInput = false;
                        break;
                    }
                }

                if (canInput)
                {
                    arr.Add(item);
                }

            }

            return arr.ToArray();

        }

        /// <summary>
        ///  source : https://leetcode.com/problems/keyboard-row/discuss/97871/Java-1-Line-Solution-via-Regex-and-Stream
        /// </summary>
        public string[] RegexSolution(string[] words)
        {
            return words.Where(u => Regex.IsMatch(u.ToLower(), "^[zxcvbnm]*|[asdfghjkl]*|[qwertyuiop]*$")).ToArray();
        }

    }
}
