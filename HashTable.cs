using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class HashTable
    {
        private class Entry
        {
            public int key;
            public string value;
            public Entry(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }
        private LinkedList<Entry>[] items;
        private int index;
        public HashTable(int lenght)
        {
            items = new LinkedList<Entry>[lenght];
        }
        public void put(int k, string v)
        {

            var entry = GetEntry(k);
            if(entry != null)
            {
                entry.value = v;
                return;
            }

            getOrCreateBucket(k).AddLast(new Entry(k, v));
        }
        private int hash(int key)
        {
            return key % items.Length;
        }
        public string get(int k)
        {
            var result = GetEntry(k);
            return (result != null) ? result.value : null;
        }

        public void remove(int k)
        {
            var entry = GetEntry(k);
            
            if(entry == null)
             throw new Exception();

            getBucket(k).Remove(entry);
        }

        private LinkedList<Entry> getBucket(int k)
        {
            return items[hash(k)];
        }
        private LinkedList<Entry> getOrCreateBucket(int k)
        {
            var index = hash(k);
            if (items[index] == null)
                items[index] = new LinkedList<Entry>();

            return items[index];
        }
        private Entry GetEntry(int key)
        {            
            var bucket = getBucket(key);
            if (bucket != null)
            {
                foreach (var item in bucket)
                {
                    if (item.key == key)
                        return item;
                }
            }
            return null;
        }
    }
}

