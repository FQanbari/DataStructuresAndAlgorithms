using System;

namespace DataStructures
{
    public class MaxHeap
    {
        public static void heapify(int[] array)
        {
            var lastParentIndex = array.Length / 2 - 1;
            for (int i = lastParentIndex; i >= 0 ; i--)
                heapify(array, i);
        } 

        private static void heapify(int[] array, int index)
        {
            var largestIndex = index;

            var leftIndex = index * 2 + 1;
            if (leftIndex < array.Length && array[leftIndex] > array[largestIndex])
                largestIndex = leftIndex;

            var rightIndex = index * 2 + 2;
            if (rightIndex < array.Length &&  array[rightIndex] > array[largestIndex])
                largestIndex = rightIndex;

            if (index == largestIndex)
                return;

            swap(array, index, largestIndex);
            heapify(array, largestIndex);
        }

        private static void swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        public static int getKthLargest(int[] array, int k)
        {
            if (k < 1 || k > array.Length)
                throw new Exception();

            var heap = new Heap();

            foreach (var item in array)
                heap.insert(item);

            for (var i = 0; i < k - 1; i++)
                heap.remove();

            return heap.Max();
        }
        public static void minHeapify(int[] array)
        {
            var lastParentIndex = array.Length / 2 - 1;
            for (int i = lastParentIndex; i >= 0 ; i--)
                minHeapify(array, i);
        }
        private static void minHeapify(int[] array, int index)
        {
            var smallestIndex = index;

            var leftIndex = index * 2 + 1;
            if (leftIndex < array.Length && array[leftIndex] < array[smallestIndex])
                smallestIndex = leftIndex;

            var rightIndex = index * 2 + 2;
            if (rightIndex < array.Length && array[rightIndex] < array[smallestIndex])
                smallestIndex = rightIndex;

            if (index == smallestIndex)
                return;

            swap(array, index, smallestIndex);
            minHeapify(array, smallestIndex);            
        }
    }
}

