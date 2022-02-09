using System;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();
            stack.push(7);
            stack.push(15);
            stack.push(3);

            var min = stack.Min();

            stack.Pop();
            var min2 = stack.Min();
            
        }
    }
}

