using System;
using System.Collections.Generic;
using System.Text;

namespace MyCalendarIi.Solution
{
    /// <summary>
    ///
    /// difficulty: I don't understand what is 'triple booking'
    ///
    /// and I explain:添加一个区间 若此区间存在与已添加的区间 重叠则不可添加 --> error
    ///
    /// final:=-= 看不懂description
    /// 
    /// </summary>
    class SimpleSolution
    {
        /**
         * Your MyCalendarTwo object will be instantiated and called as such:
         * MyCalendarTwo obj = new MyCalendarTwo();
         * bool param_1 = obj.Book(start,end);
         */

        protected IList<int[]> list;

        public SimpleSolution()
        {
            list = new List<int[]>();
        }

        public bool Book(int start, int end)
        {
            var count = 0;
            foreach (var arr in list)
            {
                if (!(start >= arr[1] || end <= arr[0]))
                {
                    if (count++ > 0)
                        return false;
                }
            }

            list.Add(new[] {start, end});

            return true;
        }
    }
}