using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Cons.Arithmetic.Sort.Note.Unstability
{
    /// <summary>
    /// 希尔排序/递减增量排序算法
    ///
    /// 希尔排序是基于插入排序的以下两点性质而提出改进方法的：
    ///    插入排序在对几乎已经排好序的数据操作时，效率高，即可以达到线性排序的效率
    ///    但插入排序一般来说是低效的，因为插入排序每次只能将数据移动一位
    /// 
    /// join:是插入排序的一种更高效的改进版本。
    /// 
    /// </summary>
    public class ShellSort
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(int[] array)
        {
            int step = array.Length / 2, temp, j;

            while (step >= 1)
            {
                for (int i = step; i < array.Length; i += step)
                {
                    temp = array[i];
                    j = i - step;

                    while (j >= 0 && array[j] > temp)
                    {
                        array[j + step] = array[j];
                        j -= step;
                    }

                    array[j + step] = temp;
                }

                step /= 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        public static void shellSort(int[] array)
        {
            //step1:确定步长
            int number = array.Length / 2;
            int i;
            int j;
            int temp;
            while (number >= 1)
            {
                for (i = number; i < array.Length; i++)
                {
                    temp = array[i];
                    j = i - number;
                    //mmp 一开始感觉不对劲 原来是反序了.
                    while (j >= 0 && array[j] > temp) // > ==> 正序排序   < ==> 反序排序 
                    {
                        array[j + number] = array[j];
                        j = j - number;
                        Console.WriteLine(JsonConvert.SerializeObject(array));
                    }

                    array[j + number] = temp;
                }

                number = number >> 1; //步长调整 << 1
            }
        }
    }
}