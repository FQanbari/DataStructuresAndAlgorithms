using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms;

public class Dijkstra
{
    private static Dictionary<string, Dictionary<string, int>> _graph = new();
    private static Dictionary<string, int> _costs = new();
    private static Dictionary<string, string> _parents = new();
    private static Dictionary<string, bool> _processed = new();
    public static void SetData()
    {
        _graph["start"] = new();
        _graph["start"]["a"] = 6;
        _graph["start"]["b"] = 6;
        _graph["a"] = new();
        _graph["a"]["fin"] = 1;
        _graph["b"] = new();
        _graph["b"]["a"] = 3;
        _graph["b"]["fin"] = 5;
        _graph["fin"] = new();

        _costs["a"] = 6;
        _costs["b"] = 2;
        _costs["fin"] = int.MaxValue;

        _parents["a"] = "start";
        _parents["b"] = "start";
        _parents["fin"] = string.Empty;
    }
    public static void Find(string name)
    {
        SetData();
        var node = findLowestCostNode(_costs);

        while (!string.IsNullOrWhiteSpace(node))
        {
            var cost = _costs[node];
            var neighbors = _graph[node];
            foreach (var n in neighbors.Keys)
            {
                var newCost = cost + neighbors[n];
                if (_costs[n] > newCost)
                {
                    _costs[n] = newCost;
                    _parents[n] = node;
                }
            }
            _processed[node] = true;
            node = findLowestCostNode(_costs);
        }

        Console.WriteLine($"lowest cost: {_costs["fin"]}");
    }
    private static string findLowestCostNode(Dictionary<string, int> costs)
    {
        var lowestCost = int.MaxValue;
        var lowestCostNode = string.Empty;

        foreach (var node in costs.Keys)
        {
            var cost = costs[node];
            if (cost < lowestCost && !_processed.ContainsKey(node))
            {
                lowestCost = cost;
                lowestCostNode = node;
            }
        }

        return lowestCostNode;
    }
}
