using System;

namespace DataStructures
{
    public class PriorityQueue
    {
        private int[] items;
        private int count;
        public PriorityQueue(int count)
        {
            this.items = new int[count];
        }
        public void insert(int item)
        {
            if (isFull())
                throw new Exception();

            var i = shiftItemsToInsert(item);
            items[i ] = item;
            count++;
        }
        public int shiftItemsToInsert(int item)
        {
            int i;
            for (i = count - 1; i >= 0; i--)
            {
                if (item < items[i])
                {
                    items[i + 1] = items[i];
                }
                else
                {

                    break;
                }
            }

            return i + 1;
        }
        public bool isFull()
        {
            return count == items.Length;
        }
        public int remove()
        {
            if (isEmpty())
                throw new Exception();

            return items[--count];
        }
        public bool isEmpty()
        {
            return count == 0;
        }
    }
}

