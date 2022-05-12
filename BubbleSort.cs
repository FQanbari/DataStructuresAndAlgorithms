//using Lucene.Net.Util;
//using NetTopologySuite.Utilities;

namespace DataStructures
{
    public class BubbleSort
    {
        public void sort(int[] array)
        {
            bool isSorted;
            for (int n = 0; n < array.Length; n++)
            {
                isSorted = true;
                for (int i = 1; i < array.Length - n; i++)                
                    if (array[i] < array[i - 1])
                    {
                        swap(array, i, i - 1);
                        isSorted = false;
                    }

                if (isSorted)
                    return;
            }
        }
        
        private void swap(int[] array, int first,int next)
        {
            var temp = array[first];
            array[first] = array[next];
            array[next] = temp;
        }
    }
}

