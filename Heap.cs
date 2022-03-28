using System;

namespace DataStructures
{
    public class Heap
    {
        private int[] item = new int[10];
        private int size;
        public int Max()
        {
            return item[0];
        }
        public void insert(int value)
        {
            if (isFull())
                throw new Exception();

            item[size++] = value;

            bubbleUp();
        }
        public int remove()
        {
            if (isEmpty())
                throw new Exception();

            var root = item[0];
            item[0] = item[--size];

            bubbleDown();

            return root;
        } 
        private void bubbleDown()
        {
            var index = 0;
            while (index <= size && !isValidParent(index))
            {
                var largindex = largerChildIndex(index);
                swap(index, largindex);
                index = largindex;
            }
        }
        public int largerChildIndex(int index)
        {
            if (!hasLeftChild(index))
                return index;

            if (!hasrightChild(index))
                return leftChildIndex(index);

            return (leftChild(index) > rightChild(index)) ?
                leftChildIndex(index) :
                rightChildIndex(index);
        }
        private bool hasLeftChild(int index)
        {
            return leftChildIndex(index) <= size;
        }
        private bool hasrightChild(int index)
        {
            return rightChildIndex(index) <= size;
        }
        public bool isValidParent(int index)
        {
            if (!hasLeftChild(index))
                return true;

            var isValid = item[index] >= leftChild(index);

            if (hasrightChild(index))
                isValid &= item[index] >= rightChild(index);

            return isValid;
        }
        public int leftChild(int index) => item[leftChildIndex(index)];
        public int rightChild(int index) => item[rightChildIndex(index)];
        public int leftChildIndex(int index) => index * 2 + 1;
        public int rightChildIndex(int index) => index * 2 + 2;
        private void bubbleUp()
        {
            var index = size - 1;
            while (index > 0 && item[index] > item[parentIndex(index)])
            {
                swap(index, parentIndex(index));
                index = parentIndex(index);
            }
        }
        private void swap(int first, int second)
        {
            var temp = item[first];
            item[first] = item[second];
            item[second] = temp;
        }
        private bool isFull()
        {
            return size == item.Length;
        }
        public bool isEmpty()
        {
            return size == 0;
        }
        private int parentValue(int index)
        {
            return item[parentIndex(index)];
        }
        private int parentIndex(int index)
        {
            return ((index - 1) / 2);
        }
        public static bool isMaxHeap(int[] array)
        {
            var isMax = true;
            var lastParentIndex = array.Length / 2 - 1;
            for (var i = lastParentIndex; i >= 0; i--)
                isMax &= isMaxHeap(array, i);

            return isMax;
        }
        private static bool isMaxHeap(int[] array, int index)
        {
            var leftIndex = index * 2 + 1;
            var rightIndex = index * 2 + 2;
            if (leftIndex > array.Length && array[index] < array[leftIndex] || array[index] < array[rightIndex])
                return false;

            return true;
        }
    }
}

