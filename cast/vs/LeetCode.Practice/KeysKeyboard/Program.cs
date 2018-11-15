using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Cons.Arithmetic.Tools;
using KeysKeyboard.Solution;
using Newtonsoft.Json;

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

            new Thread(() =>
            {
                Console.WriteLine(JsonConvert.SerializeObject(Thread.CurrentThread));

//                while (true)
//                {
//                    Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId);
//                    Thread.Sleep(1000);
//                    Thread.CurrentThread.IsBackground = true;
//                    Thread.CurrentThread.IsBackground = true;
//                }

//                Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId);
//                Thread.Sleep(1000);
//                Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId + ", over~");
            }).Start();

            Console.WriteLine(JsonConvert.SerializeObject(Thread.CurrentThread));
            Console.ReadKey(true);
//
//            new Thread(() =>
//            {
//                Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId);
//                Thread.Sleep(1000);
//                Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId + ", over~");
//            }).Start();
//            new Thread(() =>
//            {
//                Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId);
//                Thread.Sleep(1000);
//                Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId + ", over~");
//            }).Start();
//            new Thread(() =>
//            {
//                Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId);
//                Thread.Sleep(1000);
//                Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId + ", over~");
//            }).Start();
//            new Thread(() =>
//            {
//                Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId);
//                Thread.Sleep(1000);
//                Console.WriteLine("i'm thread :" + Thread.CurrentThread.ManagedThreadId + ", over~");
//            }).Start();
//
//            Console.WriteLine("---");
////            ThreadPool.QueueUserWorkItem((state =>
////            {
////                for (int i = 0; i < 50; i++)
////                {
////                    Console.WriteLine(i);
////                }
////            }));
//
////            Thread.Sleep(500);
//            Console.WriteLine("sleep finish " + Thread.CurrentThread.ManagedThreadId);
//
//            Console.ReadKey();

//            Simple simple = new Simple();
//
//            for (int i = 100; i < 10000; i++)
//            {
//                var minSteps = simple.MinSteps(i);
//
//                StopWatchTools.ShowCountTime((() => simple.MinSteps(i)));
//                StopWatchTools.ShowCountTime((() => simple.OtherSolution(i)));
//                Console.WriteLine("----------------------");
//            }
//
//
//            Console.ReadKey(true);
        }
    }
}