using System;
using System.Collections;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "boy", "book", "border", "cat", "dog", "doctor", "fine", "finest", "figure", "pick", "pickle", "picture" };
            string[] words3 = { "cat", "doctor", "fine", "finest", "figure", "pick", "pickle", "picture" };
            string[] words2 = { "boy", "book" };
            string[] words4 = { "fine", "finest", "figure" };
            string[] words5 = { "pick", "pickle", "picture" };
            var trie = new Trie();

            foreach (var w in words5)
                trie.insert(w);

            Console.WriteLine("prefix: " + trie.longestCommonPrefix());
            Console.WriteLine(trie.contains("book"));
            Console.WriteLine("count: " + trie.countWords());
        }
    }
}

