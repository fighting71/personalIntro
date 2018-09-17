using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{
    /// <summary>
    /// source:https://leetcode.com/problems/toeplitz-matrix/description/
    /// </summary>
    public class ToeplitzMatrix
    {
        //Description

//        A matrix is Toeplitz if every diagonal from top-left to bottom-right has the same element.
//
//            Now given an M x N matrix, return True if and only if the matrix is Toeplitz.


        //1234
        //1234
        //1234
        //30 / 20 31 / 10 21 32/11 22 33 /12 24 / 13


        public bool Simple(int[][] martix)
        {
            int width = martix[0].Length;
            int heigth = martix.Length;

            int x = 0, y = 0, num = 0;

            for (int i = 0; i < heigth; i++) //from top to bottom
            {
                x = 0;
                y = i;
                num = martix[y][x];
                for (y++, x++; y < heigth && x < width; y++, x++)
                {
                    if (martix[y][x] != num)
                    {
                        return false;
                    }
                }
            }

            for (int i = 1; i < width; i++) //from left to right
            {
                x = i;
                y = 0;
                num = martix[y][x];
                for (y++, x++; x < width && y < heigth; y++, x++)
                {
                    if (martix[y][x] != num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Solution(int[][] matrix)
        {
            int x, y, num, width = matrix[0].Length, heigth = matrix.Length;

            for (int i = 0; i < heigth - 1; i++) //from top to bottom
            {
                x = 0;
                y = i;
                num = matrix[y][x];
                for (y++, x++; y < heigth && x < width; y++, x++)
                    if (matrix[y][x] != num)
                        return false;
            }

            for (int i = 1; i < width - 1; i++) //from left to right
            {
                x = i;
                y = 0;
                num = matrix[y][x];
                for (y++, x++; x < width && y < heigth; y++, x++)
                    if (matrix[y][x] != num)
                        return false;
            }

            return true;
        }

        public bool OtherSolution(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    if (matrix[i][j] != matrix[i + 1][j + 1]) return false;
                }
            }

            return true;
        }
    }
}