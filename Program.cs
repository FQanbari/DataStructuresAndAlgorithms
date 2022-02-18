using System.Collections;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var stack = new StackWithTwoQueues();
            stack.push(1);
            stack.push(3);
            stack.push(4);
            //stack.pop();
            //var result = stack.pop();
            stack.push(5);
            var pe = stack.peek();
            var count = stack.size();
            var result = stack.pop();
            pe = stack.peek();
            count = stack.size();
            var isEmpty = stack.isEmpty();
        }

    }
}

