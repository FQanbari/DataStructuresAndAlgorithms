
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    partial class Program
    {
        public static void reverse(Queue<int> queue)
        {
            var stack = new Stack<int>();
            while (queue.Count != 0)
                stack.Push(queue.Dequeue());

            while (stack.Count != 0)
                queue.Enqueue(stack.Pop());
        }
    }
}
