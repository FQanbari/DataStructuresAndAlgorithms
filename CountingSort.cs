//using Lucene.Net.Util;
//using NetTopologySuite.Utilities;

namespace DataStructures
{
    public class CountingSort
    {
        public void sort(int[] array)
        {
            var temp = new int[range(array) + 1];
            for(int j = 0; j < array.Length; j++)
            {
                temp[array[j]] += 1;
            }
            var i = 0;
            for (var j = 0; j < temp.Length; j++)
                for(var k=0;k<temp[j];k++)
                    array[i++] = j;
            
        }
        private int range(int[] array)
        {
            if (array.Length == 0)
                return 0;

            var max = array[0];
            for(int i=1; i < array.Length; i++)
            {
                if (max < array[i])
                    max = array[i];
            }

            return max;
        }
    }
}

