using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Middle
{
    /// <summary>
    /// source:https://leetcode.com/problems/hand-of-straights/
    ///
    /// description:
    ///     Alice has a hand of cards, given as an array of integers.
    ///     Now she wants to rearrange the cards into groups so that each group is size W, and consists of W consecutive cards.
    /// 
    ///     Return true if and only if she can.
    ///
    /// Note:
    ///     1 $lt;= hand.length $lt;= 10000
    ///     0 $lt;= hand[i] $lt;= 10^9
    ///     1 $lt;= W $lt;= hand.length
    /// 
    /// </summary>
    public class HandOfStraights
    {

        public bool Simple(int[] hand, int W)
        {
            if (hand.Length % W != 0)
                return false;

            //step1:创建辅助数组
            int max = hand[0], min = hand[0];

            foreach (var item in hand)
            {
                if (max < item)
                    max = item;
                if (min > item)
                    min = item;
            }

            var arr = new int[max - min + 1]; //当差值较大时 不适应 容易内存溢出

            //step2:将hand中的值放在辅助数组中
            foreach (var item in hand) arr[item - min]++;

            //step3:遍历辅助数组,验证是否满足条件
            var count = 0;

            for (var i = 0; i < arr.Length; i++)
                if (count == 0)
                {
                    if (arr[i] != 0)
                    {
                        count = W - 1; //重置需要连续的个数
                        arr[i]--;
                    }
                }
                else if (arr[i] == 0)
                {
                    return false;
                }
                else
                {
                    arr[i]--;
                    if (--count == 0)
                        i -= W;
                }

            return count == 0;
        }

        public class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x - y;
            }
        }

        /// <summary>
        /// Runtime: 252 ms, faster than 62.96% of C# online submissions for Hand of Straights.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="W"></param>
        /// <returns></returns>
        public bool Solution(int[] hand, int W)
        {
            if (hand.Length % W != 0)
                return false;

            //            var dictionary = new Dictionary<int, int>();
            var dictionary = new SortedDictionary<int, int>(new IntComparer()); //使用map而非int数组 减少了空间占比  

            foreach (var item in hand)
                if (dictionary.ContainsKey(item))
                    dictionary[item]++;
                else
                    dictionary.Add(item, 1);

            //此处使用排序简化了
            var arr = dictionary.Keys.ToArray();

            //            Array.Sort(arr);

            var startNum = -1;
            int count = 0, temp;

//            foreach (var key in arr)
//            {
//                if (arr[key] > 0)
//                {
//                    for (int i = W - 1; i >= 0; i--)
//                    {
//                        dictionary.TryGetValue(key + i, out temp);
//
//                        if (temp < dictionary[key]) return false;
//                        //                        c.Add(key + i, c[key + i] - c[key]);//遍历c的时候不能修改c
//                        dictionary[key + i] = dictionary[key + i] - dictionary[key];
//                    }
//                }
//            }

            for (var i = 0; i < arr.Length; i++)
            {
                var key = arr[i];

                if (count == 0)
                {
                    if (dictionary[key] > 0)
                    {
                        dictionary[key]--;
                        startNum = key;
                        count = W - 1;
                    }
                }
                else
                {
                    if (key != startNum + (W - count))
                    {
                        return false;
                    }
                    else
                    {
                        dictionary[key]--;

                        if (--count == 0) i -= W;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// source:https://leetcode.com/problems/hand-of-straights/discuss/135598/C%2B%2BJavaPython-O(MlogM)-Complexity
        ///
        /// 打脸的环节 ^V^
        ///
        /// 实践了一下 还是差不多...
        ///
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="W"></param>
        /// <returns></returns>
        public bool OtherSolution(int[] hand, int W)
        {
//            Map<Integer, Integer> c = new TreeMap<>();
//            for (int i : hand) c.put(i, c.getOrDefault(i, 0) + 1);
//            for (int it : c.keySet())
//            if (c.get(it) > 0)
//                for (int i = W - 1; i >= 0; --i)
//                {
//                    if (c.getOrDefault(it + i, 0) < c.get(it)) return false;
//                    c.put(it + i, c.get(it + i) - c.get(it));
//                }

            Dictionary<int, int> c = new Dictionary<int, int>();

            var temp = 0;

            foreach (var i in hand)
            {
                //                c.Add(i, c.GetValueOrDefault(i, 0));//重复添加key
                if (c.ContainsKey(i))
                    c[i]++;
                else
                    c.Add(i, 1);
            }

            foreach (var key in c.Keys.ToArray())
            {
                if (c[key] > 0)
                    for (int i = W - 1; i >= 0; i--)
                    {
                        c.TryGetValue(key + i, out temp);

                        if (temp < c[key]) return false;
//                        c.Add(key + i, c[key + i] - c[key]);//遍历c的时候不能修改c
                        c[key + i] = c[key + i] - c[key];
                    }
            }

            return true;
        }

    }
}