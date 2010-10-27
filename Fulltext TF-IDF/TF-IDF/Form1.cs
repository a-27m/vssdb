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
        Dictionary<string, uint> dictBase;
        Dictionary<string, uint> dictBoolCount;
        List<Dictionary<string, uint>> dictDocs;

        public Form1()
        {
            InitializeComponent();
            dictBase = new Dictionary<string, uint>();
            dictBoolCount = new Dictionary<string, uint>();
            dictDocs = new List<Dictionary<string, uint>>();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
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

            StreamReader finp = new StreamReader(textBox1.Text, Encoding.GetEncoding(1251));
            //StreamWriter fout = new StreamWriter(textBox2.Text, false, Encoding.GetEncoding(1251));

            char[] SentenceSepartors = new char[] { '.', '?', '!' };
            char[] WordSeparators = new char[] { ' ', '\t', '.', '?', '!' };
            Dictionary<string, uint> dictDoc = new Dictionary<string, uint>();

            while (!finp.EndOfStream)
            {
                string line = finp.ReadLine();
                Regex exp = new Regex("\\b\\w+\\b");
                foreach(Match match in exp.Matches(line))
                {
                    string word = match.Value;
                    word = word.ToLower();

                    uint N;
                    if (dictDoc.TryGetValue(word, out N))
                        dictDoc[word] = N + 1;
                    else
                        dictDoc.Add(word, 1);

                    //fout.WriteLine(SentNumber.ToString("D6") + "\t" + words[i]);
                }
            }

            // merge                      

            // update keyword apperances in documents
            foreach (KeyValuePair<string, uint> word in dictDoc)
            {
                dictBoolCount[word.Key] = dictBoolCount[word.Key] + 1;
            }


            dictDocs.Add(dictDoc);

            //Debug.Print(dictDoc.ToString());
            //var res = dictBase.OrderByDescending(p => p.Value);

            finp.Close();
            //fout.Close();

            label1.Text = "OK!";
        }

        object Query(KeyValuePair<string, uint>[] query)
        { 
            float[] r = new float[dictDocs.Count];
            int i = 0;

            foreach (Dictionary<string, uint> dictDoc in dictDocs)
            {
                foreach (KeyValuePair<string, uint> term in query)
                    r[i++] = dictDoc[term.Key] * term.Value;
            }

            return r;
        }
    }
}
