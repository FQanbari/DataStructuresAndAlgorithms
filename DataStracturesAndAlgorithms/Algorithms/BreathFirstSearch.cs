using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms;

partial class BreathFirstSearch
{
    public static Dictionary<string, string[]> _graph = new();
    public static Dictionary<string, string[]> GetData()
    {
        _graph.Add("you", new string[] { "alice", "bob", "claire" });
        _graph.Add("bob", new string[] { "anuj", "peggy" });
        _graph.Add("alice", new string[] { "peggy" });
        _graph.Add("claire", new string[] { "thom", "jonn" });
        _graph.Add("anuj", new string[] { });
        _graph.Add("peggy", new string[] { });
        _graph.Add("thom", new string[] { });
        _graph.Add("jonny", new string[] { });

        return _graph;
    }
    public static bool Search(string name)
    {
        var searched = new Dictionary<string, bool>();
        var graph = GetData();
        var searchQueue = new Queue<string[]>();
        searchQueue.Enqueue(graph["you"]);
        while (searchQueue.Count > 0)
        {
            foreach (var person in searchQueue.Peek())
            {
                if (!searched.ContainsKey(person.ToString()))
                {
                    if (personIsSeller(person.ToString()))
                    {
                        Console.WriteLine($"{person.ToString()} is a mango seller!");
                        return true;
                    }
                    else
                    {
                        searched[person.ToString()] = true;
                        searchQueue.Enqueue(graph[person.ToString()]);
                    }
                }
            }
            searchQueue.Dequeue();
        }
        return false;
    }
    private static bool personIsSeller(string name)
    {        
        return name.EndsWith('m');
    }
}
