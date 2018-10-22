using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.LeetCode.Middle
{
    /// <summary>
    /// source:https://leetcode.com/problems/game-of-life/
    ///
    /// prev:
    ///     According to the Wikipedia's article:
    ///     "The Game of Life, also known simply as Life,
    ///     is a cellular automaton devised by the British mathematician John Horton Conway in 1970."
    ///
    /// note:
    ///     Given a board with m by n cells, each cell has an initial state live (1) or dead (0). Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article):
    ///     Any live cell with fewer than two live neighbors dies, as if caused by under-population.
    ///     Any live cell with two or three live neighbors lives on to the next generation.
    ///     Any live cell with more than three live neighbors dies, as if by over-population..
    ///     Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
    ///     Write a function to compute the next state (after one update) of the board given its current state.
    ///     The next state is created by applying the above rules simultaneously to every cell in the current state, where births and deaths occur simultaneously.
    ///
    /// Follow up:
    ///     Could you solve it in-place? Remember that the board needs to be updated at the same time: You cannot update some cells first and then use their updated values to update other cells.
    ///     In this question, we represent the board using a 2D array.In principle, the board is infinite, which would cause problems when the active area encroaches the border of the array.How would you address these problems?
    /// 
    /// </summary>
    public class GameOfLife
    {
        #region my simple solution

        /// <summary>
        /// 活细胞
        /// </summary>
        private const int ALIVE_CELL = 1;

        /// <summary>
        /// 死细胞
        /// </summary>
        private const int DIES_CELL = 0;

        /// <summary>
        /// 检测 此细胞是否需要发生改变
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="rowIndex"></param>
        /// <param name="lineIndex"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool GetAroundAliveCount(int cell, int rowIndex, int lineIndex, int[][] board)
        {
            var count = 0;

            for (int i = Math.Max(rowIndex - 1, 0); i < Math.Min(rowIndex + 2, board.Length); i++)
            {
//                if (i < 0 || i > board.Length - 1)
//                {
//                    continue;
//                }

                for (int j = Math.Max(lineIndex - 1, 0); j < Math.Min(lineIndex + 2, board[0].Length); j++)
                {
                    //                    if (j < 0 || j > board[0].Length - 1 || (i == rowIndex && j == lineIndex))
                    //                    {
                    //                        continue;
                    //                    }
                    if ((i == rowIndex && j == lineIndex))
                    {
                        continue;
                    }

                    count += (board[i][j] & 1);
//                    if (board[i][j] == ALIVE_CELL)
//                    {
//                        count++;
//                    }

                    if (cell == ALIVE_CELL && count == 4)
                    {
                        return true;
                    }
                }
            }

            if (cell == ALIVE_CELL && count < 2) //邻居不足2 --> 死亡
            {
                return true;
            }

            if (cell == DIES_CELL && count == 3) //邻居刚好为3 --> 死细胞成为或活细胞
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// success ... 较为简单的解决方案.
        /// </summary>
        /// <param name="board"></param>
        public void Simple(int[][] board)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (GetAroundAliveCount(board[i][j], i, j, board))
                    {
                        map.Add(i * board[0].Length + j, j);
                    }
                }
            }

            foreach (var item in map)
            {
                board[(item.Key - item.Value) / board[0].Length][item.Value] =
                    board[(item.Key - item.Value) / board[0].Length][item.Value] == ALIVE_CELL ? DIES_CELL : ALIVE_CELL;
            }
        }

        #endregion

        #region other solution
        
        /// <summary>
        /// source:https://leetcode.com/problems/game-of-life/discuss/73223/Easiest-JAVA-solution-with-explanation
        ///
        /// 采用二进制进行修改 , good
        /// I'm little bird ~
        /// 
        /// </summary>
        /// <param name="board"></param>
        public void gameOfLife(int[][] board)
        {
            if (board == null || board.Length == 0) return;
            int m = board.Length, n = board[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int lives = liveNeighbors(board, m, n, i, j);

                    // In the beginning, every 2nd bit is 0;
                    // So we only need to care about when will the 2nd bit become 1.
                    if (board[i][j] == 1 && lives >= 2 && lives <= 3)
                    {
                        board[i][j] = 3; // Make the 2nd bit 1: 01 ---> 11
                    }

                    if (board[i][j] == 0 && lives == 3)
                    {
                        board[i][j] = 2; // Make the 2nd bit 1: 00 ---> 10
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i][j] >>= 1; // Get the 2nd state.
                }
            }
        }

        public int liveNeighbors(int[][] board, int m, int n, int i, int j)
        {
            int lives = 0;
            for (int x = Math.Max(i - 1, 0); x <= Math.Min(i + 1, m - 1); x++)
            {
                for (int y = Math.Max(j - 1, 0); y <= Math.Min(j + 1, n - 1); y++)
                {
                    lives += board[x][y] & 1;
                }
            }

            lives -= board[i][j] & 1;
            return lives;
        }

        #endregion
    }
}