using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.Sort.Note
{
    /// <summary>
    ///
    /// title:插入排序
    /// 
    /// 从第一个元素开始，该元素可以认为已经被排序
    /// 取出下一个元素，在已经排序的元素序列中从后向前扫描
    /// 如果该元素（已排序）大于新元素，将该元素移到下一位置
    /// 重复步骤3，直到找到已排序的元素小于或者等于新元素的位置
    /// 将新元素插入到该位置后
    /// 重复步骤2 ~5
    ///
    /// join:二分查找法
    /// 
    /// </summary>
    public class InsertionSort<T> : ISort<T>
    {
        public static void InsertSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (array[j] > temp)
                    {
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                    else
                        break;
                }
            }
        }

        public IEnumerable<T> Sort(IEnumerable<T> source, Func<T, T, bool> compareFunc)
        {
            var arr = source.ToArray();

            for (int i = 1; i < arr.Length; i++)
            {
                var item = arr[i]; //取出一个元素

                for (int j = i - 1; j >= 0; j--) //遍历有序区域
                {
                    if (compareFunc.Invoke(item, arr[j]))
                    {
                        arr[j + 1] = arr[j];
                        arr[j] = item;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return arr;
        }
    }
}