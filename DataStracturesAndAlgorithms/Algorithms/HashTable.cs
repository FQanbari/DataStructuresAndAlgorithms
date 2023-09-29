using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms;

public class HashTable
{
    public static Dictionary<string, bool> _voted = new Dictionary<string, bool>();
    public static void CheckVote(string name)
    {
        if (_voted.ContainsKey(name)) 
        {
            Console.WriteLine($"Kick {name} out");
            return;
        };

        _voted.Add(name, true);
        Console.WriteLine($"let {name} vote!");
    }
}
