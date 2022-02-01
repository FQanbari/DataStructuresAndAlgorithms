using System;
using System.Collections.Generic;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList();
            //Console.WriteLine("size : {0}", linkedList.Size());
            linkedList.AddFirst(7);
            linkedList.AddFirst(33);
            linkedList.AddLast(13);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(27);
            linkedList.AddLast(29);

            //Console.WriteLine("size : {0}", linkedList.Size());
            //linkedList.DeleteFirst();
            //Console.WriteLine(linkedList.IndexOf(93));
            //Console.WriteLine(linkedList.Contains(7));
            //linkedList.DeleteLast();
            //Console.WriteLine("size : {0}", linkedList.Size());
            //var str = linkedList.ToArray();
            //foreach (var item in str)
            //    Console.WriteLine(item);

            //linkedList.Reverse();
            //var str0 = linkedList.ToArray();
            //foreach (var item in str0)
            //    Console.WriteLine(item);
            //var kth = linkedList.GetKthFromTheEnd(3);
            //Console.WriteLine("3th from the end is {0}", kth);
            //linkedList.PrintMiddle();
            //var result = (linkedList.HasLoop());

            Console.ReadLine();
        }
    }
}

