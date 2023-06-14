using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class QueueWithTwoStacks
    {
        private Stack<int> stack1 = new Stack<int>();
        private Stack<int> stack2 = new Stack<int>();

        //o(1)
        public void enqueue(int item)
        {
            stack1.Push(item);
        }
        //o(n)
        public int dequeue()
        {
            if (isEmpty())
                throw new Exception();

            moveStack1ToStack2();

            return stack2.Pop();
        }

        public bool isEmpty()
        {
            return stack2.Count == 0 && stack1.Count == 0;
        }

        public int peek()
        {
            if (isEmpty())
                throw new Exception();

            moveStack1ToStack2();

            return stack2.Peek();
        }

        public void moveStack1ToStack2()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count != 0)
                    stack2.Push(stack1.Pop());
            }
        }
    }
}

