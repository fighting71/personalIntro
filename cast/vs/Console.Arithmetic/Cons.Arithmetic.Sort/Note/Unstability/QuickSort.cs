using System;
using System.Collections.Generic;
using System.Text;
using Cons.Arithmetic.Sort.Tools;
using Newtonsoft.Json;

namespace Cons.Arithmetic.Sort.Note.Unstability
{
    /// <summary>
    /// 快速排序/划分交换排序
    ///
    /// about:
    ///     快速排序使用分治法（Divide and conquer）策略来把一个序列（list）分为两个子序列（sub-lists）。
    ///
    /// step:
    ///     从数列中挑出一个元素，称为“基准”（pivot），
    ///     重新排序数列，所有比基准值小的元素摆放在基准前面，所有比基准值大的元素摆在基准后面（相同的数可以到任何一边）。在这个分割结束之后，该基准就处于数列的中间位置。这个称为分割（partition）操作。
    ///     递归地（recursively）把小于基准值元素的子数列和大于基准值元素的子数列排序。
    /// 
    /// </summary>
    public class QuickSort
    {
        public static void qSort(int[] arr, int head, int tail)
        {
            if (head >= tail || arr == null || arr.Length <= 1)
            {
                return;
            }

            //确定边界 基准
            int i = head, j = tail, pivot = arr[(head + tail) / 2];
            Console.WriteLine($@"{nameof(head)}:{head} , {nameof(tail)}:{tail} , {nameof(pivot)}:{pivot} ");
            while (i <= j)
            {
                while (arr[i] < pivot)
                {
                    ++i;
                }

                while (arr[j] > pivot)
                {
                    --j;
                }

                if (i < j)
                {
                    int t = arr[i];
                    arr[i] = arr[j];
                    arr[j] = t;
                    ++i;
                    --j;
                    ShowTools.ShowArr(arr);
                    ShowTools.ShowLine();
                }
                else if (i == j)
                {
                    ++i;
                }
            }

            qSort(arr, head, j);
            qSort(arr, i, tail);
        }
    }
}