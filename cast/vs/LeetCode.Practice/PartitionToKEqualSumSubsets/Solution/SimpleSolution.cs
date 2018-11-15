using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartitionToKEqualSumSubsets.Solution
{
    /// <summary>
    /// understand the question meaning is not easy =.
    /// </summary>
    public class SimpleSolution
    {
        public bool Explain(int[] nums, int k)
        {
            //1.计算出nums/k (t) 即每个子集需要达到的总和

            //2.遍历nums 将元素以 值->出现次数 存入Dictionary

            int sum = 0;

            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            List<int> list = new List<int>();

            foreach (var num in nums)
            {
                sum += num;
                if (dictionary.ContainsKey(num))
                    dictionary[num]++;
                else
                {
                    dictionary.Add(num, 1);
                    list.Add(num);
                }
            }

            if (sum % k != 0) return false; //不存在平均值

            int t = sum / k;

            //3.去除Dictionary 中 key == T 的元素 并k-出现次数
            var itemCount = nums.Length;

            if (dictionary.ContainsKey(t))
            {
                k -= dictionary[t];
                itemCount -= dictionary[t];
                dictionary.Remove(t);
            }

            //4.遍历Dictionary 进行子集组合 令总和为T 每组合成功一次 k--  若剩余元素 < k * 2 则返回false

            //5.重复步骤4 直到 Dictionary所有元素值为0 且 k为0 即组合成功

//            List<int> removeList = new List<int>();

            var ints = nums.ToList();

            ints.Sort();

            for (int i = 0; i < ints.Count; i++)
            {
                k--;
                var needNum = t - ints[i];
                for (int j = ints.Count - 1; j > i; j--)
                {
                    if (ints[j] > needNum) continue;

                    needNum = needNum - ints[j];
                    ints.RemoveAt(j);

                    if (needNum == 0)
                    {
                        break;
                    }
                }

                if (needNum > 0) return false;

                if (ints.Count < k * 2) return false;

                if (k < 0) return false;
            }

            //只考虑子集有两个元素
//            foreach (var item in dictionary)
//            {
//                if (removeList.Contains(item.Key))
//                    continue;
//
//                var needKey = t - item.Key;
//
//                if (dictionary.ContainsKey(needKey))
//                {
//                    if (dictionary[needKey] == item.Value)
//                    {
//                        removeList.Add(needKey);
//                        k -= item.Value;
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                }
//                else
//                {
//                    return false;
//                }
//            }
//
//            //考虑多个元素...
//
//            while (k > 0)
//            {
//                if (itemCount < k * 2) return false;
//
//                for (int i = 0; i < list.Count; i++)
//                {
//                    var item = list[i];
//                    var needNum = t - item;
//
//                    for (int j = 0; j < dictionary[item]; j++)
//                    {
//                        for (int l = list.Count - 1; l >= 0; l--)
//                        {
//                            var count = dictionary[list[l]];
//
//                            // too complex ....
//
//                        }
//                    }
//                }
//            }

            //拿取最小的一个

            //needNum 

            return ints.Count == 0 && k == 0;
        }

        public bool ClearUp(int[] nums, int k)
        {
            int sum = 0;

            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                sum += num;
                if (dictionary.ContainsKey(num))
                    dictionary[num]++;
                else
                    dictionary.Add(num, 1);
            }

            if (sum % k != 0) return false; //不存在平均值

            int t = sum / k;

            if (dictionary.ContainsKey(t))
            {
                k -= dictionary[t];
                dictionary.Remove(t);
            }

            var ints = nums.Where(u => u != t).ToList();

            ints.Sort();

            for (int i = 0; i < ints.Count; i++)
            {
                k--;
                var needNum = t - ints[i];
                for (int j = ints.Count - 1; j > i; j--)
                {
                    if (needNum == 0)
                        break;

                    if (ints[j] > needNum) continue;

                    needNum = needNum - ints[j];
                    ints.RemoveAt(j);
                }

                if (needNum > 0) return false;

                if (ints.Count < k * 2) return false;

                if (k < 0) return false;

            }

            return k == 0;
        }


        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            var sum = 0;

            foreach (var num in nums)
            {
                sum += num;
                if (dictionary.ContainsKey(num))
                    dictionary[num]++;
                else
                    dictionary.Add(num, 1);
            }

            if (sum % k != 0) return false;

            var countSum = sum / k;

            if (dictionary.ContainsKey(countSum))
            {
                k -= dictionary[countSum];
                dictionary.Remove(countSum);
            }

            foreach (var item in dictionary)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    var needNum = countSum - item.Key;

                    if (dictionary.ContainsKey(needNum))
                        dictionary[needNum]--;
                    else
                        return false;

                    dictionary[item.Key]--;
                }
            }

            return true;
        }
    }
}