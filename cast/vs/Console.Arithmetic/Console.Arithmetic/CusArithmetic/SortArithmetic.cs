using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.CusArithmetic
{

    /// <summary>
    /// 排序算法
    /// source:https://zh.wikipedia.org/wiki/%E6%8E%92%E5%BA%8F%E7%AE%97%E6%B3%95
    /// </summary>
    public class SortArithmetic
    {

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        public void BubbleSort(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

        }

    }
}
