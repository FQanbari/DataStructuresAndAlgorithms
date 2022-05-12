//using Lucene.Net.Util;
//using NetTopologySuite.Utilities;

namespace DataStructures
{
    public class SelectionSort
    {
        public void sort(int[] array)
        {
            var temp = new int[array.Length];
            for (var j = 0; j < array.Length; j++)
                swap(array, j, getMinIndex(array, j));
        }
        public int getMinIndex(int[] array,int index)
        {
            var minIndex = index;
            for (var i = index + 1; i < array.Length; i++)
                if (array[index] > array[i])
                    minIndex = i;

            return minIndex;
        }
        private void swap(int[] array, int first, int next)
        {
            var temp = array[first];
            array[first] = array[next];
            array[next] = temp;
        }
    }
}

