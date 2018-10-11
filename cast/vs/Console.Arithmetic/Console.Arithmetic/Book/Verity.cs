using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Cons.Arithmetic.Book
{
    public class Verity
    {
        //param: n!  k

        //verity: n/k + n/k^2 .... n/k^m = h

        //note: k^m < n

        // ==> n! % k^h = 0  && n! % k^(h+1) != 0 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">num!</param>
        /// <returns></returns>
        public BigInteger getMutiply(long num)
        {
            BigInteger sum = 1;

            for (long i = 2; i <= num; i++)
            {
                sum *= i;
            }

            return sum; //溢出...
        }

        public BigInteger getMaxPower(long num, long k)
        {
            BigInteger maxPower = 0;

            long emptyNum;

            long mutiplyNum = k;

            while ((emptyNum = num / mutiplyNum) > 0)
            {
                mutiplyNum *= k;
                maxPower += emptyNum; ////498   333 + 111 + 37 + 12 + 4 + 1
            }

            return maxPower;
        }

        public BigInteger getPower(BigInteger num, BigInteger power)
        {
            BigInteger sum = 1;

            for (int i = 0; i < power; i++)
            {
                sum *= num;
            }

            return sum;
        }
    }
}