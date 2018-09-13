using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/lemonade-change/description/
    /// </summary>
    public class LemonadeChange
    {
        //Description:

        //        At a lemonade stand, each lemonade costs $5. 
        //
        //        Customers are standing in a queue to buy from you, and order one at a time(in the order specified by bills).
        //
        //        Each customer will only buy one lemonade and pay with either a $5, $10, or $20 bill.You must provide the correct change to each customer, so that the net transaction is that the customer pays $5.
        //
        //        Note that you don't have any change in hand at first.
        //
        //            Return true if and only if you can provide every customer with correct change.

        public bool Simple(int[] bills)
        {
            int[] prices = new[] {5, 10, 20};

            int[] wallet = new[] {0, 0, 0};

            for (int i = 0; i < bills.Length; i++)
            {
                var bill = bills[i];

                if (bill == prices[0])
                {
                    wallet[0]++;
                }
                else if (bill == prices[1])
                {
                    if (wallet[0] > 0)
                    {
                        wallet[0]--;
                        wallet[1]++;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (bill == prices[2])
                {
                    if (wallet[0] > 0 && wallet[1] > 0)
                    {
                        wallet[0]--;
                        wallet[1]--;
                        wallet[2]++;
                    }
                    else if (wallet[0] > 2)
                    {
                        wallet[0] -= 3;
                        wallet[2]++;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Solution(int[] bills)
        {
            int[] wallet = new[] {0, 0, 0};

            foreach (var bill in bills)
            {
                var result = (bill / 10); //0 1 2

                if (result > 0)
                {
                    int needNum = 1;
                    for (int j = (result) - 1; j >= 0; j--)
                        if (wallet[j] >= needNum)
                        {
                            wallet[j] -= needNum;
                            needNum = 1;
                        }
                        else if (j > 0)
                            needNum += 2;
                        else
                            return false;

                    wallet[result]++;
                }
                else
                {
                    wallet[result]++;
                }
            }

            return true;
        }

        /// <summary>
        /// source:https://leetcode.com/problems/lemonade-change/discuss/143719/C++JavaPython-Straight-Forward
        ///
        /// diff:类似于暴力破解
        ///
        /// 算法，只是为了结果而生？
        /// 
        /// </summary>
        /// <param name="bills"></param>
        /// <returns></returns>
        public bool OtherSolution(int[] bills)
        {
            int five = 0, ten = 0;
            foreach (var bill in bills)
            {
                if (bill == 5) five++;
                else if (bill == 10) { five--; ten++; }
                else if (ten > 0) { ten--; five--; }
                else five -= 3;
                if (five < 0) return false;
            }
            return true;
        }

    }
}