using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/pascals-triangle/description/
    ///
    /// description:Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
    /// 
    /// </summary>
    public class PascalsTriangle
    {
        /// <summary>
        /// 返回一个类似于杨辉三角的图形
        ///
        /// easy .,
        /// 
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Simple(int numRows)
        {
            IList<IList<int>> list = new List<IList<int>>();

            IList<int> itemList;

            for (int i = 1; i <= numRows; i++)
            {
                itemList = new List<int>();

                for (int j = 0; j < i; j++)
                {
                    if (j == 0 || j == i - 1)
                        itemList.Add(1);
                    else
                        itemList.Add(list[i - 2][j - 1] + list[i - 2][j]); //数组0 即 1 故此次要  -2  
                }

                list.Add(itemList);
            }

            return list;
        }
    }
}