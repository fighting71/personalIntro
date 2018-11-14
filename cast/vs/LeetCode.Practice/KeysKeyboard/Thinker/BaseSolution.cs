using System;
using System.Collections.Generic;
using System.Text;
using KeysKeyboard.CusInterface;

namespace KeysKeyboard.Thinker
{
    
    /// <summary>
    /// 抽象化问题
    /// </summary>
    public abstract class BaseSolution : IPaste, ICopy
    {
        /// <summary>
        /// 文本内容
        /// </summary>
        public string Str { get; set; } = "A";

        /// <summary>
        /// 剪切板
        /// </summary>
        public string MemoryStr { get; set; }

        /// <summary>
        /// 由实现类处理
        /// </summary>
        public abstract void Paste();

        /// <summary>
        /// 由实现类处理
        /// </summary>
        public abstract void Copy();

        /// <summary>
        /// 复制验证
        /// </summary>
        /// <param name="needLen"></param>
        /// <returns></returns>
        public abstract bool CopyValid(int needLen);

        /// <summary>
        /// 计算最小计步
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinSteps(int n)
        {
            int step = 0;

            while (n > Str.Length)
            {
                if (CopyValid(n - Str.Length))
                    Copy();
                else
                    Paste();

                step++;
            }

            return step;
        }
    }
}