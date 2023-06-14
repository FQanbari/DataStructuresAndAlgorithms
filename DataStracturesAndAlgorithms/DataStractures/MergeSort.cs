//using Lucene.Net.Util;
//using NetTopologySuite.Utilities;

namespace DataStructures
{
    public class MergeSort
    {
        public void sort(int[] array)
        {
            if (array.Length <= 1)
                return;

            int middle = array.Length / 2;

            var left = new int[middle];
            for (var i = 0; i < middle; i++)
                left[i] = array[i];

            var right = new int[array.Length - middle];
            for (var i = middle; i < array.Length; i++)
                right[i - middle] = array[i];

            sort(left);
            sort(right);

            merge(left, right,array); 
        }
        private void merge(int[] left, int[] right, int[] result)
        {
            int leftIndex = 0, rightIndex = 0,resultIndex = 0;
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                    result[resultIndex++] = left[leftIndex++];
                else
                    result[resultIndex++] = right[rightIndex++];                
            }

            while (leftIndex < left.Length)
                result[resultIndex++] = left[leftIndex++];

            while (rightIndex < right.Length)
                result[resultIndex++] = right[rightIndex++];
        }
        
    }
}

