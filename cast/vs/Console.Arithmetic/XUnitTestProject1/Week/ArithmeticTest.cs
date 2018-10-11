using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Cons.Arithmetic.LeetCode;
using Cons.Arithmetic.LeetCode.Design.Inherit;
using Cons.Arithmetic.LeetCode.Week.Two;
using Cons.Arithmetic.Tools;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class ArithmeticTest : IDisposable
    {
        private ITestOutputHelper _output;

        public ArithmeticTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Execute constructor!");
        }

        [Fact(DisplayName = "TestReverseOnlyLetters")]
        public void TestReverseOnlyLetters()
        {
            var demo = new ReverseOnlyLetters();

            var rand = new Random();

            for (int i = 0; i < 1000; i++)
            {

                var len = rand.Next(10) + 25;

                char[] arr = new char[len];

                for (int j = 0; j < len; j++)
                {
                    arr[j] = (char)(rand.Next('z') + 65);
                }

                var str = new string(arr);

                //var solution = demo.Solution(str);

                //var otherSolution = demo.OtherSolution(str);

                var otherSolution = StopWatchTools.CountTime(()=>demo.OtherSolution(str));
                var solution = StopWatchTools.CountTime(() => demo.Solution(str));

                _output.WriteLine($@"

str:{str}
solution time:{solution}
otherSolution time:{otherSolution}

");

                //                _output.WriteLine($@"

                //str:{str}
                //solution:{solution}
                //otherSolution:{otherSolution}

                //");

                //                Assert.Equal(solution, otherSolution);

            }

        }

        public void Dispose()
        {
            _output.WriteLine("Execute dispose!");
        }
    }
}