using System.Collections.Generic;

namespace DataStructures
{
    public class LinkedListQueue
    {
        private LinkedList<int> items = new LinkedList<int>();
        //- enqueue 
        public void enqueue(int item)
        {
            items.AddLast(item);
        }
        //- dequeue 
        public int dequeue()
        {
            var result = items.First;
            items.RemoveFirst();
            return result.Value;
        }
        //- peek 
        public int peek()
        {
            return items.First.Value;
        }
        //- size 
        public int size()
        {
            return items.Count;
        }
        //- isEmpty
        public bool isEmpty()
        {
            return items.Count == 0;
        }
    }
}

