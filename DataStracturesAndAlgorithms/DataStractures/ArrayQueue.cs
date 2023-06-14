using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class ArrayQueue
    {
        public int count;
        private int rear;
        private int front;
        private int[] items;
        public ArrayQueue(int capaicity)
        {
            items = new int[capaicity];
        }
        public void enqueue(int item)
        {
            if (count == items.Length)
                throw new Exception();

            items[rear] = item;
            rear = (rear + 1) % items.Length;
            count++;
        }
        public int dequeue()
        {
            var item = items[front];
            items[front] = 0;
            front = (front + 1) % items.Length;
            count--;
            return item;
        }
        public int[] toArry()
        {
            return items;
        }
        public int peek()
        {
            return items[front];
        }
        public bool isEmpty()
        {
            return count == 0;
        }
        public bool isFull()
        {
            return count == items.Length;
        }
    }
}
