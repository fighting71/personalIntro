using System;
using System.Collections.Generic;
using System.Text;
using KeysKeyboard.Thinker;

namespace KeysKeyboard.CusInherit
{
    public class SimpleSolution : BaseSolution
    {
        public override void Paste()
        {
            Str = Str + MemoryStr;
        }

        public override void Copy()
        {
            MemoryStr = Str;//仅允许全复制
        }

        public override bool CopyValid(int needLen)
        {
            if (string.IsNullOrEmpty(MemoryStr))
            {
                return true;
            }

            if (MemoryStr.Equals(Str))
            {
                return false;
            }

            if (needLen > Str.Length && needLen % Str.Length == 0)
            {
                return true;
            }

            return false;
        }
    }
}