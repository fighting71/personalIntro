using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.Sort.Note.Unstability
{

    /// <summary>
    /// 梳排序
    ///
    /// 要旨:
    ///     消除乌龟，亦即在数组尾部的小数值，这些数值是造成泡沫排序缓慢的主因。
    /// 
    /// join:
    ///     改良自泡沫排序和快速排序
    /// 
    /// </summary>
    public class CombSort
    {

        public static void sort<T>(T[] input)where T:IComparable
        {

            #region 伪代码

//            梳排序程序（以array作輸入）
//            gap = array的長度 //設定開始時的間距
//
//
//
//            當gap > 1或swaps = 1時執行迴圈 //代表未完成排序
//                gap = 取「gap除以遞減率」的整數值 //更新間距
//
//
//                swaps = 0 //用以檢查陣列是否已在遞增形式，只限gap=1時有效
//
//
//            //把輸入陣列「梳」一次
//            i = 0 到(array的長度 - 1 - gap)來執行迴圈 //從首到尾掃描一次；因為陣列元素的編號從0開始，所以最後一個元素編號為長度-1
//            如果array[i] > array[i + gap]
//            把array[i]和array[i + gap]的數值交換
//                swaps = 1 //曾作交換，故此陣列未必排序好
//            如果結束
//                迴圈結束
//            迴圈結束
//                程序結束

            #endregion

            int gap = input.Length;
            bool swapped = true;
            while (gap > 1 || swapped)
            {
                if (gap > 1)
                {
                    gap = (int)(gap * 0.8);
                }
                int i = 0;
                swapped = false;
                while (i + gap < input.Length)
                {
                    if (input[i].CompareTo(input[i + gap]) > 0)
                    {
                        T t = input[i];
                        input[i] = input[i + gap];
                        input[i + gap] = t;
                        swapped = true;
                    }
                    i++;
                }
            }
        }

    }
}
