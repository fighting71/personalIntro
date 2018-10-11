using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Cons.Arithmetic.LeetCode;
using Cons.Arithmetic.LeetCode.Design.Inherit;
using Cons.Arithmetic.LeetCode.Week.Two;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1.Two
{
    public class ArithmeticTest : IDisposable
    {
        private ITestOutputHelper _output;

        public ArithmeticTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Execute constructor!");
        }

        [Fact(DisplayName = "PathSumIII", Skip = "SUCCESS")]
        public void TestPathSumIII()
        {
            //懒到只想一次弄完=-=
            var root = new TreeNode<int>(10)
                .AddChildrenNode(
                    new TreeNode<int>(5)
                        .AddChildrenNode(
                            new TreeNode<int>(3)
                                .AddChildrenNode(new TreeNode<int>(3), new TreeNode<int>(-2)),
                            new TreeNode<int>(2)
                                .AddChildrenNode(null, new TreeNode<int>(1))),
                    new TreeNode<int>(-3)
                        .AddChildrenNode(null, new TreeNode<int>(11)));

            var demo = new PathSumIII();
            var simple = demo.Simple(root, 8);

            _output.WriteLine($"simple:{simple}");

            Assert.Equal(3, simple);

            var nextRoot = new TreeNode<int>(8)
                .AddChildrenNode(
                    new TreeNode<int>(-2)
                        .AddChildrenNode(
                            new TreeNode<int>(2),
                            new TreeNode<int>(8)),
                    new TreeNode<int>(3));

            var next = demo.Simple(nextRoot, 6);

            _output.WriteLine($"simple:{next}");
        }

        [Fact(DisplayName = "TwoSum", Skip = "SUCCESS")]
        public void TestTwoSum()
        {
            var demo = new TwoSum();

            var arr = new[] {0, 4, 3, 0};
        }

        [Fact(DisplayName = "HappyNumber", Skip = "SUCCESS")]
        public void TestHappyNumber()
        {
            var happyNumber = new HappyNumber();

            for (var i = 50; i < 1000; i++)
            {
//                var simple = happyNumber.Simple(i);

                var otherSolution = happyNumber.OtherSolution(i);

                _output.WriteLine(happyNumber.count + "  i:" + i);

                happyNumber.count = 0;

//                Assert.Equal(simple,otherSolution);
            }
        }

        [Fact(DisplayName = "RectangleOverlap", Skip = "SUCCESS")]
        public void TestRectangleOverlap()
        {
            var demo = new RectangleOverlap();

            var random = new Random();

            var rctNum = 4;

            for (var i = 0; i < 1000; i++)
            {
                var rct1 = new int[rctNum];
                var rct2 = new int[rctNum];

                for (var j = 0; j < rctNum; j++)
                {
                    rct1[j] = random.Next(4) + (j > 1 ? rct1[j - 2] + 1 : 0);
                    rct2[j] = random.Next(4) + (j > 1 ? rct2[j - 2] + 1 : 0);
                }

                var simple = demo.Simple(rct1, rct2);

                var otherSolution2 = demo.OtherSolution2(rct1, rct2);

                _output.WriteLine($@"
rct1:{JsonConvert.SerializeObject(rct1)}
rct2:{JsonConvert.SerializeObject(rct2)}

simple:{simple}
otherSolution2:{otherSolution2}

");

                Assert.Equal(simple, otherSolution2);
            }
        }

        [Fact(DisplayName = "ReverseInteger")]
        public void TestReverseInteger()
        {
            var demo = new ReverseInteger();

            checked
            {
                for (var i = int.MaxValue - 10000; i < int.MaxValue; i++)
                {
                    var result = demo.Solution(i);

                    _output.WriteLine($"i:{i},reuslt:{result}");
                }
            }
        }

        public void Dispose()
        {
            _output.WriteLine("Execute dispose!");
        }
    }
}