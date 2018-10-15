using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.Sort.Note.Stabilization
{
    /// <summary>
    /// 基数排序
    ///
    /// 实现：将所有待比较数值（正整数）统一为同样的数字长度，数字较短的数前面补零。
    /// 然后，从最低位开始，依次进行一次排序。
    /// 这样从最低位排序一直到最高位排序完成以后，数列就变成一个有序序列。
    ///
    /// 基数排序的方式可以采用LSD（Least significant digital）或MSD（Most significant digital），
    /// LSD的排序方式由键值的最右边开始，
    /// 而MSD则相反，由键值的最左边开始。
    ///
    /// about:参考桶排序。
    /// 
    /// </summary>
    public class RadixSort
    {
        /// <summary>
        /// 辅助函数-求数据的最大位数
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Maxbit(int[] arr, int n)
        {
            var max = arr[0];

            for (int i = 0; i < n; i++)
            {
                if (max < arr[i])
                    max = arr[i];
            }

            var len = 1;

            while (max >= 10)
            {
                len++;
                max = max / 10;
            }

            return len;
        }

        public void Sort(int[] arr, int n)
        {
            var maxbit = Maxbit(arr, n);

            var tempArr = new int[n];

            var countArr = new int[10];//计数器

            int i, j, k,radix = 1;

            for (i = 1; i <= maxbit; i++) //进行d次排序
            {
                for (j = 0; j < 10; j++)
                    countArr[j] = 0; //每次分配前清空计数器
                for (j = 0; j < n; j++)
                {
                    k = (arr[j] / radix) % 10; //统计每个桶中的记录数
                    countArr[k]++;
                }
                for (j = 1; j < 10; j++)
                    countArr[j] = countArr[j - 1] + countArr[j]; //将tmp中的位置依次分配给每个桶
                for (j = n - 1; j >= 0; j--) //将所有桶中记录依次收集到tmp中
                {
                    k = (arr[j] / radix) % 10;
                    tempArr[countArr[k] - 1] = arr[j];
                    countArr[k]--;
                }
                for (j = 0; j < n; j++) //将临时数组的内容复制到data中
                    arr[j] = tempArr[j];
                radix = radix * 10;
            }

        }
        
    }
}