using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Tree tree;

        Tree.Node MakeNode(Tree.Node n1, Tree.Node n2)
        {
            return new Tree.Node('#', n1.p + n2.p);
        }

        KeyValuePair<char, float>[] pairs;
        int indexDGV = 0;
        float CurrentCost = 0;

        private void UpdateHR(double C)
        {
            double H = 0;

            for (int k = 0; k < pairs.Length; k++)
            {
                H -= pairs[k].Value * Math.Log(pairs[k].Value, 2);
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

        #region №1 - huffman
        private void buttonHuffman_Click(object sender, EventArgs e)
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

            // create leaves, a less freaquent leaf goes first
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

            UpdateHR(CurrentCost);
        }

        object[] GatherCodes(Tree.Node root)
        {
            indexDGV = 0;
            CurrentCost = 0f;
            Gardener(root.children[0], "0");
            Gardener(root.children[1], "1");

            return null;
        }
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
                CurrentCost += node.p * prefix.Length;
                //listBox1.Items.Add("Node: "+node.k + " --> " + prefix);
            }
        }
        #endregion
     
        private void buttonAlphabCodes_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();

            BuildPairs();

            // alphabetically
            Array.Sort(pairs, new Comparison<KeyValuePair<char, float>>(
                delegate(KeyValuePair<char, float> a, KeyValuePair<char, float> b)
                {
                    return a.Key.CompareTo(b.Key);
                }
                )
                );

            indexDGV = 0;
            CurrentCost = 0f;

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
                CurrentCost += pairs[i].Value * code.Length;
            }


            UpdateHR(CurrentCost);
        }

        private void buttonOptimal_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();
            indexDGV = 0;
            CurrentCost = 0f;

            BuildPairs();

            // alphabetically
            Array.Sort(pairs, new Comparison<KeyValuePair<char, float>>(
                delegate(KeyValuePair<char, float> a, KeyValuePair<char, float> b)
                {
                    return a.Key.CompareTo(b.Key);
                }
                )
                );

            RODic roDic = new RODic();

            int n = pairs.Length;

            // (A,A) (B,B) ...
            for (int i = 0; i < n; i++)
            {
                KeyValuePair<char, string>[] set = new KeyValuePair<char, string>[1];
                set[0] = new KeyValuePair<char, string>(pairs[i].Key, "");
                roDic.Add(set, 0f);
            }

            // (A,B) (B,C) ...
            for (int i = 0; i < n-1; i++)
            {
                KeyValuePair<char, string>[] set = new KeyValuePair<char, string>[2];
                set[0] = new KeyValuePair<char, string>(pairs[i].Key, "0");
                set[1] = new KeyValuePair<char, string>(pairs[i+1].Key, "1");
                roDic.Add(set, pairs[i].Value + pairs[i+1].Value);
            }

            for (int k = 3; k <= n; k++)
            {
                for (int i = 0; i <= n - k; i++)
                {
                    int j = i + k - 1;
                    {
                        //DebugPrint("k:{0} ({1},{2})", k, i, j);
                        string debugString = "";

                        int minMid = i;
                        float minCost = float.MaxValue;

                        RODic.LetterItem li1 = null, li2 = null;

                        #region break L(i...j) into two (L1(i,mid) , L2(mid+1,j))
                        for (int mid = i; mid < j; mid++)
                        {
                            float c = 0;
                            debugString = "(";

                            KeyValuePair<char, string>[] set1 = new KeyValuePair<char, string>[mid - i + 1];
                            KeyValuePair<char, string>[] set2 = new KeyValuePair<char, string>[j - mid];

                            for (int t = i; t <= mid; t++)
                            {
                                set1[t-i] = new KeyValuePair<char, string>(pairs[t].Key, "");
                                c += pairs[t].Value;

                                debugString += pairs[t].Key;
                            }
                            debugString += "), (";
                            for (int t = mid+1; t <= j; t++)
                            {
                                set2[t-mid-1] = new KeyValuePair<char, string>(pairs[t].Key, "");
                                c += pairs[t].Value;

                                debugString += pairs[t].Key;

                            }
                            debugString += ")";

                            c += roDic.Read(set1) + roDic.Read(set2);

                            DebugPrint("{0}, Cч = {1}", debugString, c);

                            if (c < minCost)
                            {
                                minCost = c;
                                minMid = mid;

                                li1 = roDic.Search(set1);
                                li2 = roDic.Search(set2);
                            }
                        }
                        #endregion

                        KeyValuePair<char, string>[] setNew = new KeyValuePair<char, string>[k];

                        debugString = "Codes: (";
                        for (int t = i; t <= j; t++)
                        {
                            string code;
                            if (t <= minMid)
                                code = "0" + li1.ltrs[t - i].Value;
                            else
                                code = "1" + li2.ltrs[t - minMid-1].Value;

                            setNew[t - i] = new KeyValuePair<char, string>(pairs[t].Key, code);

                            debugString += pairs[t].Key + "~" + code + " ";
                        }
                        debugString += ")";

                        DebugPrint("Minimal Cч = {0}; {1}" + Environment.NewLine, minCost, debugString);
                        roDic.Add(setNew, minCost);
                    }
                }
            }

            // now dictionary contains partition consisting from all
            // symbols from input alphabet with their codes.

            // Lets print them out and evaluate their costs.
            RODic.LetterItem li = roDic.GetLastEntry();

            for (int i = 0; i < li.ltrs.Length; i++)
            {
                dgv1.Rows.Add();
                dgv1[0, indexDGV].Value = li.ltrs[i].Key;
                dgv1[1, indexDGV].Value = pairs[i].Value.ToString("F3");//li.ltrs[i].Value.ToString("F3");
                dgv1[2, indexDGV].Value = li.ltrs[i].Value;
                indexDGV++;
                //(*) CurrentCost += pairs[i].Value * li.ltrs[i].Value.Length;
            }

            //(*) UpdateHR(C: CurrentCost);
            UpdateHR(C: li.cost);

            //DebugPrint("cost_partial:{0}", li.cost);
        }

        private void DebugPrint(string format, params object[] p)
        {
            textBoxDebug.Text += string.Format(format, p) + Environment.NewLine;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDebug.Visible = checkBox1.Checked;
        }
    }
}
