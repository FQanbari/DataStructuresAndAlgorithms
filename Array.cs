using System;

namespace DataStructures
{
    public class Array
    {
        private int count;
        private int[] items;
        public Array(int length)
        {
            items = new int[length];
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
                Console.WriteLine(items[i]);
        }
        public void Insert(int item)
        {
            if (count == items.Length)
            {
                var newItems = new int[count * 2];
                for (int i = 0; i < count; i++)
                    newItems[i] = items[i];

                items = newItems;
            }

            items[count++] = item;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new Exception();

            for (int i = index; i < count - 1; i++)
                items[i] = items[i + 1];

            count--;
        }
        public int IndexOf(int item)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i] == item)
                    return i;
            }

            return -1;
        }
        public int Max()
        {
            var max = items[0];
            for (int i = 1; i < count; i++)
            {
                if (items[i] > max)
                    max = items[i];
            }
            return max;
        }
        public Array Intersect(Array array)
        {
            var arrayResult = new Array(count);
            for (int i = 0; i < count; i++)
            {
                for (int r = 0; r < array.count; r++)
                {
                    if (array.items[r] == items[i])
                        arrayResult.Insert(items[i]);
                }

            }

            return arrayResult;
        }
        public Array Reverse()
        {
            var arrayResult = new Array(count);
            for (int i = count; i > 0; i--)
                arrayResult.Insert(items[i - 1]);

            return arrayResult;
        }
        public void InsertAt(int item,int index)
        {
            if(index >= count)
            {
                var newItems = new int[count * 2];
                for (int i = 0; i < count; i++)
                    newItems[i] = items[i];

                items = newItems;
                count *= 2;
            }
            items[index] = item;
        }
    }

}

