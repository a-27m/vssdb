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
        KeyValuePair<char, float>[] pairs;

        private void button1_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();

            tree = new Tree();
            Tree.Node[] leaves;

            BuildPairs();

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
                leaves[i].p = pairs[i].Value;// / (float)textBoxMsg.TextLength;
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

            double H = 0;

            for (int k = 0; k < pairs.Length; k++)
            {
                H -= pairs[k].Value * Math.Log(pairs[k].Value, 2);
            }

            double C = 0;

            for (int k = 0; k < pairs.Length; k++)
            {
                C += pairs[k].Value * dgv1[2, k].Value.ToString().Length;
            }

            double R = C - H;

            label2.Text = string.Format("H = {0}, C = {1}, R = {2}", H, C, R);
        }

        private void BuildPairs()
        {
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

            pairs = dict.ToArray();

            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new KeyValuePair<char, float>(pairs[i].Key, pairs[i].Value / (float)textBoxMsg.TextLength);
            }
        }

        private void PrintCodes()
        {
            throw new NotImplementedException();
        }

        object[] GatherCodes(Tree.Node root)
        {
            indexDGV = 0;
            Gardener(root.children[0], "0");
            Gardener(root.children[1], "1");

            return null;
        }
        int indexDGV = 0;
        void Gardener(Tree.Node node, string prefix)
        {
            if (node.children.Count > 0)
            {
                Gardener(node.children[0], prefix + "0");
                Gardener(node.children[1], prefix + "1");
            }
            else
            {
                // its leaf
                dgv1.Rows.Add();
                dgv1[0, indexDGV].Value = node.k;
                dgv1[1, indexDGV].Value = node.p.ToString("F3");
                dgv1[2, indexDGV].Value = prefix;
                indexDGV++;
                //listBox1.Items.Add("Node: "+node.k + " --> " + prefix);
            }
        }

        Tree.Node MakeNode(Tree.Node n1, Tree.Node n2)
        {
            return new Tree.Node('#', n1.p + n2.p);
        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();

            BuildPairs();

            // less freaquent will be first ones
            Array.Sort(pairs, new Comparison<KeyValuePair<char, float>>(
                delegate(KeyValuePair<char, float> a, KeyValuePair<char, float> b)
                {
                    return a.Value.CompareTo(b.Value);
                }
                )
                );

            indexDGV = 0;
            int n = pairs.Length;
            float[] B = new float[n];

            for (int i = 0; i < n; i++)
            {
                B[i] = 0;
                for (int j = 0; j < i; j++)
                {
                    B[i] += pairs[j].Value;
                }
                B[i] += pairs[i].Value / 2.0f;

                int m = (int)Math.Ceiling(Math.Log(1f / pairs[i].Value))+1;

                string code = "";
                float b = B[i];
                for (int k = 0; k < m; k++)
                { 
                    b *= 2f;
                    int integer = (int)Math.Truncate(b);                    
                    code += integer.ToString();

                    b -= integer;
                }

                dgv1.Rows.Add();
                dgv1[0, indexDGV].Value = pairs[i].Key;
                dgv1[1, indexDGV].Value = pairs[i].Value.ToString("F3");
                dgv1[2, indexDGV].Value = code;
                indexDGV++;
            }

            

            double H = 0;

            for (int k = 0; k < pairs.Length; k++)
            {
                H -= pairs[k].Value * Math.Log(pairs[k].Value, 2);
            }

            double C = 0;

            for (int k = 0; k < pairs.Length; k++)
            {
                C += pairs[k].Value * dgv1[2, k].Value.ToString().Length;
            }

            double R = C - H;

            label2.Text = string.Format("H = {0}, C = {1}, R = {2}", H, C, R);
        }
    }
}
