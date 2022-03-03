using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 10, 5, 15, 6, 1, 8, 12, 18, 17 };
            var input2 = new int[] { 20, 10, 6, 14, 3, 8, 30, 24, 26 };
            var input3 = new int[] { 7,4, 9, 1, 6, 8, 10 };
            var tree = new Tree();
            foreach (var item in input2)
                tree.insert(item);

            var tree1 = new Tree();
            foreach (var item in input3)
                tree1.insert(item);

            var tree3 = new Tree();
            foreach (var item in input)
                tree3.insert(item);
            //var height = tree.height();
            //var min = tree.min();
            //var isEqual = tree.equals(tree1);
            //tree.swapRoot();
            //var isValid = tree.isBinarySearchTree();
            //var result = tree.find(20);
            //var list = tree.getNodesAtDistance(3);
            //foreach (var item in list)
            //    Console.WriteLine(item);
            //tree.traverseLevelOrder();
            //var size = tree3.max();
            //var list = tree.getAncestors(8);
            //var isSibling = tree.areSibling(6,14);
            var isthere = tree.contains(17);
         }

    }
    public class Tree
    {
        private class Node
        {
            public Node(int value)
            {
                this.value = value;
            }
            public int value;
            public Node leftChild;
            public Node rightChild;
        }
        private Node root;
        private int count;
        public void swapRoot()
        {
            var tmp = root.leftChild;
            root.leftChild = root.rightChild;
            root.rightChild = tmp;
        }
        public void insert(int value)
        {
            var node = new Node(value);
            if (root == null)
            {
                root = node;
                return;
            }
            var current = root;
            while (true)
            {
                
                if(current.value < value)
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = node;
                        break;
                    }
                    current = current.rightChild;
                }
                else
                {
                    if (current.leftChild == null) { 
                        current.leftChild = node;
                        break;
                    }
                    current = current.leftChild;
                }
                count++;
            }
            
        }
        public int size()
        {
            return size(root);
        }
        private int size(Node root)
        {
            if (root == null)
                return 0;
            return size(root.leftChild) + size(root.rightChild) + 1;
        }
        public int countLeaves()
        {
            return countLeaves(root);
        }
        private int countLeaves(Node root)
        {
            if (root == null)
                return 0;
            if (root.leftChild == null && root.rightChild == null)
                return 1;
            else
                return countLeaves(root.leftChild) +
                    countLeaves(root.rightChild);
        }
        public bool find(int value)
        {
            if (root == null)
                throw new Exception();

            var current = root;
            while (current != null)
            {
                if (current.value == value)
                    return true;

                if (current.value < value)
                    current = current.rightChild;
                else
                    current = current.leftChild;
            }
            return false;
        }
        private void traversePreOrder(Node root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.value);
            traversePreOrder(root.leftChild);
            traversePreOrder(root.rightChild);
        }
        public void traversePreOrder()
        {
            traversePreOrder(root);
        }
        private void traverseInOrder(Node root)
        {
            if (root == null)
                return;

            
            traverseInOrder(root.leftChild);
            Console.WriteLine(root.value);
            traverseInOrder(root.rightChild);
        }
        public void traverseInOrder()
        {
            traverseInOrder(root);
        }
        private void traversePostOrder(Node root)
        {
            if (root == null)
                return;


            traversePostOrder(root.leftChild);            
            traversePostOrder(root.rightChild);
            Console.WriteLine(root.value);
        }
        public void traversePostOrder()
        {
            traversePostOrder(root);
        }
        private int height(Node root)
        {
            if (root == null)
                return -1;

            if (isLeaf(root))
                return 0;
            return 1 + Math.Max(height(root.leftChild),height(root.rightChild));
        }
        public int height()
        {
            return height(root);
        }
        private int min(Node root)
        {
            if (isLeaf(root))
                return root.value;

            var left = min(root.leftChild);
            var right = min(root.rightChild);

            return Math.Min(Math.Min(left, right), root.value);
        }
        public int min()
        {
            if (root == null)
                throw new Exception();

            var current = root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.leftChild;
            }
            return last.value;
            //return min(root);
        }
        public int max()
        {
            if (root == null)
                throw new Exception();
            return max(root);
        }
        private int max(Node root)
        {
            if (root == null)
                return 0;

            var left = max(root.leftChild);
            var right = max(root.rightChild);

            return Math.Max(Math.Max(left, right), root.value);
        }
        private bool isLeaf(Node node)
        {
            return node.leftChild == null && node.rightChild == null;
        }
        public bool equals(Tree other)
        {
            if (other == null)
                return false;

            return equals(root, other.root);
        }
        private bool equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return first.value == second.value
                    && equals(first.leftChild, second.leftChild)
                    && equals(first.rightChild, second.rightChild);
            
            return false;
        }
        private bool isBinarySearchTree(Node root, int min,int max)
        {
            if (root == null)
                return true;

            if (root.value < min || root.value > max)
                return false;

            return isBinarySearchTree(root.leftChild,min,root.value - 1)
            && isBinarySearchTree(root.rightChild,root.value + 1, max);

        }
        public bool isBinarySearchTree()
        {
            return isBinarySearchTree(root,int.MinValue,int.MaxValue);
        }
        private void getNodesAtDistance(Node root,int distance,List<int> list)
        {
            if (root == null)
                return;
            if (distance == 0)
            {
                list.Add(root.value);
                return;
            }
            getNodesAtDistance(root.leftChild, distance - 1,list);
            getNodesAtDistance(root.rightChild, distance - 1,list);
        }
        public List<int> getNodesAtDistance(int distance)
        {
            var list = new List<int>();
            getNodesAtDistance(root, distance,list);
            return list;
        }
        public void traverseLevelOrder()
        {
            for (int i = 0; i <= height(); i++)
            {
                foreach (var item in getNodesAtDistance(i))
                    Console.WriteLine(item);
            }
        }
        private bool getAncestors(Node root,int target, List<int> list)
        {
            if (root == null)
                return false;

            if (root.value == target)
                return true;

            if (getAncestors(root.leftChild, target, list) ||
            getAncestors(root.rightChild, target, list))
            { list.Add(root.value);
                return true;
            }

            return false;
        }
        public List<int> getAncestors(int target)
        {
            var list = new List<int>();
            getAncestors(root, target,list);
            return list;
        }
        private bool areSibling(Node root,int first,int second)
        {
            if (root == null)
                return false;

            // Compare the two given nodes with
            // the childrens of current node
            if (root.leftChild != null && root.rightChild != null)
            {
                int left = root.leftChild.value;
                int right = root.rightChild.value;

                if (left == first && right == second)
                    return true;
                else if (left == second && right == first)
                    return true;
            }

            // Check for left subtree
            if (root.leftChild != null)
                if (areSibling(root.leftChild, first,second))
                    return true;

            // Check for right subtree
            if (root.rightChild != null)
                if (areSibling(root.rightChild,first,second))
                    return true;

            return false;
        }
        public bool areSibling(int first,int second)
        {
            return areSibling(root, first, second);
        }
        private bool contains(Node root,int target)
        {
            if (root == null)
                return false;

            if (root.value == target)
                return true;

            if (contains(root.leftChild, target) || contains(root.rightChild, target))
                return true;

            return false;
        }

        public bool contains(int target)
        {
            return contains(root, target);
        }
    }
}

