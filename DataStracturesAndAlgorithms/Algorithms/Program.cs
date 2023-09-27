

using Algorithms;

var array = new int[] { 2, 6, 9, 3, 5, 4, 1 };
QuickSort.Sort(array,0,6);

foreach (var item in array)
    Console.WriteLine(item);

