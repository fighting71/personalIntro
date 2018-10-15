using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.LeetCode
{

    /// <summary>
    /// source:https://leetcode.com/problems/nim-game/description/
    /// </summary>
    public class NimGame
    {

        //Description:

        //You are playing the following Nim Game with your friend: There is a heap of stones on the table, each time one of you take turns to remove 1 to 3 stones. The one who removes the last stone will be the winner. You will take the first turn to remove the stones.

        //Both of you are very clever and have optimal strategies for the game.Write a function to determine whether you can win the game given the number of stones in the heap.

        public bool Simple(int count)
        {

            //当剩下4个石头时 ==> failure

            //同理 需要剩下4个石头给对方  或者只有4个石头以下的数量时会 ==> success 
            
            //1 - 3  5-7 9-11  ... i give up

            return true;

        }

        /// <summary>
        /// source https://leetcode.com/problems/nim-game/discuss/73749/Theorem:-all-4s-shall-be-false
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool OtherSolution(int count)
        {
            return count % 4 != 0;//$#@$#@%#@%#@*$&*#@&$*.... why so simple  推演证明求证=-=
        }
    }
}
