using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Cons.Arithmetic.LeetCode;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1.Week.One
{

    public class ArithmeticTest : IDisposable
    {
        private ITestOutputHelper _output;

        public ArithmeticTest(ITestOutputHelper output)
        {
            this._output = output;
            _output.WriteLine("Execute constructor!");
        }

        [Fact(DisplayName = "LemonadeChange", Skip = "SUCCESS")]
        public void TestLemonadeChange()
        {
            LemonadeChange demo = new LemonadeChange();

            Random random = new Random();

            int randNum = 100;

            int[] price = new[] {5, 10, 20};

            for (int i = 0; i < 10000; i++)
            {
                IList<int> list = new List<int>();
                for (int j = 0; j < price.Length; j++)
                {
                    for (int k = 0; k < random.Next(randNum); k++)
                    {
                        list.Add(price[j]);
                    }
                }

                var simple = demo.Simple(list.ToArray());

                var solution = demo.Solution(list.ToArray());

                _output.WriteLine($@"
arr:{JsonConvert.SerializeObject(list)}
simple:{simple}
solution:{solution}

");

                Assert.Equal(solution, simple);
            }
        }

        [Fact(DisplayName = "ToeplitzMatrix", Skip = "SUCCESS")]
        public void TestToeplitzMatrix()
        {
            int testNum = 100000;

            int randNum = 5;

            Random random = new Random();

            ToeplitzMatrix demo = new ToeplitzMatrix();

            for (int i = 0; i < testNum; i++)
            {
                int width = random.Next(randNum) + 1;
                int height = random.Next(randNum) + 1;

                int[][] martix = new int[width][];

                for (int j = 0; j < width; j++)
                {
                    martix[j] = new int[height];
                    for (int k = 0; k < height; k++)
                    {
                        martix[j][k] = random.Next(2);
                    }
                }

                var solution = demo.Solution(martix);

                var otherSolution = demo.OtherSolution(martix);

                _output.WriteLine($@"
martix:{JsonConvert.SerializeObject(martix)}
result:{solution}
otherSolution:{otherSolution}
");
                Assert.Equal(solution, otherSolution);
            }
        }

        [Fact(DisplayName = "LetterCasePermutation", Skip = "SUCCESS")]
        public void TestLetterCasePermutation()
        {
            int testNum = 100000;

            int randNum = 5;

            Random random = new Random();

            LetterCasePermutation demo = new LetterCasePermutation();

            for (int i = 0; i < testNum; i++)
            {
                char[] arr = new char[randNum];

                for (int j = 0; j < arr.Length; j++)
                {
                    int num = random.Next(3);
                    if (num == 0)
                    {
                        arr[j] = (char) (random.Next(26) + 65);
                    }
                    else if (num == 1)
                    {
                        arr[j] = (char) (random.Next(26) + 97);
                    }
                    else
                    {
                        arr[j] = (char) (random.Next(10) + 48);
                    }
                }

                string str = new string(arr);

                IList<string> bfsSolution = demo.BFSSolution(str);

                List<string> dfsSolution = (List<string>) demo.DFSSolution(str);

                _output.WriteLine($@"

str:{str}
bfs:{JsonConvert.SerializeObject(bfsSolution)}
dfs:{JsonConvert.SerializeObject(dfsSolution)}

");

                for (int k = 0; k < dfsSolution.Count; k++)
                {
                    var item = dfsSolution[k];

                    var contains = bfsSolution.Contains(item);

                    var indexOf = dfsSolution.IndexOf(item, k + 1);

                    Assert.Equal(indexOf, -1);

                    Assert.Equal(contains, true);
                }
            }
        }

        public void Dispose()
        {
            _output.WriteLine("Execute dispose!");
        }
    }
}