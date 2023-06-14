using System.Linq;
using System.Collections.Generic;

namespace DataStructures
{
    public class HashTableExercises
    {
        public int mostFrequent(int[] items)
        {
            var hashTable = new Dictionary<int,int>();
            foreach (var item in items)
            {
                var count = (hashTable.ContainsKey(item)) ? (int)hashTable[item] : 0;
                if(count == 0)
                    hashTable.Add(item, count + 1);
                else
                    hashTable[item] = count + 1;
            }

            var max = (int)hashTable[items[0]];
            var index = 0;
            for (int i=1;i<items.Length;i++)
            {
                if((int)hashTable[items[i]] > max)
                {
                    max = (int)hashTable[items[i]];
                    index = i;
                }
            }

            return hashTable.Keys.AsQueryable().FirstOrDefault(s => hashTable[s] == max);
        }
        public int countPairsWithDiff(int[] items,int k)
        {
            var hashtable = new Dictionary<int,int>();
            foreach (var i in items)
            {
                foreach (var j in items)
                {
                    if ((i - j) == k)
                        hashtable.Add(i, j);
                }
            }

            return hashtable.Count;
        }
        public int[] twoSum(int[] items,int target)
        {
            var hashtable = new Dictionary<int, int>();
            var indexA = 0;
            var indexB = 0;
            var result = new int[2];
            foreach (var i in items)
            {                
                foreach (var j in items)
                {
                    if ((i + j) == target)
                    {
                        hashtable.Add(i, j);
                        result[0] = indexA;
                        result[1] = indexB;
                        break;
                    }
                    indexB++;
                }
                indexA++;
            }

            return result;
        }
    }
}

