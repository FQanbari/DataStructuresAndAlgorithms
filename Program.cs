using System.Collections;

namespace DataStructures
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 10, 5, 15, 6, 1, 8, 12, 18, 17 };
            var input2 = new int[] { 20, 10, 6, 14, 3, 8, 30, 24, 26 };
            var input3 = new int[] { 7, 4, 9, 1, 6, 8, 10 };
            var input4 = new int[] { 10, 30, 20 };
            var tree = new AVLTree();
            foreach (var item in input3)
                tree.insert(item);
            var isPerfect = tree.isPerfect();
            var isBalance = tree.isBalance();
        }
    }
}

