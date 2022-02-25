using System;

namespace DataStructures
{
    public class HashMap
    {
        private class Entry
        {
            public int key;
            public string value;
            public Entry(int key,string value)
            {
                this.key = key;
                this.value = value;
            }
        }
        Entry[] Entries = new Entry[5];
        //- put(int, String)
        public void put(int key,string value)
        {
            var index = hash(key);
            
            
            while(Entries[index] != null)
            {
                if (Entries[index].key == key)
                {
                    Entries[index].value = value;
                    break;
                }
                    
                if (index == Entries.Length - 1) break;
                index++;                
            }
            if (Entries[index] == null)
                Entries[index] = new Entry(key, value);
        }
        //- get(int)
        public string get(int key)
        {
            var index = hash(key);
            return (Entries[index] == null) ? null : Entries[index].value;
        }
        //- remove(int)
        public void remove(int key)
        {
            var index = hash(key);
            
            if(Entries[index] == null) throw new Exception();
            if (Entries[index].key != key)
            {
                while(Entries[index].key != key)
                {
                    if (Entries[index].key == key)
                    {
                        break;
                    }
                    if (index == Entries.Length - 1) break;
                    index++;
                }
            }
                Entries[index] = null;
        }
        //- size()
        public int size()
        {
            return Entries.Length;
        }
        public int hash(int key)
        {
            return key % Entries.Length;
        }
    }
}

