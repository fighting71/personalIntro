using System;
using System.Collections.Generic;
using System.Text;

namespace KeysKeyboard.Solution
{
    public class Simple
    {
        protected string memoryChar = string.Empty;

        protected string str = "A";

        /// <summary>
        /// result:Runtime: 56 ms, faster than 70.00% of C# online submissions for 2 Keys Keyboard.
        ///
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinSteps(int n)
        {
            //A  --> n*A

            //option:copy/paste

            var strLen = 1; //字符长度
            var memoryLen = 0; //剪切板字符长度
            var step = 0; //步骤


            while (strLen < n)
            {
                if (memoryLen == 0) //初始只能进行进行复制
                {
                    memoryLen = strLen;
                }
                else if (memoryLen == strLen)
                {
                    strLen += memoryLen; //字符长度==复制字符长度  只有进行粘贴的必要
                }
                else if (n - strLen > strLen && (n - strLen) % strLen == 0
                ) //可以进行复制条件  需要的字符 > 当前字符的长度  && 需要的字符 % 当前字符的长度 == 0
                {
                    memoryLen = strLen;
                }
                else
                {
                    strLen += memoryLen;
                }

                step++;
            }

            return step;
        }

        /// <summary>
        /// don't understand.,
        /// 存在两个循环 .,
        /// extension emm...留着以后有空再看
        /// source:https://leetcode.com/problems/2-keys-keyboard/discuss/105899/Java-DP-Solution
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int OtherSolution(int n)
        {
            int[] dp = new int[n + 1];

            for (int i = 2; i <= n; i++)
            {
                dp[i] = i;
                for (int j = i - 1; j > 1; j--)
                {
                    if (i % j == 0)
                    {
                        dp[i] = dp[j] + (i / j);
                        break;
                    }
                }
            }

            return dp[n];
        }

        /// <summary>
        /// 复制
        /// </summary>
        public void Copy()
        {
            memoryChar = str;
        }

        /// <summary>
        /// 粘贴
        /// </summary>
        public void Paste()
        {
            str = str + memoryChar;
        }
    }
}