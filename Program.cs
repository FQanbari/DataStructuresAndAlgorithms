using System;
using System.Collections;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 3, 8, 4, 1, 2 };
            string[] charnumber = { "5", "3", "8", "4", "1", "2" };
            var minHeap = new minHeap(10);
            foreach(var item in charnumber)
                minHeap.Add(item, Convert.ToInt32(item));

            Console.WriteLine(minHeap.Remove());
            Console.WriteLine(minHeap.Remove());
            Console.WriteLine(minHeap.Remove());
            Console.WriteLine(minHeap.Remove());
        }
    }
    public class minHeap
    {
        private class node
        {
            public string value;
            public int key;
        }
        private node[] items;
        private int size;
        public minHeap(int size)
        {
            items = new node[size];
        }
        public void Add(string item, int key)
        {
            if (size == items.Length)
                throw new IndexOutOfRangeException();

            items[size] = new node
            {
                value = item,
                key = key
            };
            size++;

            ReCalculateUp();
        }
        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < size;
        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < size;
        private bool IsRoot(int elementIndex) => elementIndex == 0;

        private void ReCalculateUp()
        {
            var index = size - 1;
            while (!IsRoot(index) && items[index].key < items[GetParentIndex(index)].key)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
        private void ReCalculateDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChildIndex(index) < GetLeftChildIndex(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (items[smallerIndex].key >= items[index].key)
                {
                    break;
                }

                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }
        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
        public string Remove()
        {
            if (size == 0)
                throw new IndexOutOfRangeException();

            var result = items[0];
            items[0] = items[size - 1];
            size--;

            ReCalculateDown();

            return result.value;
        }
    }

}

