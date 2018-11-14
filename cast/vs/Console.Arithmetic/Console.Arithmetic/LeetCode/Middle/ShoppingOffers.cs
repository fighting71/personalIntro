using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Middle
{
    /// <summary>
    /// source:https://leetcode.com/problems/shopping-offers/
    ///
    ///Note:
    ///     There are at most 6 kinds of items, 100 special offers.
    ///     For each item, you need to buy at most 6 of them.
    ///     You are not allowed to buy more items than you want, even if that would lower the overall price.
    ///
    ///     ...不能多买
    /// 
    /// </summary>
    public class ShoppingOffers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="price">每件商品的价格</param>
        /// <param name="special">优惠套餐 ： {对应每件商品的数量,套餐价格}</param>
        /// <param name="needs">对应每件商品的数量(实际所需数量)</param>
        /// <returns></returns>
        public int Simple(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            //note1 need foreach all special  <--> 需要知道所有的优惠组合 
            // optimize : (所需和优惠套餐)完全重合时 直接跳过后续

            // 比对needs
            // type:不足needs
            // type2:完全重合 [完美方案]
            // type3:比needs更多

            //暴力破解 》 计算所有优惠方案对应的价格 取最小值

            int minSpend = 0; //最少花费

            //初始为最高花费
            for (int i = 0; i < needs.Count; i++)
            {
                minSpend += needs[i] * price[i];
            }

            for (int i = 0; i < special.Count; i++)
            {
                bool hasDiff = false;
                bool change = true;
                int specialSpend = special[i][special[i].Count - 1]; //套餐价格
                for (int j = 0; j < special[i].Count - 1; j++)
                {
                    if (special[i][j] > needs[j])
                    {
                        change = false;
                        break; //不能多买...
                        if (!hasDiff)
                            hasDiff = true;//正常人都不会在意多买吧. 还能转手 赚一笔.,
                    }
                    else if ((special[i][j] < needs[j]))
                    {
                        if (!hasDiff)
                            hasDiff = true;

                        specialSpend += (needs[j] - special[i][j]) * price[j]; //不足 补金额

                        if (specialSpend > minSpend)
                        {
                            change = false;
                            break;
                        }
                    }
                }

                if (!hasDiff) //完全吻合
                    return specialSpend;

                if (change)
                    minSpend = specialSpend;
            }

            return minSpend;
        }


        public int Simple(int[] price, int[][] special, int[] needs)
        {
            //note1 need foreach all special  <--> 需要知道所有的优惠组合 
            // optimize : (所需和优惠套餐)完全重合时 直接跳过后续

            // 比对needs
            // type:不足needs
            // type2:完全重合 [完美方案]
            // type3:比needs更多

            //暴力破解 》 计算所有优惠方案对应的价格 取最小值

            int minSpend = 0; //最少花费

            //初始为最高花费
            for (int i = 0; i < needs.Length; i++)
            {
                minSpend += needs[i] * price[i];
            }

            for (int i = 0; i < special.Length; i++)
            {
                bool hasDiff = false;
                int specialSpend = special[i][special[i].Length - 1]; //套餐价格
                for (int j = 0; j < special[i].Length - 1; j++)
                {
                    if (special[i][j] > needs[j])
                    {
                        if (!hasDiff)
                            hasDiff = true;
                    }
                    else if ((special[i][j] < needs[j]))
                    {
                        if (!hasDiff)
                            hasDiff = true;

                        specialSpend += (needs[j] - special[i][j]) * price[j]; //不足 补金额

                        if (specialSpend > minSpend)
                            break;
                    }
                }

                if (!hasDiff) //完全吻合
                    return specialSpend;

                minSpend = specialSpend > minSpend ? minSpend : specialSpend;
//                Console.WriteLine("已替换最优套餐为:" + i);
            }

            return minSpend;
        }
    }
}