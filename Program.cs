//using Lucene.Net.Util;
using java.util;
//using NetTopologySuite.Utilities;
using System;
using System.Collections;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var graph = new WeightedGraph();
            graph.addNode("A");
            graph.addNode("B");
            graph.addNode("C");
            graph.addNode("D");
            graph.addNode("E");

            //graph.addEdge("A", "B", 0);
            //graph.addEdge("B", "C", 0);
            //graph.addEdge("C", "A", 0);
            //Console.WriteLine("has cycle: " + graph.hasCycle());

            graph.addEdge("A", "B", 3);
            graph.addEdge("B", "D", 4);
            graph.addEdge("C", "D", 5);
            graph.addEdge("A", "C", 1);
            graph.addEdge("B", "C", 2);
            var tree = graph.getMinimumSpanningTree();
            tree.print();
            graph.print();
            var shortDistance = graph.getShortestDistance("A", "C");
            Console.WriteLine("A->C: " + shortDistance);
            Console.WriteLine("============================");
            foreach (var item in graph.getShortestPath("A", "R").get())
                Console.WriteLine(item);
            Console.ReadLine();

        }
    }

}

