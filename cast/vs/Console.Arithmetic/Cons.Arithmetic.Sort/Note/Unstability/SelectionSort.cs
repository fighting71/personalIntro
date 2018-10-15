using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.Sort.Note.Unstability
{
    /// <summary>
    ///
    /// 选择排序
    ///
    /// 工作原理如下。
    /// 首先在未排序序列中找到最小（大）元素，存放到排序序列的起始位置，
    /// 然后，再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。
    /// 以此类推，直到所有元素均排序完毕。
    /// 
    /// 选择排序的主要优点与数据移动有关。
    /// 如果某个元素位于正确的最终位置上，则它不会被移动。
    /// 选择排序每次交换一对元素，它们当中至少有一个将被移到其最终位置上，因此对 {  n}
    /// n个元素的表进行排序总共进行至多 {  n-1} {  n-1}次交换。
    /// 在所有的完全依靠交换去移动元素的排序方法中，选择排序属于非常好的一种
    ///
    /// 交换次数比冒泡排序较少，由于交换所需CPU时间比比较所需的CPU时间多，
    /// { n} n值较小时，选择排序比冒泡排序快。
    /// 
    /// </summary>
    public class SelectionSort
    {

        static void selection_sort<T>(T[] arr) where T : System.IComparable<T>
        {//整數或浮點數皆可使用
            int i, j, min, len = arr.Length;
            T temp;
            for (i = 0; i < len - 1; i++)
            {
                min = i;
                for (j = i + 1; j < len; j++)
                    if (arr[min].CompareTo(arr[j]) > 0)
                        min = j;
                temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
        }

    }
}