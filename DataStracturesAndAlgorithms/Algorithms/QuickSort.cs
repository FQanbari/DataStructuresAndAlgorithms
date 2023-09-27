using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms;

public static class QuickSort
{
    public static int Sum(int[] arr)
    {
        if(arr.Length == 0) return 0;

        return arr[0] + Sum(arr[1..]);
    }

    public static int Count(int[] arr)
    {
        if (arr.Length == 0) return 0;

        return 1 + Count(arr[1..]);
    }
}
