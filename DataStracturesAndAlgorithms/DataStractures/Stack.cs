using System;

namespace DataStructures
{
    public class Stack
    {
        private int count = 0;
        private int[] items = new int[5];
        public Stack()
        {

        }
        public void push(int input)
        {
            if (count == items.Length)
                throw new Exception();
            
            items[count++] = input;
        }

        public int Pop()
        {
            if (count == 0)
                throw new Exception();

            return items[--count];
        }

        public override string ToString()
        {
            //var content = new int[5];
            //var content = items.CopyTo(content, 0, count);
            return items.ToString();
        }
        public void Print()
        {
            for(int i = 0; i < count; i++)
                Console.WriteLine(items[i]);
        }

        public int Peek()
        {
            if (count == 0)
                throw new Exception();

            return items[count - 1];
        }
        
        public bool IsEmpty()
        {
            return count == 0;
        }

        public int Min()
        {
            var min = items[0];
            for(int i= 1; i<count;i++)
            {
                if (items[i] < min)
                    min = items[i];
            }

            return min;
        }
    }
}

