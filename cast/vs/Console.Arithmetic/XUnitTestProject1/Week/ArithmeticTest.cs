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
        private const string SUCCESS = nameof(SUCCESS);

        private ITestOutputHelper _output;

        Random rand = new Random();

        public ArithmeticTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Execute constructor!");
        }

        [Fact(DisplayName = "TestReverseOnlyLetters", Skip = SUCCESS)]
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
                    arr[j] = (char) (rand.Next('z') + 65);
                }

                var str = new string(arr);

                //var solution = demo.Solution(str);

                //var otherSolution = demo.OtherSolution(str);

                var otherSolution = StopWatchTools.CountTime(() => demo.OtherSolution(str));
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

        [Fact(DisplayName = "TestRelativeRanks")]
        public void TestRelativeRanks()
        {
            RelativeRanks demo = new RelativeRanks();

            for (int i = 0; i < 1000; i++)
            {
                int randNum = rand.Next(11);

                int[] arr = new int[randNum];

                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = rand.Next(10);
                }

                var simple = demo.Simple(arr);

                var otherSolution = demo.OtherSolution(arr);

                _output.WriteLine($@"
{nameof(arr)}:{JsonConvert.SerializeObject(arr)}
{nameof(simple)}:{JsonConvert.SerializeObject(simple)}
{nameof(otherSolution)}:{JsonConvert.SerializeObject(otherSolution)}
");

                Assert.Equal(JsonConvert.SerializeObject(simple), JsonConvert.SerializeObject(otherSolution));
            }
        }

        public void Dispose()
        {
            _output.WriteLine("Execute dispose!");
        }
    }
}