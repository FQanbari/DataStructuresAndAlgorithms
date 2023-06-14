﻿using Algorithms;


var array = new int[] { 6, 8,2, 1,3,5,7,4 };
array = SelectionSort.Sort(array);
for (int i = 0; i < array.Length; i++)
    Console.WriteLine(array[i]);

Console.WriteLine($"index: {BinarySearch.Search(array, 6)}");

Recursive.CountDown(3);

Console.WriteLine(Recursive.Fact(5));