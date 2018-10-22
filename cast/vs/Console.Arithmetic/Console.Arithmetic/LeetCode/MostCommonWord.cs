using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/most-common-word/description/
    ///
    /// description:
    ///     Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words.
    ///     It is guaranteed there is at least one word that isn't banned, and that the answer is unique.
    ///     Words in the list of banned words are given in lowercase, and free of punctuation.
    ///     Words in the paragraph are not case sensitive.The answer is in lowercase.
    ///
    /// Note:
    ///     1 &lt; = paragraph.length &lt;= 1000.
    ///     1 &lt;= banned.length &lt;= 100.
    ///     1 &lt;= banned[i].length &lt;= 10.
    ///     The answer is unique, and written in lowercase(even if its occurrences in paragraph may have uppercase symbols, and even if it is a proper noun.)
    ///     paragraph only consists of letters, spaces, or the punctuation symbols !?',;.
    ///     There are no hyphens or hyphenated words.
    ///     Words only consist of letters, never apostrophes or other punctuation symbols.
    /// 
    /// </summary>
    public class MostCommonWord
    {
        #region 理解题义error 

        //        public string Simple(string paragraph, string[] banned)
        //        {
        //            Dictionary<string, int> dictionary = new Dictionary<string, int>();
        //
        //            string lowerParagraph = paragraph.ToLower(), key;
        //
        //            foreach (var item in banned)
        //            {
        //                key = item.ToLower();
        //                key = key.Replace(",", "").Replace(".", "");
        //                if (key.ToLower() != lowerParagraph)
        //                {
        //                    if (dictionary.ContainsKey(key))
        //                    {
        //                        dictionary[key]++;
        //                    }
        //                    else
        //                    {
        //                        dictionary.Add(key, 1);
        //                    }
        //                }
        //            }
        //
        //            int max = 0;
        //
        //            string mostCommonWord = string.Empty;
        //
        //            foreach (var item in dictionary)
        //            {
        //                if (item.Value > max)
        //                {
        //                    mostCommonWord = item.Key;
        //                    max = item.Value;
        //                }
        //            }
        //
        //            return mostCommonWord;
        //        }

        #endregion

        public string Simple(string paragraph, string[] banned)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            var words = paragraph.ToLower().Replace(",", " ").Replace(".", " ").Replace(".", " ").Replace("!", " ")
                .Replace("?", " ").Replace(";", " ").Replace("'", " ").Split(' ');

            string key;

            foreach (var item in words)
            {
                key = item.Trim();

                if (key.Length > 0 && !banned.Contains(key))
                {
                    if (dictionary.ContainsKey(key))
                    {
                        dictionary[key]++;
                    }
                    else
                    {
                        dictionary.Add(item, 1);
                    }
                }
            }

            int max = 0;

            string mostCommonWord = string.Empty;

            foreach (var item in dictionary)
            {
                if (item.Value > max)
                {
                    mostCommonWord = item.Key;
                    max = item.Value;
                }
            }

            return mostCommonWord;
        }


        public string Solution(string paragraph, string[] banned)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            var words = paragraph
                //以小写为准
                .ToLower()
                //可考虑正则替换.
//                .Replace("\\W"," ")
                //去除标点符号
                .Replace(",", " ")
                .Replace(".", " ")
                .Replace(".", " ")
                .Replace("!", " ")
                .Replace("?", " ")
                .Replace(";", " ")
                .Replace("'", " ")
                //作为数组处理
                .Split(' ');

            string key;

            int num;
            
            foreach (var item in words)
            {
                key = item.Trim(); //去除多余空格

                if (key.Length > 0 && !banned.Contains(key)) //元素非空格且不在禁用词中
                {
                    dictionary.TryGetValue(key, out num);
                    dictionary.Add(key, num + 1);
                }
            }

            int max = 0;

            //ef 处理
            //            string mostCommonWord = dictionary.FirstOrDefault(u => u.Value == dictionary.Max(u => u.Value)).Key;
            string mostCommonWord = string.Empty;//答案唯一

            foreach (var item in dictionary)
            {
                if (item.Value > max)//获取出现次数最大的word
                {
                    mostCommonWord = item.Key;
                    max = item.Value;
                }
            }

            return mostCommonWord;
        }
    }
}