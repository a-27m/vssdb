using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Tree tree;

        private void button1_Click(object sender, EventArgs e)
        {
            tree = new Tree();
            Tree.Node[] leaves;

            Dictionary<char, float> dict = new Dictionary<char, float>();

            for (int i = 0; i < textBoxMsg.Text.Length; i++)
            {
                char c = textBoxMsg.Text[i];
                if (dict.ContainsKey(c))
                {
                    dict[c] = dict[c] + 1;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            KeyValuePair<char, float>[] pairs = dict.ToArray();

            // less freaquent will be first ones
            Array.Sort(pairs, new Comparison<KeyValuePair<char, float>>(
                delegate(KeyValuePair<char, float> a, KeyValuePair<char, float> b)
                {
                    return a.Value.CompareTo(b.Value);
                }
                )
                );

            // create leaves, less freaquent goes first, again
            leaves = new Tree.Node[pairs.Length];
            for (int i = 0; i < pairs.Length; i++)
            {
                leaves[i] = new Tree.Node();
                leaves[i].k = pairs[i].Key;
                // TODO count total probability and let last leave's p to be = (1 - sum)
                leaves[i].p = pairs[i].Value / (float)textBoxMsg.TextLength;
            }

            int index = 0;

            while (index < pairs.Length - 1)
            {
                Tree.Node n = MakeNode(leaves[index], leaves[index + 1]);
                n.children.Add(leaves[index]);
                n.children.Add(leaves[index + 1]);

                leaves[index] = new Tree.Node();
                leaves[index + 1] = n;

                // TODO вынести безымянный метод отдельно чтоб не new
                Array.Sort(leaves, new Comparison<Tree.Node>(
                delegate(Tree.Node a, Tree.Node b)
                {
                    return a.p.CompareTo(b.p);
                }
                ));

                index++;
            }

            GatherCodes(leaves[pairs.Length - 1]);

            //PrintCodes();
        }

        object[] GatherCodes(Tree.Node root)
        {

            return null;
            // root.children[0] => 0
            // root.children[1] => 1
        }

        Tree.Node MakeNode(Tree.Node n1, Tree.Node n2)
        {
            return new Tree.Node('#', n1.p + n2.p);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (true)
            {
                double[] m = new double[1000];
            }
        }

    }
}
