using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.Sort.Note.Stabilization
{
    /// <summary>
    /// 计数排序
    ///
    /// 找出待排序的数组中最大和最小的元素
    ///
    /// 统计数组中每个值为 i i的元素出现的次数，存入数组 C  C 的第 i i项
    /// 对所有的计数累加（从 C
    /// C 中的第一个元素开始，每一项和前一项相加）
    /// 反向填充目标数组：将每个元素 i i放在新数组的第 C[i] C[i]项，每放一个元素就将 C[i] C[i]减去1
    ///
    /// 非比较排序 效率优于比较排序
    /// 不适应于元素极差较大的数组
    /// 
    /// </summary>
    public class CountingSort
    {
        #region

        public static int[] countingSort(int[] A)
        {
            int[] B = new int[A.Length];
            // 假设A中的数据a'有，0<=a' && a' < k并且k=100
            int k = 100;
            countingSort(A, B, k);
            return B;
        }

        private static void countingSort(int[] A, int[] B, int k)
        {
            int[] C = new int[k];
            // 计数
            for (int j = 0; j < A.Length; j++)
            {
                int a = A[j];
                C[a] += 1;
            }

            // 求计数和
            for (int i = 1; i < k; i++)
            {
                C[i] = C[i] + C[i - 1];
            }

            // 整理
            for (int j = A.Length - 1; j >= 0; j--)
            {
                int a = A[j];
                B[C[a] - 1] = a;
                C[a] -= 1;
            }
        }

        #endregion

        #region optmize

        public static int[] Sort(int[] a)
        {
            int[] b = new int[a.Length];
            int max = a[0], min = a[0];
            foreach (int i in a)
            {
                if (i > max)
                {
                    max = i;
                }

                if (i < min)
                {
                    min = i;
                }
            }

            //这里k的大小是要排序的数组中，元素大小的极值差+1
            int k = max - min + 1;
            int[] c = new int[k];
            for (int i = 0; i < a.Length; ++i)
            {
                c[a[i] - min] += 1; //优化过的地方，减小了数组c的大小
            }

            for (int i = 1; i < c.Length; ++i)
            {
                c[i] = c[i] + c[i - 1];
            }

            for (int i = a.Length - 1; i >= 0; --i)
            {
                b[--c[a[i] - min]] = a[i]; //按存取的方式取出c的元素
            }

            return b;
        }

        #endregion

        public static int[] Learning(int[] arr)
        {
            //step1:创建计数数组
            int max = arr[0], min = arr[0];

            foreach (var item in arr)
            {
                if (max < item)
                    max = item;
                if (min > item)
                    min = item;
            }

            int[] countArr = new int[max - min + 1];

            //step2:对每个元素进行计数
            foreach (var item in arr)
            {
                countArr[item - min] += 1;
            }

            for (int i = 1; i < countArr.Length; i++)
            {
                countArr[i] = countArr[i] + countArr[i - 1]; //确定位置  例如3计数前有20个数  则 3计数 = 原来的计数 + 20
            }

            //step3:根据元素取出位置进行排序
            int[] sortArr = new int[arr.Length];

            foreach (var item in arr)
            {
                sortArr[--countArr[item - min]] = item;
            }

            return sortArr;
        }
    }
}