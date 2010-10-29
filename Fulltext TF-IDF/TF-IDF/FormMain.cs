using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TF_IDF
{
    public partial class FormMain : Form
    {
        public List<Document> Docs;
            KeyValuePair<string, float>[] pairs;

        char[] WordSeparators = new char[] { ' '/*, '\t', '.', '?', '!' */};

        public FormMain()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pairs = ParseToPairs(textBox1.Text);

            //Docs = (List<Document>)
            Form1.Query(Docs, pairs);
            Docs.Sort(delegate(Document d1, Document d2) { return -Math.Sign(d1.rank - d2.rank); });
            dataGridView1.DataSource = Docs;
            dataGridView1.Refresh();
        }

        private KeyValuePair<string, float>[] ParseToPairs(string input)
        {
            KeyValuePair<string, float>[] result;
            string[] words = input.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);

            result = new KeyValuePair<string, float>[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                float weight;
                string word = words[i].ToLower();

                if (word.StartsWith("-"))
                {
                    weight = -1;
                    word = word.Substring(1);
                }
                else
                    weight = words.Length - i;

                result[i] = new KeyValuePair<string, float>(word, weight);
            }

            return result;
        }

        private void re_Click(object sender, EventArgs e)
        {
        }

        bool close_back;
        private void Back(object sender, EventArgs e)
        {
            Owner.Show();
            close_back = true;
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close_back)
                close_back = false;
            else
                Application.Exit();
        }

        int docPosition = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            docPosition = 0;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                richTextBox1.LoadFile(Docs[e.RowIndex].path, RichTextBoxStreamType.PlainText);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            docPosition += 1;

            if (pairs == null) return;

            int minPos = int.MaxValue;
            string nextWord = "";

            foreach (KeyValuePair<string, float> word in pairs)
            {
                if (word.Value <= 0) continue;
                int pos = richTextBox1.Find(word.Key, docPosition, RichTextBoxFinds.WholeWord);
                if (pos < minPos)
                {
                    minPos = pos;
                    nextWord = word.Key;
                }
            }

            docPosition = richTextBox1.Find(nextWord, docPosition, RichTextBoxFinds.WholeWord);
            //richTextBox1.ScrollToCaret();
        }
    }
}
