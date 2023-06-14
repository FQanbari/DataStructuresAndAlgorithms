using System;

namespace DataStructures
{
    public class LinkedList
    {
        private class Node
        {
            public Node(int value)
            {
                this.value = value;
            }
            public int value;
            public Node next;
        }
        private Node first;
        private Node last;
        private int size;
        private bool IsEmpty() => first == null;
        public int Size() => size;
        private Node PrevNode(Node node)
        {
            var current = first;
            while (current != null)
            {
                if (current.next == node) return current;
                current = current.next;
            }
            return null;
        }
        public void AddFirst(int item)
        {
            var node = new Node(item);
            if (IsEmpty())
                last = first = node;
            else
            {
                node.next = first;
                first = node;
            }
            size++;
        }
        public void AddLast(int item)
        {
            var node = new Node(item);
            if (IsEmpty())
                last = first = node;
            else
            {
                last.next = node;
                last = node;
            }
            size++;
        }
        public void DeleteFirst()
        {
            if (IsEmpty())
                throw new Exception();
            if (first == last)
            {
                first = last = null;
            }
            else
            {
                var second = first.next;
                first.next = null;
                first = second;
            }
            size--;
        }
        public void DeleteLast()
        {
            if (IsEmpty())
                throw new Exception();

            if (first == last)
                first = last = null;

            var prevNode = PrevNode(last);
            last = prevNode;
            last.next = null;
            size--;
        }
        public int IndexOf(int item)
        {
            if (IsEmpty())
                throw new Exception();
            var current = first;
            var index = 0;
            while (current != null)
            {
                if (item == current.value)
                    return index;
                index++;
                current = current.next;
            }
            return -1;
        }
        public bool Contains(int item)
        {
            return IndexOf(item) != -1;
        }
        public int[] ToArray()
        {
            var array = new int[size];
            var current = first;
            var index = 0;
            while (current != null)
            {
                array[index++] = current.value;
                current = current.next;
            }
            return array;
        }
        public void Reverse()
        {
            if (IsEmpty()) throw new Exception();
            var previous = first;
            var current = first.next;
            while (current != null)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            last = first;
            last.next = null;
            first = previous;
        }
        public int GetKthFromTheEnd(int k)
        {
            if (IsEmpty()) throw new Exception();
            if (k > size) throw new Exception();
            var pinter1 = first;
            var current = first;
            var index = 0;
            while (index != k)
            {
                current = current.next;
                index++;
            }
            while (current.next != null)
            {
                current = current.next;
                pinter1 = pinter1.next;
            }

            return pinter1.value;
        }
        public void PrintMiddle()
        {
            var a = first;
            var b = first;
            while (b != last && b.next != last)
            {
                b = b.next.next;
                a = a.next;
            }
            if (b == last)
                Console.WriteLine(a.value);
            else
                Console.WriteLine(a.value + ", " + a.next.value);
        }
        public bool HasLoop()
        {
            var a = first;
            var b = first;
            while (a != null && b != null && b.next != null)
            {
                a = a.next;
                b = b.next.next;
                if (a == b) return true;
            }
            return false;
        }
    }
}

