using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class CharFinder
    {
        public char findFirsNonRepeatingChar(string str)
        {
            var hashTable = new Hashtable();
            foreach (var ch in str)
            {
                var count = hashTable.ContainsKey(ch) ? (int)hashTable[ch] : 0;
                if (count == 0)
                    hashTable.Add(ch, count + 1);
                else
                    hashTable[ch] = count + 1;
            }

            foreach (var ch in str)
            {
                if ((int)hashTable[ch] == 1) return ch;
            }

            return char.MinValue;
        }
        public char firstRepeatedChar(string str)
        {
            var set = new HashSet<char>();
            foreach (var ch in str)
            {
                if (set.Contains(ch))
                    return ch;

                set.Add(ch);
            }

            return char.MinValue;
        }
    }
}

