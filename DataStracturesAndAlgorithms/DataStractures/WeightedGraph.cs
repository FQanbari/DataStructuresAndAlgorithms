//using Lucene.Net.Util;
using DotNetty.Common.Utilities;
//using NetTopologySuite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class WeightedGraph
    {
        private class Node
        {
            public string lable;
            private List<Edge> edges = new List<Edge>();
            public Node(string lable)
            {
                this.lable = lable;
            }
            public void addEdge(Node to, int weight)
            {
                edges.Add(new Edge(this, to, weight));
            }
            public List<Edge> getEdges()
            {
                return edges;
            }
        }
        private class Edge
        {
            public Node from;
            public Node to;
            public int weight;
            public Edge(Node from, Node to, int weight)
            {
                this.from = from;
                this.to = to;
                this.weight = weight;
            }
        }
        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        public void addNode(string lable)
        {
            if (!nodes.ContainsKey(lable))
                nodes.Add(lable, new Node(lable));
        }
        public void addEdge(string from, string to, int weight)
        {
            var fromNode = nodes[from];
            var toNode = nodes[to];
            if (fromNode == null || toNode == null)
                throw new Exception("not valid node");


            fromNode.addEdge(toNode, weight);
            toNode.addEdge(fromNode, weight);
        }
        public void print()
        {
            foreach (var node in nodes.Values)
            {
                var edges = node.getEdges();
                if (edges.Count > 0)
                {
                    Console.Write(node.lable + " is connected to ");
                    foreach (var v in edges)
                        Console.Write(v.from.lable + "->" + v.to.lable + " ");
                    Console.WriteLine();
                }

            }
        }
        private class NodeEntry
        {
            public Node node;
            public int priority;
            public NodeEntry(Node node, int priority)
            {
                this.node = node;
                this.priority = priority;
            }
        }
        public int getShortestDistance(string from, string to)
        {
            var fromNode = nodes[from];
            var distances = new Dictionary<Node, int>();
            var previousNodes = new Dictionary<Node, Node>();
            foreach (var node in nodes.Values)
                distances.Add(node, int.MaxValue);
            distances[fromNode] = 0;

            var visited = new HashSet<Node>();

            var queue = new PriorityQueue<NodeEntry>(
                Comparer<NodeEntry>.Create((a, b) => a.priority.CompareTo(b.priority)));
            //Comparer<NodeEntry>.Create(en => en.priority,)
            queue.Enqueue(new NodeEntry(fromNode, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue().node;
                visited.Add(current);

                foreach (var edge in current.getEdges())
                {
                    if (visited.Contains(edge.to))
                        continue;

                    var newDistance = distances[current] + edge.weight;
                    if (newDistance < distances[edge.to])
                    {
                        distances[edge.to] = newDistance;
                        queue.Enqueue(new NodeEntry(edge.to, newDistance));
                    }
                }
            }
            return distances[nodes[to]];
        }
        public class Path
        {
            private List<string> nodes = new List<string>();
            public void add(string node)
            {
                nodes.Add(node);
            }
            public List<string> get()
            {
                return nodes;
            }
        }
        public Path getShortestPath(string from, string to)
        {
            if (!nodes.ContainsKey(from) || !nodes.ContainsKey(to))
                throw new Exception("input is not valid");

            var fromNode = nodes[from];
            var toNode = nodes[to];

            var distances = new Dictionary<Node, int>();
            var previousNodes = new Dictionary<Node, Node>();
            foreach (var node in nodes.Values)
                distances.Add(node, int.MaxValue);
            distances[fromNode] = 0;

            var previousNode = new Dictionary<Node, Node>();
            var visited = new HashSet<Node>();

            var queue = new PriorityQueue<NodeEntry>(
                Comparer<NodeEntry>.Create((a, b) => a.priority.CompareTo(b.priority)));
            //Comparer<NodeEntry>.Create(en => en.priority,)
            queue.Enqueue(new NodeEntry(fromNode, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue().node;
                visited.Add(current);

                foreach (var edge in current.getEdges())
                {
                    if (visited.Contains(edge.to))
                        continue;

                    var newDistance = distances[current] + edge.weight;
                    if (newDistance < distances[edge.to])
                    {
                        distances[edge.to] = newDistance;
                        previousNode[edge.to] = current;
                        queue.Enqueue(new NodeEntry(edge.to, newDistance));
                    }
                }
            }

            return buildPath(toNode, previousNode);
        }
        private Path buildPath(Node toNode, Dictionary<Node, Node> previousNode)
        {
            var stack = new Stack<Node>();
            stack.Push(toNode);

            var previous = previousNode[toNode];
            while (previous != null)
            {
                stack.Push(previous);
                if (!previousNode.ContainsKey(previous)) break;
                previous = previousNode[previous];

            }

            var path = new Path();
            while (stack.Count > 0)
                path.add(stack.Pop().lable);

            return path;
        }
        public bool hasCycle()
        {
            var visited = new HashSet<Node>();

            foreach (var node in nodes.Values)
            {
                if (!visited.Contains(node) &&
                    hasCycle(node, null, visited))
                    return true;
            }

            return false;
        }
        private bool hasCycle(Node node, Node parent, HashSet<Node> visited)
        {
            visited.Add(node);
            foreach (var edge in node.getEdges())
            {
                if (edge.to == parent)
                    continue;

                if (visited.Contains(edge.to) ||
                    hasCycle(edge.to, node, visited))
                    return true;
            }

            return false;
        }
        public WeightedGraph getMinimumSpanningTree()
        {
            var tree = new WeightedGraph();

            if (nodes.Count == 0)
                return tree;

            var edges = new PriorityQueue<Edge>(
                Comparer<Edge>.Create((a, b) => a.weight.CompareTo(b.weight)));

            var startNode = nodes.Values.First();
            foreach (var item in startNode.getEdges())
                edges.Enqueue(item);

            tree.addNode(startNode.lable);

            if (edges.Count == 0)
                return tree;

            while (tree.nodes.Count < nodes.Count)
            {
                var minEdge = edges.Dequeue();
                if (minEdge == null)
                    return tree;
                var nextNode = minEdge.to;

                if (tree.containsNode(nextNode.lable))
                    continue;

                tree.addNode(nextNode.lable);
                tree.addEdge(minEdge.from.lable, nextNode.lable, minEdge.weight);

                foreach (var edge in nextNode.getEdges())
                    if (!tree.containsNode(edge.to.lable))
                        edges.Enqueue(edge);
            }

            return tree;
        }
        public bool containsNode(string lable)
        {
            return nodes.ContainsKey(lable);
        }
    }

}

