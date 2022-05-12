//using Lucene.Net.Util;
using java.util;
//using NetTopologySuite.Utilities;
using System;
using System.Runtime;
using System.Collections;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var sorting = new BucketSort();
            var list = new int[] {};
            sorting.sort(list,4);

            foreach (var item in list)
                Console.WriteLine(item);
        }
    }
}

