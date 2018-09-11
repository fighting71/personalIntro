using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Command.Tools
{
    public class CommandTool
    {
        protected static Stopwatch timer;

        public static void InitTimer()
        {
            if (timer != null)
            {
                timer.Restart();
            }
            else
            {
                timer = new Stopwatch();
                timer.Start();
            }
        }

        public static void CountTime(Func<object> runner)
        {
            InitTimer();

            var result = runner.Invoke();

            timer.Stop();

            Console.WriteLine("执行完毕,总执行时间：{0},返回值：{1}", timer.ElapsedMilliseconds, JsonConvert.SerializeObject(result));

        }
    }
}