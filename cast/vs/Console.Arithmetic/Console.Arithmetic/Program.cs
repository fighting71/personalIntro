using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using Cons.Arithmetic.LeetCode;
using Cons.Arithmetic.LeetCode.Design;
using Cons.Arithmetic.LeetCode.Design.Inherit;
using Cons.Arithmetic.Tools;
using Newtonsoft.Json;

namespace Cons.Arithmetic
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILinkedList<string> list = new SimpleLinkedList<string>();

            list.AddAtHead("head");
            list.AddAtTail("tail");
            list.AddAtIndex(1, "index");

            list.DeleteAtIndex(1);

            Console.WriteLine(list);

            Console.WriteLine((int) '0');

            Console.WriteLine("Success!");

            Console.ReadKey();
        }

        private static void TestRotateArray()
        {
            RotateArray demo = new RotateArray();

            int[] arr = new[] {1, 2, 3, 4, 5, 6, 7, 8};

            demo.Solution(arr, 3);
            demo.OtherSolution(arr, 3);
            Console.WriteLine(demo);
        }

        private static void TestBuddyStrings()
        {
            HashSet<int> set = new HashSet<int>();

            var methodInfo = set.GetType().GetMethod("AddIfNotPresent", BindingFlags.Instance | BindingFlags.NonPublic);
            var result = methodInfo.Invoke(set, new Object[] {3});
            var info = methodInfo.Invoke(set, new Object[] {3});

            Console.WriteLine(methodInfo);

            BuddyStrings demo = new BuddyStrings();

            Console.WriteLine(demo.Simple("ab", "ba"));
            Console.WriteLine(demo.Solution("ab", "ab"));
            Console.WriteLine(demo.Simple("aa", "aa"));
            Console.WriteLine(demo.Simple("aaaaaaabc", "aaaaaaacb"));
            Console.WriteLine(demo.Simple("", "aa"));
        }

        private static void TestValidPhoneNumbers()
        {
            ValidPhoneNumbers demo = new ValidPhoneNumbers();

            string path =
                "F:\\work_data\\git\\personalIntro\\cast\\vs\\Console.Arithmetic\\Console.Arithmetic\\Txt\\phone.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                var phone = string.Empty;

                //                while (!string.IsNullOrEmpty(phone = sr.ReadLine()))
                //                {
                ////                    StopWatchTools.ShowCountTime((() =>
                ////                    {
                ////                        var mobile = demo.Simple(phone);
                ////                        Console.WriteLine(mobile);
                ////                        return "Simple";
                ////                    }));
                //
                //                    StopWatchTools.ShowCountTime((() =>
                //                    {
                //                        var mobile = demo.Solution(phone);
                //                        if (!string.IsNullOrEmpty(mobile))
                //                        {
                //                            Console.WriteLine(mobile);
                //                        }
                //                        return "Solution";
                //                    }));
                //
                //                }

                List<string> list = new List<string>();

                while (!string.IsNullOrEmpty(phone = sr.ReadLine()))
                {
                    list.Add(phone);
                }

                StopWatchTools.ShowCountTime(() =>
                {
                    foreach (var item in list.ToArray())
                    {
                        var solution = demo.Simple(item);
                    }

                    return "Simple";
                });

                StopWatchTools.ShowCountTime(() =>
                {
                    foreach (var item in list.ToArray())
                    {
                        var solution = demo.Solution(item);
                    }

                    return "Solution";
                });
            }
        }

        private static void TestNonDecreasingArray()
        {
            NonDecreasingArray demo = new NonDecreasingArray();

//            var checkPossibility = demo.CheckPossibility(new[] { 663, 635, 513, 108, 926, 738, 418, 402 });
//
//            Console.ReadKey();

            Random rand = new Random();

            StringBuilder builder = new StringBuilder();

            int arrLength = 1000;

            bool first = false, second = false, third = false;

//            for (int i = 0; i < 1000; i++)
//            {
//                int[] arr = new int[arrLength];
//
//                for (int j = 0; j < arrLength; j++)
//                {
//                    arr[j] = rand.Next(1000);
//                }
//
//                builder.AppendLine(StopWatchTools.CountTime((() =>
//                {
//                    int[] clone = (int[]) arr.Clone();
//                    var result = demo.CheckPossibility(clone);
//                    first = result;
//                    return $@"CheckPossibility
//result:{result}
//arr:{JsonConvert.SerializeObject(arr)}
//";
//                })));
//
//                builder.AppendLine(StopWatchTools.CountTime((() =>
//                {
//                    int[] clone = (int[]) arr.Clone();
//                    var result = demo.OtherSolution(clone);
//                    second = result;
//                    return $@"OtherSolution
//result:{result}
//arr:{JsonConvert.SerializeObject(arr)}
//";
//                })));
//
//                builder.AppendLine(StopWatchTools.CountTime((() =>
//                {
//                    int[] clone = (int[]) arr.Clone();
//                    var result = demo.OtherSolution2(clone);
//                    third = result;
//                    return $@"OtherSolution2
//result:{result}
//arr:{JsonConvert.SerializeObject(arr)}
//";
//                })));
//
//                if (first != second)
//                {
//                    builder.AppendLine("error");
//                }
//
//                builder.AppendLine("----------------------------------------------------------");
//            }

            builder.AppendLine(StopWatchTools.CountTime((() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    int[] arr = new int[arrLength];

                    for (int j = 0; j < arrLength; j++)
                    {
                        arr[j] = rand.Next(1000);
                    }

                    demo.CheckPossibility(arr);
                }

                return "CheckPossibility";
            })));

            builder.AppendLine("----------------------------------------------------------");

            builder.AppendLine(StopWatchTools.CountTime((() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    int[] arr = new int[arrLength];

                    for (int j = 0; j < arrLength; j++)
                    {
                        arr[j] = rand.Next(1000);
                    }

                    demo.OtherSolution(arr);
                }

                return "OtherSolution";
            })));

            builder.AppendLine("----------------------------------------------------------");

            builder.AppendLine(StopWatchTools.CountTime((() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    int[] arr = new int[arrLength];

                    for (int j = 0; j < arrLength; j++)
                    {
                        arr[j] = rand.Next(1000);
                    }

                    demo.OtherSolution2(arr);
                }

                return "OtherSolution2";
            })));

            builder.AppendLine("----------------------------------------------------------");

            string path =
                "F:\\work_data\\git\\personalIntro\\cast\\vs\\Console.Arithmetic\\Console.Arithmetic\\Logs\\" +
                Guid.NewGuid().ToString() + ".log";

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(builder.ToString().Replace("\n", "\r\n"));
            }
        }
    }
}