using System.Collections;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashMap();
            hashTable.put(6, "A");
            hashTable.put(8, "B");
            hashTable.put(11, "C");
            hashTable.put(6, "A+");
            var value = hashTable.get(6);
            hashTable.remove(11);
        }

    }
}

