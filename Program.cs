using System;
using System.Collections;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 3, 8, 4, 1, 2 };
            string[] charnumber = { "5", "3", "8", "4", "1", "2" };
            var minHeap = new MinHeap(10);
            foreach(var item in charnumber)
                minHeap.Add(item, Convert.ToInt32(item));

            Console.WriteLine(minHeap.Remove());
            Console.WriteLine(minHeap.Remove());
            Console.WriteLine(minHeap.Remove());
            Console.WriteLine(minHeap.Remove());
        }
    }

}

