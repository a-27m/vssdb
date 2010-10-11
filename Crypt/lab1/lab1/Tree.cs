using System.Collections.Generic;

namespace lab1
{
    public class Tree
    {
        public class Node
        {
            public char k;
            public float p;
            public List<Node> children;

            public Node()
            { 
                k = ' ';
                p = -1;
                children = new List<Node>();
            }

            public Node(char key, float value)
            {
                this.k = key;
                this.p = value;
                children = new List<Node>();
            }
        }

        Node root;

        public Tree()
        {
            root = new Node();
        }


    }
}
