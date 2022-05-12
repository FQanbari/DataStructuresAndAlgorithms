//using Lucene.Net.Util;
//using NetTopologySuite.Utilities;

namespace DataStructures
{
    public class QuickSort
    {
        public void sort(int[] array)
        {
            sort2(array, 0, array.Length - 1);
            //sort(array, 0);
        }
        private void sort2(int[] array,int start, int end)
        {
            if (start >= end)
                return;

            var boundary = partition(array,start,end);

            sort2(array, start, boundary - 1);
            sort2(array, boundary + 1, end);
        }
        //index of pivot after right position
        private int partition(int[] array, int start, int end)
        {
            var pivot = array[end];
            var boundary = start - 1;

            for (var i = start; i <= end; i++)
                if (array[i] <= pivot)
                    swap(array, i, ++boundary);

            return boundary;
        }
        private void sort(int[] array,int index)
        {
            int b = -1;
            if (array.Length == index)
                return;

            var pivot = array[array.Length - 1 - index];

            for(var i = 0; i < array.Length; i++)
            {
                if(array[i] < pivot)
                {
                    b++;
                    swap(array, b, i);
                }
            }

            sort(array,++index);
        }
        private void swap(int[] array, int first, int next)
        {
            var temp = array[first];
            array[first] = array[next];
            array[next] = temp;
        }
    }
}

