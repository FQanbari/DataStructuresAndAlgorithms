using System;
using System.Collections;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            //graph.addNode("A");
            //graph.addNode("B");
            //graph.addNode("C");
            //graph.addNode("D");
            //graph.addNode("E");

            //graph.addEdge("A", "B");
            //graph.addEdge("A", "E");

            //graph.addEdge("C", "A");
            //graph.addEdge("C", "B");
            //graph.addEdge("C", "D");

            //graph.addEdge("B", "E");

            //graph.addEdge("D", "E");

            //graph.removeNode("D");
            //graph.removeEdge("C", "B");
            //graph.addNode("X");
            //graph.addNode("B");
            //graph.addNode("A");
            //graph.addNode("P");

            //graph.addEdge("X", "A");
            //graph.addEdge("X", "B");
            //graph.addEdge("A", "P");
            //graph.addEdge("B", "P");
            graph.addNode("A");
            graph.addNode("B");
            graph.addNode("C");

            graph.addEdge("A", "B");
            graph.addEdge("B", "C");
            graph.addEdge("C", "A");
            graph.print();

            Console.WriteLine("**************");
            Console.WriteLine("has Cycle: "+graph.hasCycle());
        }
    }
}

