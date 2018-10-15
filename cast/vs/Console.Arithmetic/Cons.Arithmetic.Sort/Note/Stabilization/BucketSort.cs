using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.Sort.Note.Stabilization
{
    /// <summary>
    ///
    /// 桶排序/箱排序
    /// 
    /// 设置一个定量的数组当作空桶子。
    /// 寻访序列，并且把项目一个一个放到对应的桶子去。
    /// 对每个不是空的桶子进行排序。
    /// 从不是空的桶子里把项目再放回原来的序列中。
    ///
    /// 优势：利于分段处理
    /// 劣势：当需要分配桶较多时不适应使用
    ///
    /// join:桶排序是鸽巢排序的一种归纳结果
    /// 
    /// </summary>
    public class BucketSort
    {
        #region from office

        private static int IndexFor(int a, int min, int step)
        {
            return (a - min) / step;
        }

        public void Override(int[] arr)
        {
            //step 1: 找出最大值与最小值
            int max = arr[0], min = arr[0];

            foreach (var item in arr)
            {
                if (item > max)
                    max = item;

                if (item < min)
                    min = item;
            }

            //step 2: 确定桶个数
            var step = 10;
            int bucketCount = max / step - min / step + 1;

            List<List<int>> bucket = new List<List<int>>();

            for (int i = 0; i < bucketCount; i++)
            {
                bucket.Add(new List<int>());
            }

            //step 3:给桶分配元素
            foreach (var item in arr)
            {
                bucket[IndexFor(item, min, step)].Add(item);
            }

            //step 4:遍历所有桶，进行排序
            var index = 0;
            foreach (var item in bucket)
            {
                InsertSort(item);

                foreach (var i in item)
                {
                    arr[index++] = i;
                }
            }
        }

        public static void Sort(int[] arr)
        {
            //step 1: 找出最大值与最小值
            int max = arr[0], min = arr[0];
            foreach (int a in arr)
            {
                if (max < a)
                    max = a;
                if (min > a)
                    min = a;
            }

            //step 2: 确定桶个数
            // 該值也可根據實際情況選擇
            int bucketNum = max / 10 - min / 10 + 1;
            List<List<int>> buckList = new List<List<int>>();
            // create bucket
            for (int i = 1; i <= bucketNum; i++)
            {
                buckList.Add(new List<int>());
            }

            //step 3:给桶分配元素
            int index = 0;
            // push into the bucket
            for (int i = 0; i < arr.Length; i++)
            {
                index = IndexFor(arr[i], min, 10); //分段放入桶中
                buckList[index].Add(arr[i]);
            }

            //step 4:遍历所有桶，进行排序
            List<int> bucket = null;
            index = 0;
            for (int i = 0; i < bucketNum; i++)
            {
                bucket = buckList[i];
                InsertSort(bucket); //在桶中进行排序  【可使用其他排序算法】
                foreach (int k in bucket)
                {
                    arr[index++] = k;
                }
            }
        }

        // 把桶內元素插入排序
        private static void InsertSort(List<int> bucket)
        {
            for (int i = 1; i < bucket.Count; i++)
            {
                int temp = bucket[i];
                int j = i - 1;
                for (; j >= 0 && bucket[j] > temp; j--)
                {
                    bucket[j + 1] = bucket[j];
                }

                bucket[j + 1] = temp;
            }
        }

        #endregion
    }
}