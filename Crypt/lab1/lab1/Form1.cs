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

            frq_dict = new Dictionary<char, float>();
        }

        Dictionary<Char, float> frq_dict;
        int sort_direction = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            frq_dict.Clear();

            textBoxMsg.Enabled = false;

            for (int i = 0; i < textBoxMsg.TextLength; i++)
            {
                char key = textBoxMsg.Text[i];

                if (!frq_dict.ContainsKey(key))
                    frq_dict.Add(key, 1); // the first occurance
                else
                    frq_dict[key] = frq_dict[key] + 1;
            }

            textBoxMsg.Enabled = true;

            List<KeyValuePair<char, float>> l = frq_dict.ToList();
            l.Sort(
                new Comparison<KeyValuePair<char, float>>(
                    delegate(KeyValuePair<char, float> kv, KeyValuePair<char, float> kv2)
                    {
                        return (int)Math.Sign( sort_direction * (kv.Value - kv2.Value)); //kv.Key.CompareTo(kv2.Key);
                    }
                ));
            listBox1.DataSource = l;

            float txtLength = (float)textBoxMsg.TextLength; 
            KeyValuePair<char, float>[] kvList = frq_dict.ToArray();
            for (int i = 0; i < kvList.Length; i++)
            {
                kvList[i] = new KeyValuePair<char,float>(kvList[i].Key, kvList[i].Value / txtLength);
            }


        }
    }

    class Node
    {
        Node parent;

    }
}
