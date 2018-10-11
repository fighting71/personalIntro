using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Cons.Arithmetic.Book;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class UTBook : IDisposable
    {
        private ITestOutputHelper _output;

        public UTBook(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Execute constructor!");
        }

        [Fact(DisplayName = "Verity",Skip = "SUCCESS")]
        public void TestVerity()
        {
            var verity = new Verity();

            var k = 3;

            for (var i = 5; i <= 1000; i++)
            {
                var mutiply = verity.getMutiply(i);
                var maxPower = verity.getMaxPower(i, k);

//                var exceptNum = (BigInteger) Math.Pow(k, maxPower); 当数字过大时 long cast to BigInteger Can lost some number

                var exceptNum = verity.getPower(k, maxPower);

                _output.WriteLine($@"
n:{i}
k:{k}
{nameof(mutiply)}:{mutiply}
{nameof(maxPower)}:{maxPower}
{nameof(exceptNum)}:{exceptNum}
except:{mutiply % exceptNum == 0} ==> n! %  k^h = 0
except:{mutiply % (exceptNum * k) != 0} ==> n! % k^(h+1) != 0

");

                Assert.Equal(mutiply % exceptNum, 0); // n! %  k^h = 0
                Assert.Equal(mutiply % (exceptNum * k) != 0, true); // n! % k^(h+1) != 0

            }
        }

        public void Dispose()
        {
            _output.WriteLine("Execute dispose!");
        }
    }
}