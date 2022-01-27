using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new Array(3);
            array.Insert(2);
            array.Insert(7);
            array.Insert(33);
            array.Insert(5);

            var array2 = new Array(3);
            array2.Insert(2);
            array2.Insert(7);
            array2.Insert(0);
            array2.Insert(43);
            array2.Insert(11);
            array2.Insert(41);

            Console.WriteLine("Print Array:");
            array.Print();
            Console.WriteLine("----------------");

            array.InsertAt(23, 5);
            array.InsertAt(14, 7);
            Console.WriteLine("Insert At: 23 in 5th item and 14 in 7th item");            
            array.Print();
            Console.WriteLine("----------------");

            var reverse = array.Reverse();
            Console.WriteLine("Reverse Array: ");
            reverse.Print();
            Console.WriteLine("----------------");

            
            Console.WriteLine("Maximum Array: {0}", array.Max());
            array.Print();
            Console.WriteLine("----------------");

            Console.WriteLine("Index Of: {0}", array.IndexOf(5));
            Console.WriteLine("----------------");

            array.RemoveAt(5);
            Console.WriteLine("Remove 5th item");
            array.Print();
            Console.WriteLine("----------------");

            var result = array.Intersect(array2);
            Console.WriteLine("Intrersect array: ");
            result.Print();
            Console.WriteLine("----------------");

            Console.ReadLine();
        }
    }
}

