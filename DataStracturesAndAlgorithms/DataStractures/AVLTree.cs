using System;

namespace DataStructures
{
    public class AVLTree
    {
        private class AVLNode
        {
            public AVLNode(int value)
            {
                this.value = value;
            }
            public int value;
            public int height;
            public AVLNode left;
            public AVLNode right;
        }
        private AVLNode root;
        private AVLNode insert(AVLNode root, int value)
        {
            if (root == null)
            {
                root = new AVLNode(value);
                return root;
            }
            if (root.value > value)
                root.left = insert(root.left, value);
            else
                root.right = insert(root.right, value);

            setHeight(root);

            return balance(root);
        }
        private AVLNode balance(AVLNode root)
        {
            if (isLeftHeavy(root))
            {
                if (balanceFactor(root.right) < 0)
                    root.left = leftRotate(root.right);
                return rightRotate(root);
            }
            else if (isRightHeavy(root))
            {
                if (balanceFactor(root.right) > 0)
                    root.right = rightRotate(root.right);
                return leftRotate(root);                
            }

            return root;
        }
        private AVLNode leftRotate(AVLNode root)
        {
            var newRoot = root.right;
            root.right = newRoot.left;
            newRoot.left = root;

            setHeight(root);
            setHeight(newRoot);
            return newRoot;
        }
        private AVLNode rightRotate(AVLNode root)
        {
            var newRoot = root.left;
            root.left = newRoot.right;
            newRoot.right = root;

            setHeight(root);
            setHeight(newRoot);
            return newRoot;
        }
        private void setHeight(AVLNode node)
        {
            node.height = height(node);
        }
        private int height(AVLNode root)
        {
            if (root == null)
                return -1;

            if (isLeaf(root))
                return 0;
            return 1 + Math.Max(height(root.left), height(root.right));
        }
        public void insert(int value)
        {
            root = insert(root, value);
        }
        private bool isLeaf(AVLNode node)
        {
            return node.left == null && node.right == null;
        }
        private bool isLeftHeavy(AVLNode node)
        {
            return balanceFactor(node) > 1;
        }
        private bool isRightHeavy(AVLNode node)
        {
            return balanceFactor(node) < -1;
        }
        private int balanceFactor(AVLNode node)
        {
            return node == null ? 0 : height(node.left) - height(node.right);

        }
        private bool isBalance(AVLNode root)
        {
            if (root == null)
                return true;

            if (Math.Abs(height(root.left) - height(root.right)) <= 1 && isBalance(root.left) && isBalance(root.right))
                return true;

            return false;
        }
        public bool isBalance()
        {
            return isBalance(root);
        }
        private int size(AVLNode root, int level)
        {
            if (root == null)
                return 0;

            return ((int)Math.Pow(2, level) + size(root.left, level++));
        }
        private bool isPerfect(AVLNode root)
        {
            if (root == null)
                return true;

            if ((size(root.left, 0) == size(root.right, 0)) && isPerfect(root.left) && isPerfect(root.right))
                return true;

            return false;
        }

        public bool isPerfect()
        {
            return isPerfect(root);
        }
    }
}

