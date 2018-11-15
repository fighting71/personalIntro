using System;
using System.Collections.Generic;
using System.Text;

namespace PartitionToKEqualSumSubsets.OOSolution
{
    public class Explain
    {

        public bool Solution(int[] nums, int k)
        {

            //1.计算出nums/k (t) 即每个子集需要达到的总和

            //2.遍历nums 将元素以 值->出现次数 存入Dictionary

            //3.去除Dictionary 中 key == T 的元素 并k-出现次数

            //4.遍历Dictionary 进行子集组合 令总和为T 每组合成功一次 k--  若剩余元素 < k * 2 则返回false

            //5.重复步骤4 直到 Dictionary所有元素值为0 且 k为0 即组合成功

            return false;
        }



    }
}