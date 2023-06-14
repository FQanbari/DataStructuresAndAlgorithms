namespace DataStructures
{
    public class StringTrie
    {
        public class Node
        {
            public static int ALPHABET_SIZE = 26;
            public char value;
            public Node[] children = new Node[ALPHABET_SIZE];
            public bool isEndOfWord;
            public Node(char value)
            {
                this.value = value;
            }
        }
        private Node root = new Node(' ');
        public void insert(string word)
        {
            var current = root;
            foreach (var ch in word)
            {
                var index = ch - 'a';
                if (current.children[index] == null)
                    current.children[index] = new Node(ch);
                current = current.children[index];
            }
            current.isEndOfWord = true;
        }
    }
}

