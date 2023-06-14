using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class QueueReverser
    {
        private Queue<int> queue = new Queue<int>();
        private Stack<int> stack = new Stack<int>();

        public Queue<int> reverse(int k, Queue<int> items)
        {
            if (items.Count == 0)
                throw new Exception();

            if (items.Count > k)
                throw new Exception();

            for (int i = 0; i < k; i++)
                stack.Push(items.Dequeue());

            while (stack.Count != 0)
                queue.Enqueue(stack.Pop());

            while (items.Count != 0)
                queue.Enqueue(items.Dequeue());

            return queue;
        }
    }
}

