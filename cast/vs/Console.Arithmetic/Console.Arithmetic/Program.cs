using System;
using System.IO;
using System.Text;
using Cons.Arithmetic.LeetCode;
using Cons.Arithmetic.Tools;
using Newtonsoft.Json;

namespace Cons.Arithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            NonDecreasingArray demo = new NonDecreasingArray();

            var checkPossibility = demo.CheckPossibility(new[] { 663, 635, 513, 108, 926, 738, 418, 402 });

            Console.ReadKey();

            Random rand = new Random();

            StringBuilder builder = new StringBuilder();

            int arrLength = 8;

            bool first = false, second = false, third = false;

            for (int i = 0; i < 1000; i++)
            {
                int[] arr = new int[arrLength];

                for (int j = 0; j < arrLength; j++)
                {
                    arr[j] = rand.Next(1000);
                }

                builder.AppendLine(StopWatchTools.CountTime((() =>
                {
                    int[] clone = (int[]) arr.Clone();
                    var result = demo.CheckPossibility(clone);
                    first = result;
                    return $@"CheckPossibility
result:{result}
arr:{JsonConvert.SerializeObject(arr)}
";
                })));

                builder.AppendLine(StopWatchTools.CountTime((() =>
                {
                    int[] clone = (int[]) arr.Clone();
                    var result = demo.OtherSolution(clone);
                    second = result;
                    return $@"OtherSolution
result:{result}
arr:{JsonConvert.SerializeObject(arr)}
";
                })));

                builder.AppendLine(StopWatchTools.CountTime((() =>
                {
                    int[] clone = (int[]) arr.Clone();
                    var result = demo.OtherSolution2(clone);
                    third = result;
                    return $@"OtherSolution2
result:{result}
arr:{JsonConvert.SerializeObject(arr)}
";
                })));

                if (first != second)
                {
                    builder.AppendLine("error");
                }

                builder.AppendLine("----------------------------------------------------------");
            }

//            builder.AppendLine(StopWatchTools.CountTime((() =>
//            {
//                for (int i = 0; i < 1000; i++)
//                {
//                    int[] arr = new int[arrLength];
//
//                    for (int j = 0; j < arrLength; j++)
//                    {
//                        arr[j] = rand.Next(1000);
//                    }
//
//                    demo.CheckPossibility(arr);
//                }
//
//                return "CheckPossibility";
//            })));
//
//            builder.AppendLine("----------------------------------------------------------");
//
//            builder.AppendLine(StopWatchTools.CountTime((() =>
//            {
//                for (int i = 0; i < 1000; i++)
//                {
//                    int[] arr = new int[arrLength];
//
//                    for (int j = 0; j < arrLength; j++)
//                    {
//                        arr[j] = rand.Next(1000);
//                    }
//
//                    demo.OtherSolution(arr);
//                }
//
//                return "OtherSolution";
//            })));
//
//            builder.AppendLine("----------------------------------------------------------");
//
//            builder.AppendLine(StopWatchTools.CountTime((() =>
//            {
//                for (int i = 0; i < 1000; i++)
//                {
//                    int[] arr = new int[arrLength];
//
//                    for (int j = 0; j < arrLength; j++)
//                    {
//                        arr[j] = rand.Next(1000);
//                    }
//
//                    demo.OtherSolution2(arr);
//                }
//
//                return "OtherSolution2";
//            })));
//
//            builder.AppendLine("----------------------------------------------------------");

            string path = "F:\\work_data\\cast\\vs\\Console.Arithmetic\\Console.Arithmetic\\Logs\\" +
                          Guid.NewGuid().ToString() + ".log";

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(builder.ToString().Replace("\n", "\r\n"));
            }

            Console.WriteLine("Success!");

            Console.ReadKey();
        }
    }
}