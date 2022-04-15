using System;
using System.Linq;
using System.Collections.Generic;

namespace DataStructures
{
    public class Graph
    {
        private class Node
        {
            public string lable;
            public Node(string lable)
            {
                this.lable = lable;
            }
        }
        private Dictionary<string,Node> nodes = new Dictionary<string,Node>();
        private Dictionary<Node,List<Node>> adjacencyList  = new Dictionary<Node, List<Node>>();
        public void addNode(string lable)
        {
            var node = new Node(lable);
            if(!nodes.ContainsKey(lable))
                nodes.Add(lable,node);

            if (!adjacencyList.ContainsKey(node))
                adjacencyList.Add(node, new List<Node>());
        }
        public void addEdge(string from,string to)
        {
            var fromNode = nodes[from];
            var toNode = nodes[to];
            if (fromNode == null || toNode == null)
                throw new Exception("not valid node");

            adjacencyList[fromNode].Add(toNode);
        }
        public void print()
        {
            foreach(var source in adjacencyList.Keys)
            {
                var target = adjacencyList[source];
                if(target.Count > 0)
                {
                    Console.Write(source.lable + " is connected to ");
                    foreach(var v in target)
                        Console.Write(v.lable + ", ");
                    Console.WriteLine();
                }
                    
            }
        }
        public void removeNode(string lable)
        {
            var node = nodes[lable];
            if (node == null)
                return;

            foreach (var n in adjacencyList.Keys)
                adjacencyList[n].Remove(node);

            adjacencyList.Remove(node);
            nodes.Remove(lable);
        }
        public void removeEdge(string from,string to)
        {
            var fromNode = nodes[from];
            var toNode = nodes[to];

            if (fromNode == null || toNode == null)
                return;

            adjacencyList[fromNode].Remove(toNode);
        }
        public void traverseDepthFirstRec(string root)
        {            
            if (!nodes.ContainsKey(root))
                return;
            var node = nodes[root];
            traverseDepthFirstRec(node, new HashSet<Node>());
        }
        private void traverseDepthFirstRec(Node root, HashSet<Node> visited)
        {
            Console.WriteLine(root.lable);
            visited.Add(root);

            foreach(var node in adjacencyList[root])
                if (!visited.Contains(node))
                    traverseDepthFirstRec(node, visited);
        }
        public void traverseDepthFirst(string root)
        {
            if (!nodes.ContainsKey(root))
                return;
            var node = nodes[root];

            var visited = new HashSet<Node>();
            var stack = new Stack<Node>();

            stack.Push(node);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current.lable);
                visited.Add(current);
                foreach (var n in adjacencyList[current])
                {
                    if (!visited.Contains(n))
                        stack.Push(n);
                }
            }              
        }
        public void traverseBreathFirst(string root)
        {
            if (!nodes.ContainsKey(root))
                return;
            var node = nodes[root];

            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();

            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (visited.Contains(current))
                    continue;

                Console.WriteLine(current.lable);
                visited.Add(current);
                foreach (var n in adjacencyList[current])
                {
                    if (!visited.Contains(n))
                        queue.Enqueue(n);
                }
            }
        }
        public List<string> topologicalSort()
        {
            var stack = new Stack<Node>();
            var visited = new HashSet<Node>();
            foreach (var node in nodes.Values)
                topologicalSort(node, visited, stack);

            var sorted = new List<string>();
            while (stack.Count > 0)
                sorted.Add(stack.Pop().lable);

            return sorted;
        }
        private void topologicalSort(Node node, HashSet<Node> visited,
            Stack<Node> stack)
        {
            if (visited.Contains(node))
                return;

            visited.Add(node);

            foreach (var n in adjacencyList[node])
                topologicalSort(n, visited, stack);

            stack.Push(node);
        }
        public bool hasCycle()
        {
            var all = new HashSet<Node>();
            foreach (var node in nodes)
                all.Add(node.Value);

            var visiting = new HashSet<Node>();
            var visited = new HashSet<Node>();

            while (all.Count > 0)
            {
                var current = all.First();
                if(hasCycle(current, all, visiting, visited))
                    return true;
            }

            return false;
        }
        private bool hasCycle(Node node, HashSet<Node> all, 
            HashSet<Node> visiting,HashSet<Node> visited)
        {
            all.Remove(node);
            visiting.Add(node);                       

            foreach (var n in adjacencyList[node])
            {
                if (visited.Contains(node))
                    continue;

                if (visiting.Contains(node))
                    return true;

                if(hasCycle(n, all,visiting, visited))
                    return true; 
            }

            visiting.Remove(node);
            visited.Add(node);

            return false;
        }
    }
}

