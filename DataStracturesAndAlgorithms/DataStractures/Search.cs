//using Lucene.Net.Util;
//using NetTopologySuite.Utilities;
using System;

namespace DataStructures
{
    public class Search
    {
        public int linearSearch(int[] array,int item)
        {
            for (var i = 0;i<array.Length;i++)
                if (array[i] == item)
                    return i;

            return -1;
        }
        private int binarySearchRec(int[] array,int target,int left,int right)
        {
            if (left > right)
                return -1;

            var middle = (left + right) / 2;
            if (array[middle] == target)
                return middle;

            if (array[middle] > target)
                return binarySearchRec(array, target, left, middle - 1);
            
             return binarySearchRec(array, target,middle + 1, right);            
        }
        public int binarySearchItr(int[] array, int target)
        {
            var left = 0;
            var right = array.Length - 1;
            
            while(left <= right)
            {
                var middle = (left + right) / 2;

                if (array[middle] == target)
                    return middle;

                if (target < array[middle])
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;
        }
        public int ternarySearch(int[] array, int target)
        {
            return ternary(array, target, 0, array.Length - 1);
        }
        private int ternary(int[] array, int target, int left, int right)
        {
            if (left > right)
                return -1;

            var partition = (right - left) / 3;
            var mid1 = left + partition;
            var mid2 = right - partition;

            if (array[mid1] == target)
                return mid1;

            if (array[mid2] == target)
                return mid2;          

            if (array[mid1] > target)
                return ternary(array, target, left, mid1 - 1);

            if (array[mid2] < target)
                return ternary(array, target, mid2 + 1, right);

            return ternary(array, target, mid1 + 1, mid2 - 1);
        }
        //public int binarySearch(int[] array,int item)
        //{
        //    return binarySearchRec(array,item, 0, array.Length - 1);
        //}
        public int jumbSearch(int[] array, int target)
        {
            return jubmpSearchRec(array, target, 0);
            //int blockSize = (int)Math.Sqrt(array.Length);
            //int start = 0;
            //int next = blockSize;

            //while(start < array.Length && array[next - 1] < target)
            //{
            //    start = next;
            //    next += blockSize;
            //    if (next > array.Length)
            //        next = array.Length;
            //}

            //for (var i = start; i < next; i++)
            //    if (array[i] == target)
            //        return i;

            //return -1;
        }
        private int jubmpSearchRec(int[] array, int target,int start)
        {
            var blockSize = (int)Math.Sqrt(array.Length);
            var next = start + blockSize;

            if (start >= array.Length)
                return -1;

            if (array[start] == target)
                return start;

            if (next > array.Length)
                next = array.Length;

            if(target >= start )
                for (var i = start; i < next; i++)
                    if (array[i] == target)
                        return i;

            return jubmpSearchRec(array, target, next);
        }
        public int exponentialSearch(int[] array,int target)
        {
            int bound = 1;
            while (bound < array.Length && array[bound] < target)
                bound *= 2;

            var left = bound / 2;
            var right = Math.Min(bound, array.Length - 1);
            return binarySearchRec(array, target, left, right);
        }
    }
}

