using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cons.Arithmetic.Sort.Tools
{
    public class ShowTools
    {

        public static void ShowLine()
        {
            Console.WriteLine("----------------cool---------------------");
        }

        public static void ShowArr(int[] arr)
        {
            var max = arr.Max();

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (max - arr[j] > i)
                    {
                        Console.Write("□");
                    }
                    else
                    {
                        Console.Write("■");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}