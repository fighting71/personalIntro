using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.Sort.Note.Stabilization
{
    /// <summary>
    /// 归并排序
    ///
    /// 归并操作（merge），也叫归并算法，指的是将两个已经排序的序列合并成一个序列的操作。归并排序算法依赖归并操作。
    /// 
    /// 递归法（Top-down）
    ///     申请空间，使其大小为两个已经排序序列之和，该空间用来存放合并后的序列
    ///     设定两个指针，最初位置分别为两个已经排序序列的起始位置
    ///     比较两个指针所指向的元素，选择相对小的元素放入到合并空间，并移动指针到下一位置
    ///     重复步骤3直到某一指针到达序列尾
    ///     将另一序列剩下的所有元素直接复制到合并序列尾
    /// 
    /// 迭代法（Bottom-up）
    ///     原理如下（假设序列共有 {  n}
    /// n个元素）：
    /// 
    /// 将序列每相邻两个数字进行归并操作，形成 {  ceil(n/2)} {  ceil(n/2)}个序列，排序后每个序列包含两/一个元素
    /// 若此时序列数不是1个则将上述序列再次归并，形成 {  ceil(n/4)} {  ceil(n/4)}个序列，每个序列包含四/三个元素
    /// 重复步骤2，直到所有元素排序完毕，即序列数为1
    ///
    /// .,难度稍高  先跳过
    /// 
    /// </summary>
    public class MergeSort
    {

        #region 递归法

        static void merge_sort_recursive(int[] arr, int[] result, int start, int end)
        {
            if (start >= end)
                return;
            int len = end - start, mid = (len >> 1) + start;
            int start1 = start, end1 = mid;
            int start2 = mid + 1, end2 = end;
            merge_sort_recursive(arr, result, start1, end1);
            merge_sort_recursive(arr, result, start2, end2);
            int k = start;
            while (start1 <= end1 && start2 <= end2)
                result[k++] = arr[start1] < arr[start2] ? arr[start1++] : arr[start2++];
            while (start1 <= end1)
                result[k++] = arr[start1++];
            while (start2 <= end2)
                result[k++] = arr[start2++];
            for (k = start; k <= end; k++)
                arr[k] = result[k];
        }

        public static void merge_sort(int[] arr)
        {
            int len = arr.Length;
            int[] result = new int[len];
            merge_sort_recursive(arr, result, 0, len - 1);
        }

        #endregion

        #region 迭代法

        public static void new_merge_sort(int[] arr)
        {
            //申请空间
            int[] orderedArr = new int[arr.Length];
            for (int i = 2; i < arr.Length * 2; i *= 2)
            {
                for (int j = 0; j < (arr.Length + i - 1) / i; j++)
                {
                    int left = i * j;
                    int mid = left + i / 2 >= arr.Length ? (arr.Length - 1) : (left + i / 2);
                    int right = i * (j + 1) - 1 >= arr.Length ? (arr.Length - 1) : (i * (j + 1) - 1);
                    int start = left, l = left, m = mid;
                    while (l < mid && m <= right)
                    {
                        if (arr[l] < arr[m])
                        {
                            orderedArr[start++] = arr[l++];
                        }
                        else
                        {
                            orderedArr[start++] = arr[m++];
                        }
                    }
                    while (l < mid)
                        orderedArr[start++] = arr[l++];
                    while (m <= right)
                        orderedArr[start++] = arr[m++];
                    Array.Copy(orderedArr, left, arr, left, right - left + 1);
                }
            }
        }

        #endregion

    }
}