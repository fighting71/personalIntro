using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.Sort.Note
{
    /// <summary>
    /// title:鸡尾酒排序
    ///
    /// description:鸡尾酒排序，也就是定向冒泡排序，
    /// 鸡尾酒搅拌排序，搅拌排序（也可以视作选择排序的一种变形）
    /// ，涟漪排序，来回排序或快乐小时排序，是冒泡排序的一种变形。
    /// 此算法与冒泡排序的不同处在于排序时是以双向在序列中进行排序。
    ///
    /// </summary>
    public class CocktailSort<T> : ISort<T>
    {
        public static void OfficeSort(int[] arr)
        {
            int i, left = 0, right = arr.Length - 1;
            int temp;
            while (left < right)
            {
                for (i = left; i < right; i++)
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }

                right--;
                for (i = right; i > left; i--)
                    if (arr[i - 1] > arr[i])
                    {
                        temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                    }

                left++;
            }
        }

        public IEnumerable<T> Sort(IEnumerable<T> source, Func<T, T, bool> compareFunc)
        {
            var arr = source.ToArray();

            //记录初始下标
            int left = 0, right = arr.Length - 1;
            //交换中间对象
            T temp;

            while (left < right)
            {

                //在无序区  从左至右  扫描
                for (int i = left; i < right; i++)
                {
                    if (compareFunc.Invoke(arr[i], arr[i + 1]))
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }

                right--;

                for (int i = right; i > left; i--)
                {
                    if (compareFunc.Invoke(arr[i - 1], arr[i]))
                    {
                        temp = arr[i - 1];
                        arr[i - 1] = arr[i];
                        arr[i] = temp;
                    }
                }

                left++;
            }

            return arr;
        }
    }
}