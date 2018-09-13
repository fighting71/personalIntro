using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;

namespace Cons.Arithmetic.Tools
{
    public class StopWatchTools
    {
        public static Stopwatch Stopwatch = new Stopwatch();

        protected static void Init()
        {
            if (Stopwatch == null)
            {
                Stopwatch = new Stopwatch();
                Stopwatch.Start();
            }
            else
            {
                Stopwatch.Restart();
            }
        }

        public static string CountTime(Func<object> runner)
        {
            Init();

            var result = runner.Invoke();

            return string.Format(@"
spend time:{0}s
result:{1}
", Stopwatch.Elapsed.TotalSeconds, JsonConvert.SerializeObject(result));
        }

        public static double CountTime(Action runner)
        {
            Init();

            runner.Invoke();

            return Stopwatch.Elapsed.TotalSeconds;
        }

        public static void ShowCountTime(Func<object> runner)
        {
            Console.WriteLine(CountTime(runner));
        }

    }
}