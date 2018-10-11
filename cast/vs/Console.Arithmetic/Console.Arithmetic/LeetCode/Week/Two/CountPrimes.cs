using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    /// <summary>
    /// source:https://leetcode.com/problems/count-primes/description/
    /// </summary>
    public class CountPrimes
    {
        //Description:

        //Count the number of prime numbers less than a non-negative number, n.

        public int Simple(int n)
        {
            int count = 0;

            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) count++;
            }

            return count;
        }

        /// <summary>
        /// 参考 other
        /// 理解 理解埃拉托斯特尼筛法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Solution(int n)
        {
            bool[] notPrime = new bool[n];

            int count = 0;

            HashSet<int> set = new HashSet<int>();

            for (int i = 2; i < n; i++)
            {
                if (notPrime[i] == false)
                {
//                    Console.WriteLine("each:"+i);
                    count++;
                    if (i * i < n)
                    {
                        for (int j = 2; i * j < n; j++)
                        {
                            notPrime[i * j] = true; //
                            if (!set.Add(i * j))
                            {
                                Console.WriteLine("存在一个重复数：" + (i * j));//存在。。。
                            }

                            ;
                        }
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// https://leetcode.com/problems/count-primes/discuss/57588/My-simple-Java-solution
        /// don't understand
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int OtherSolution(int n)
        {
            bool[] notPrime = new bool[n];
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                if (notPrime[i] == false)
                {
                    count++;
                    if (i * i < n)
                    {
                        for (int j = 2; i * j < n; j++)
                        {
                            notPrime[i * j] = true;
                        }
                    }
                }
            }

            return count;
        }
    }
}