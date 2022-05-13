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
            var sorting = new Search();
            var list = new int[] {  };

            Console.WriteLine(sorting.exponentialSearch(list,5));
        }
    }
}

