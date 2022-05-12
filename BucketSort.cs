//using Lucene.Net.Util;
//using NetTopologySuite.Utilities;
using System.Collections.Generic;

namespace DataStructures
{
    public class BucketSort
    {
        public void sort(int[] array, int numberOfBuckets)
        {
            var i = 0;
            foreach (var bucket in creatBuckets(array, numberOfBuckets))
            {
                bucket.Sort();
                foreach (var item in bucket)
                    array[i++] = item;
            }
        }

        private static List<List<int>> creatBuckets(int[] array, int numberOfBuckets)
        {
            var buckets = new List<List<int>>();
            for (var j = 0; j < numberOfBuckets; j++)
                buckets.Add(new List<int>());

            foreach (var item in array)
                buckets[item / numberOfBuckets].Add(item);

            return buckets;
        }
    }
}

