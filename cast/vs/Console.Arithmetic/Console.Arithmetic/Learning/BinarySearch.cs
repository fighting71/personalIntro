using System;
using System.Collections.Generic;
using System.Text;

namespace Cons.Arithmetic.Learning
{
    public class BinarySearch
    {

        static int binary_search(int[] arr, int start, int end, int khey)
        {
            int mid;
            while (start <= end)
            {
                mid = (start + end) / 2;
                if (arr[mid] < khey)
                    start = mid + 1;
                else if (arr[mid] > khey)
                    end = mid - 1;
                else
                    return mid;
            }
            return -1;
        }

    }
}
