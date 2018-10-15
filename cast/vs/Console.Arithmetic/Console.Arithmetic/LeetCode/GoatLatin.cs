using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    public class GoatLatin
    {

        //Description:

        //A sentence S is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.

        //We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)

        //The rules of Goat Latin are as follows:

        //If a word begins with a vowel(a, e, i, o, or u), append "ma" to the end of the word.
        //For example, the word 'apple' becomes 'applema'.


        //If a word begins with a consonant (i.e.not a vowel), remove the first letter and append it to the end, then add "ma".
        //For example, the word "goat" becomes "oatgma".

        //Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
        //For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
        //Return the final sentence representing the conversion from S to Goat Latin.

        public string Simple(string str)
        {

            var arr = str.Split(' ');

            var sm = "ma";

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                sm += "a";

                if (arr[i][0] == 'a' || arr[i][0] == 'e' || arr[i][0] == 'i' || arr[i][0] == 'o' || arr[i][0] == 'u')
                {
                    builder.Append(arr[i]);
                }
                else
                {
                    builder.Append(arr[i].Substring(1));
                    builder.Append(arr[i][0]);
                }

                builder.Append(sm);
                builder.Append(" ");

            }

            return builder.ToString();

        }

        /// <summary>
        /// 跟其他人解决方案差不多=- 是问题太简单的问题吗。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Solution(string str)
        {

            var arr = str.Split(' ');

            var sm = "maa";

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < arr.Length; i++,sm+="a")
            {

                if (arr[i][0] == 'a' || arr[i][0] == 'e' || arr[i][0] == 'i' || arr[i][0] == 'o' || arr[i][0] == 'u'||
                    arr[i][0] == 'A' || arr[i][0] == 'E' || arr[i][0] == 'I' || arr[i][0] == 'O' || arr[i][0] == 'U')
                {
                    builder.Append(arr[i]);
                }
                else
                {
                    builder.Append(arr[i].Substring(1));
                    builder.Append(arr[i][0]);
                }

                builder.Append(sm);

                if (i != arr.Length - 1)
                {
                    builder.Append(" ");
                }

            }

            return builder.ToString();

        }

    }
}
