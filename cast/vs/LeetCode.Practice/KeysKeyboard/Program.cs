using System;
using System.Collections.Generic;
using System.Diagnostics;
using Cons.Arithmetic.Tools;
using KeysKeyboard.Solution;

namespace KeysKeyboard
{
    /// <summary>
    /// source : https://leetcode.com/problems/2-keys-keyboard/
    ///
    /// description:
    ///     Initially on a notepad only one character 'A' is present. You can perform two operations on this notepad for each step:
    ///     Copy All: You can copy all the characters present on the notepad(partial copy is not allowed).
    ///     Paste: You can paste the characters which are copied last time.
    ///     Given a number n.You have to get exactly n 'A' on the notepad by performing the minimum number of steps permitted.Output the minimum number of steps to get n 'A'.
    ///
    /// Note:
    ///     The n will be in the range[1, 1000].
    /// 
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            Simple simple = new Simple();

            for (int i = 100; i < 10000; i++)
            {
                var minSteps = simple.MinSteps(i);

                StopWatchTools.ShowCountTime((() => simple.MinSteps(i)));
                StopWatchTools.ShowCountTime((() => simple.OtherSolution(i)));
                Console.WriteLine("----------------------");
            }


            Console.ReadKey(true);
        }
    }
}