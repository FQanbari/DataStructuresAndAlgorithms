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

    public static int Max(int[] arr)
    {
        if (arr.Length == 2) return arr[0] > arr[1] ? arr[0] : arr[1];


        var max = Max(arr[1..]);

        return max > arr[0] ? max : arr[0];
    }

    public static void Sort(int[] arr, int left, int right)
    {

        if (left < right)
        {
            var pivot = _partition(arr, left, right);

            Sort(arr, left, pivot - 1);
            Sort(arr, pivot + 1, right);
        }
    }
    private static int _partition(int[] arr, int left, int right)
    {
        var pivot = arr[right];
        var i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                var temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
        }

        var temp2 = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = temp2;

        return i + 1;
    }
}
