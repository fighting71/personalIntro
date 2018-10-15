using System;
using System.Collections.Generic;
using System.Linq;

namespace Cons.Arithmetic.Sort.inherit
{
    /// <summary>
    ///
    /// title:冒泡排序
    /// 
    /// 比较相邻的元素。如果第一个比第二个大，就交换他们两个。
    /// 对每一对相邻元素作同样的工作，从开始第一对到结尾的最后一对。这步做完后，最后的元素会是最大的数。
    /// 针对所有的元素重复以上的步骤，除了最后一个。
    /// 持续每次对越来越少的元素重复上面的步骤，直到没有任何一对数字需要比较。
    ///
    /// join：鸡尾酒排序
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NormalBubbleSort<T> : ISort<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="compareFunc"></param>
        /// <returns></returns>
        public IEnumerable<T> Sort(IEnumerable<T> source, Func<T, T, bool> compareFunc)
        {

            T temp;

            //swap
            // n. 交换；交换之物
            // vt.与...交换；以...作交换
            // vi.交换；交易
            bool swapped;

            var arr = source.ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                swapped = false;
                for (int j = 0; j < arr.Length - i - 1; j++) //遍历无序区段
                {
                    if (compareFunc.Invoke(arr[j], arr[j + 1])) //查看是否需要置换
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        if (!swapped)
                            swapped = true;
                    }
                }

                if (!swapped) //若无序区段不存在则直接结束
                    break;
            }

            return arr;
        }

        /// <summary>
        /// source:https://zh.wikipedia.org/wiki/%E5%86%92%E6%B3%A1%E6%8E%92%E5%BA%8F
        /// </summary>
        /// <param name="intArray"></param>
        static void BubbleSort(int[] intArray)
        {
            int temp = 0; //交换载体
            bool swapped; //循环优化
            for (int i = 0; i < intArray.Length; i++)
            {
                swapped = false;
                for (int j = 0; j < intArray.Length - 1 - i; j++)
                    if (intArray[j] > intArray[j + 1]) //前者》后者
                    {
                        temp = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = temp; //交换位置
                        if (!swapped)
                            swapped = true; //表示任需继续优化
                    }

                if (!swapped) //循环优化
                    return;
            }
        }
    }
}