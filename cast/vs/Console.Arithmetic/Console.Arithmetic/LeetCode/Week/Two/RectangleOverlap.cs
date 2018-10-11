using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Week.Two
{
    /// <summary>
    /// source:https://leetcode.com/problems/rectangle-overlap/description/
    /// </summary>
    public class RectangleOverlap
    {
        //Description:

        //A rectangle is represented as a list [x1, y1, x2, y2], where (x1, y1) are the coordinates of its bottom-left corner, and (x2, y2) are the coordinates of its top-right corner.

        //Two rectangles overlap if the area of their intersection is positive.To be clear, two rectangles that only touch at the corner or edges do not overlap.

        //Given two (axis-aligned) rectangles, return whether they overlap.

        //Notes:

        //Both rectangles rec1 and rec2 are lists of 4 integers.
        //All coordinates in rectangles will be between -10^9 and 10^9.

        /// <summary>
        /// 暴力破解=-= accepted~
        ///
        /// error=-=
        /// 
        /// </summary>
        /// <param name="rec1"></param>
        /// <param name="rec2"></param>
        /// <returns></returns>
        public bool Simple(int[] rec1, int[] rec2) //error 矩形 not 正方形
        {
            //包含顶点
            for (var i = 0; i < rec1.Length; i += 2)
                if (rec1[i] > rec2[0] && rec1[i] < rec2[2]
                                      && rec1[1] > rec2[1] && rec1[1] < rec2[3] //01
                    || rec1[i] > rec2[0] && rec1[i] < rec2[2]
                                         && rec1[3] > rec2[1] && rec1[3] < rec2[3]) //03
                    return true;

            for (var i = 0; i < rec1.Length; i += 2)
                if (rec2[i] > rec1[0] && rec2[i] < rec1[2]
                                      && rec2[1] > rec1[1] && rec2[1] < rec1[3] //01 21
                    || rec2[i] > rec1[0] && rec2[i] < rec1[2]
                                         && rec2[3] > rec1[1] && rec2[3] < rec1[3]) //03  23
                    return true;

            //完全重合

            bool hasOverride = true;

            for (int i = 0; i < rec1.Length; i++)
            {
                if (rec1[i] != rec2[i])
                {
                    hasOverride = false;
                    break;
                }
            }

            if (hasOverride)
            {
                return true;
            }

            //不包含顶点 但中间重叠

            return (rec1[3] >= rec2[3] && rec1[1] <= rec2[1]
                                      && rec1[0] >= rec2[0] && rec1[2] <= rec2[2])
                   || (rec2[3] >= rec1[3] && rec2[1] <= rec1[1]
                                         && rec2[0] >= rec1[0] && rec2[2] <= rec1[2]);

            //一边重叠 另一边包含

            //error
            //            int len1 = rec1[3] - rec1[0];
            //            int len2 = rec2[3] - rec2[0];
            //
            //            int[] largeRec = len1 > len2 ? rec1 : rec2;
            //            int[] smallRec = len1 > len2 ? rec2 : rec1;
            //
            //            //4个顶点是否在范围内
            //
            //            //范围  1 - 3  2 - 4 
            //
            //            return (smallRec[0] == largeRec[0] && smallRec[1] == largeRec[1] && len1 == len2) //完全重叠
            //                   || (smallRec[0] > largeRec[0] && smallRec[0] < largeRec[2]
            //                                                 && smallRec[1] > largeRec[1] && smallRec[1] < largeRec[3]) //01
            //                   || (smallRec[0] > largeRec[0] && smallRec[0] < largeRec[2]
            //                                                 && smallRec[3] > largeRec[1] && smallRec[3] < largeRec[3]) //03
            //                   || (smallRec[2] > largeRec[0] && smallRec[2] < largeRec[2]
            //                                                 && smallRec[1] > largeRec[1] && smallRec[1] < largeRec[3]) //21
            //                   || (smallRec[2] > largeRec[0] && smallRec[2] < largeRec[2]
            //                                                 && smallRec[3] > largeRec[1] && smallRec[3] < largeRec[3]) //23
            //                ;

            return false;
        }

        /// <summary>
        /// source:https://leetcode.com/problems/rectangle-overlap/discuss/132340/C++JavaPython-1-line-Solution-1D-to-2D
        ///
        /// 单面 1D
        /// 
        /// error...
        /// 
        /// </summary>
        /// <param name="rec1"></param>
        /// <param name="rec2"></param>
        /// <returns></returns>
//        public bool OtherSolution(int[] rec1, int[] rec2)
//        {
//            return rec1[0] < rec2[2]
//                   && rec2[0] < rec1[2] 
//                   && rec1[1] < rec2[3] 
//                   && rec2[1] < rec1[3];
//        }

        /// <summary>
        /// https://leetcode.com/problems/rectangle-overlap/discuss/161497/Java-One-Line-with-explanation
        /// </summary>
        /// <param name="rec1"></param>
        /// <param name="rec2"></param>
        /// <returns></returns>
        public bool OtherSolution2(int[] rec1, int[] rec2)
        {
            return (!(rec1[2] <= rec2[0] || rec1[3] <= rec2[1] || rec2[2] <= rec1[0] || rec2[3] <= rec1[1]));
        }

    }
}