using System;
using Cons.Arithmetic.Sort.Note;
using Cons.Arithmetic.Sort.Note.Stabilization;
using Cons.Arithmetic.Sort.Note.Unstability;
using Newtonsoft.Json;

namespace Cons.Arithmetic.Sort
{

    enum Empty
    {
        

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(2 >> 1);

            Console.WriteLine("Hello World!");

            int[] arr = {4, 1, 12, 8, 6, 7, 4, 3, 1, 5, 9, 7, 5, 6, 1, 13, 7};

            QuickSort.qSort(arr, 0, arr.Length - 1);

            Console.WriteLine("-------------" + JsonConvert.SerializeObject(arr));

            //            CocktailSort<int>.OfficeSort(arr);

            //            var sort = CountingSort.Sort(arr);
            //
            //            Console.WriteLine(JsonConvert.SerializeObject(sort));
            //            //
            //            var learning = CountingSort.Learning(arr);
            //
            //            Console.WriteLine(JsonConvert.SerializeObject(learning));
            //
            //            arr =  new int[]{ 23, 52, 5, 1, 2, 41, 5, 1};
            //
            //            OfficeBubbleSort(arr);
            //
            //            Console.WriteLine(JsonConvert.SerializeObject(arr));

            Console.ReadKey();
        }

        static void OfficeBubbleSort(int[] intArray)
        {
            int temp = 0; //交换载体
            bool swapped; //循环优化
            for (int i = 0; i < intArray.Length; i++)
            {
                swapped = false;
                for (int j = 0; j < intArray.Length - 1 - i; j++)
                    if (intArray[j] > intArray[j + 1]) //前者》后者
                    {
                        temp = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = temp; //交换位置
                        if (!swapped)
                            swapped = true; //表示任需继续优化
                    }

                if (!swapped) //循环优化
                    return;
            }
        }

        public static void SimpleBubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}