using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class Trie
    {
        private class Node
        {
            public static int ALPHABET_SIZE = 26;
            public char value;
            public Dictionary<char, Node> children = new Dictionary<char, Node>();
            public bool isEndOfWord;
            public Node(char value)
            {
                this.value = value;
            }

            public bool hasChild(char ch)
            {
                return children.ContainsKey(ch);
            }

            public void addChild(char ch)
            {
                children.Add(ch, new Node(ch));
            }
            public Node getChild(char ch)
            {
                return children[ch];
            }
            public Node[] getAllChild()
            {
                return children.Values.ToArray<Node>();
            }
            public bool hasChildren()
            {
                return children.Count != 0;
            }
            public void removeChild(char ch)
            {
                children.Remove(ch);
            }
        }
        private Node root = new Node(' ');
        public void insert(string word)
        {
            var current = root;
            foreach (var ch in word)
            {
                if (!current.hasChild(ch))
                    current.addChild(ch);
                current = current.getChild(ch);
            }
            current.isEndOfWord = true;
        }
        public bool contains(string word)
        {
            if (word == null)
                throw new Exception("input is null");

            var current = root;
            foreach (var ch in word)
            {
                if (!current.hasChild(ch))
                    return false;
                current = current.getChild(ch);
            }
            if (current.isEndOfWord == true)
                return true;

            return false;
        }
        public bool containsRecursive(string word)
        {
            if (word == null)
                throw new Exception("input is null");
            return contains(word, root, 0);
        }
        private bool contains(string word, Node root, int index)
        {
            if (!root.hasChild(word[index]))
                return false;

            if (root.isEndOfWord && index == word.Length - 1)
                return true;

            index = word[index] - 'a';
            return contains(word, root.children[word[index]], word[index] - 'a');
        }
        public int countWords()
        {
            return countWords(root, 0);
        }
        private int countWords(Node root, int count)
        {
            //var count = 0;

            if (root.isEndOfWord)
                count++;

            foreach (var item in root.getAllChild())
                count = countWords(item, count);

            return count;
        }
        public string longestCommonPrefix()
        {
            var prefix = "";
            return longestCommonPrefix(root, prefix);
        }
        private string longestCommonPrefix(Node root, string prefix)
        {
            if (root.children.Count == 1)
                prefix += root.value;
            else
            {
                prefix += root.value;
                return prefix;
            }

            foreach (var item in root.getAllChild())
                prefix = longestCommonPrefix(item, prefix);

            return prefix;
        }
        public void traverse()
        {
            postTraverse(root);
        }
        private void traverse(Node root)
        {
            Console.WriteLine(root.value);
            foreach (var item in root.getAllChild())
                traverse(item);
        }
        private void postTraverse(Node root)
        {
            foreach (var item in root.getAllChild())
                postTraverse(item);
            Console.WriteLine(root.value);

        }
        public void remove(string word)
        {
            if (word == null)
                return;
            remove(root, word, 0);
        }
        private void remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.isEndOfWord = false;
                return;
            }
            var ch = word[index];
            if (!root.hasChild(ch))
                return;
            var child = root.getChild(ch);

            if (child == null)
                return;

            remove(child, word, index + 1);

            if (!child.hasChildren() && !child.isEndOfWord)
                root.removeChild(ch);

        }
        public List<string> findWords(string prefix)
        {
            if (prefix == null)
                return null;

            var words = new List<string>();
            var lastNode = firstLastNodeOf(prefix);
            findWords(lastNode, prefix, words);

            return words;
        }
        private void findWords(Node root, string prefix, List<string> words)
        {
            if (root.isEndOfWord)
                words.Add(prefix);

            foreach (var child in root.getAllChild())
                findWords(child, prefix + child.value, words);
        }
        private Node firstLastNodeOf(string prefix)
        {
            var current = root;
            foreach (var ch in prefix)
            {
                var child = current.getChild(ch);
                if (child == null)
                    return null;
                current = child;
            }
            return current;
        }
    }
}

