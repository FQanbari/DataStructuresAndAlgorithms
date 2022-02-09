using System;

namespace DataStructures
{
    public class TwoStacks
    {
        private int[] items = new int[10];
        private int top1 = 0;
        private int top2 = 9;

        public void push1(int input)
        {
            if (top1 == items.Length)
                throw new Exception();
            if (IsFull1())
                throw new Exception("Stack 1 is fulled");
            if(top1 < top2)
                items[top1++] = input;
        }
        public void push2(int input)
        {
            if (top2 == items.Length)
                throw new Exception();
            if (IsFull2())
                throw new Exception("Stack 2 is fulled");
            if (top1 < top2)
                items[top2--] = input;
        }

        public void Print1()
        {
            for (int i = 0; i < top1; i++)
                Console.WriteLine(items[i]);
        }

        public void Print2()
        {
            for (int i = 9; i > top2; i--)
                Console.WriteLine(items[i]);
        }

        public int Pop1()
        {
            if (top1 == 0)
                throw new Exception();

            return items[--top1];
        }

        public int Pop2()
        {
            if (top2 == 0)
                throw new Exception();

            return items[++top2];
        }
        public bool IsEmpty1()
        {
            return top1 == 0;
        }

        public bool IsEmpty2()
        {
            return top2 == 0;
        }

        public bool IsFull1()
        {
            return top1 == top2;
        }

        public bool IsFull2()
        {
            return top2 == top1;
        }
    }
}

