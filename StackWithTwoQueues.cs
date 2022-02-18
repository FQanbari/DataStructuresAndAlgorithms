using System.Collections.Generic;

namespace DataStructures
{
    public class StackWithTwoQueues
    {
        private Queue<int> queue1 = new Queue<int>();
        private Queue<int> queue2 = new Queue<int>();
        private int count;
        //- push 
        public void push(int item)
        {
            queue2.Enqueue(item);
            while (queue1.Count != 0)
            {
                queue2.Enqueue(queue1.Dequeue());
            }
            Queue<int> temp = queue1;
            queue1 = queue2;
            queue2 = temp;
            count++;
        }
        //- pop 
        public int pop()
        {           
            count--;
            return queue1.Dequeue();
        }
        //- peek 
        public int peek()
        {
            return queue1.Peek();
        }
        //- size 
        public int size()
        {
            return count;
        }
        //- isEmpty
        public bool isEmpty()
        {
            return count == 0;
        }
    }
}

