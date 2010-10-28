using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
/*
Реализовать пространственно-векторную модель поиска документов. Для этого:

Документы индексировать ключевыми словами. Вес каждого слова определяется местом по убыванию важности ,например, по убыванию частот или по обращенному рангу. 
Запросы задаются набором ключевых слов по убыванию важности. 
Релевантность документа определяется скалярным произведением вектора запроса на вектор документа. 
Основные соотношения: 
1) инверсная частота термина: w(Ti)=lg(N/Ni), где Ti - термин, i=1,2,…M, M – число терминов в базе, N - число документов в базе, Ni - число документов с термином Ti в базе; 

2) вес термина Ti в документе Dj: W=Wij= w(Ti)* wj(Ti), где wj(Ti) – частота термина Ti в документе Dj; 

3) запрос формируется как вектор Q=(q1,q2, … ,qM), где qi– вес термина Ti в запросе; 

4) степень релевантности документа Dj запросу Q определяется cкалярным произведением: Rj(Q)=QW=Σ(qi*Wij) в порядке убывания. 

*/
namespace TF_IDF
{
    public partial class Form1 : Form
    {
        //Dictionary<string, float> dictBase;
        Dictionary<string, float> dictBoolCount;
        List<Document> dictDocs;

        public Form1()
        {
            InitializeComponent();
            //dictBase = new Dictionary<string, float>();
            dictBoolCount = new Dictionary<string, float>();
            //dictDocs = new List<Dictionary<string, float>>();
            dictDocs = new List<Document>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.txt", SearchOption.AllDirectories));
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Working...";
            Application.DoEvents();
            int minWordLength = int.Parse(textBoxCount.Text);

            char[] SentenceSepartors = new char[] { '.', '?', '!' };
            char[] WordSeparators = new char[] { ' ', '\t', '.', '?', '!' };

            StreamReader finp;
            //StreamWriter fout = new StreamWriter(textBox2.Text, false, Encoding.GetEncoding(1251));
            foreach (string filename in listBox1.Items)
            {
                finp = new StreamReader(filename, Encoding.GetEncoding(1251));
                Dictionary<string, float> dictDoc = new Dictionary<string, float>();
                int wordCount = 0;

                while (!finp.EndOfStream)
                {
                    string line = finp.ReadLine();
                    Regex exp = new Regex("\\b\\w+\\b");
                    foreach (Match match in exp.Matches(line))
                    {
                        wordCount++;

                        string word = match.Value;
                        word = word.ToLower();

                        float n;
                        if (dictDoc.TryGetValue(word, out n))
                            dictDoc[word] = n + 1;
                        else
                            dictDoc.Add(word, 1);

                        //fout.WriteLine(SentNumber.ToString("D6") + "\t" + words[i]);
                    }
                }

                // update keyword apperances in documents
                string[] terms = new string[dictDoc.Keys.Count];
                dictDoc.Keys.CopyTo(terms, 0);

                foreach (string term in terms)
                {
                    float n;

                    if (dictBoolCount.TryGetValue(term, out n))
                        dictBoolCount[term] = n + 1;
                    else
                        dictBoolCount.Add(term, 1);

                    dictDoc[term] = dictDoc[term] / wordCount;
                }

                dictDocs.Add(new Document(dictDoc, filename));

                //Debug.Print(dictDoc.ToString());
                //var res = dictBase.OrderByDescending(p => p.Value);

                finp.Close();
            }

            // pass all docs again to update Wij
            double N = dictDocs.Count; // number fo docs in base
            foreach(Document doc in dictDocs)
            {
                string[] terms = new string[doc.dict.Keys.Count];
                doc.dict.Keys.CopyTo(terms, 0);

                foreach (string term in terms)
                {
                    doc.dict[term] = (float)(doc.dict[term] * Math.Log10(N / dictBoolCount[term]));
                }
            }

            //fout.Close();
            label1.Text = "OK!";
            button4.Enabled = true;
        }

        public static object Query(IList<Document> docs, KeyValuePair<string, float>[] query)
        { 
            float rank;
            
            for(int i = 0; i < docs.Count; i++)
            //foreach (Document doc in docs)
            {
                rank = 0;
                foreach (KeyValuePair<string, float> queryTerm in query)
                    rank = docs[i].dict[queryTerm.Key] * queryTerm.Value;

                docs[i].SetRank(rank);
            }

            return docs;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            fm.Docs = dictDocs;
            this.Hide();
            fm.Owner = this;
            fm.Show();
        }
    }

    public struct Document
    {
        public Dictionary<string, float> dict;
        public string path;
        public float rank;

        public Document(Dictionary<string, float> dictionary, string filePath)
        {
            dict = dictionary;
            path = filePath;
            rank = -1;
        }

        public void SetRank(float Rank)
        {
            this.rank = Rank;
        }
    }

}
