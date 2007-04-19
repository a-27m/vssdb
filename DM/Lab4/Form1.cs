using System;
using System.Drawing;
using System.Windows.Forms;
using automats;

namespace Lab4
{
    public partial class Form1 : Form
    {
        ExtendingPrefixIdenifierAutomat eta;

        public Form1()
        {
            InitializeComponent();

            eta = new ExtendingPrefixIdenifierAutomat();

            string[] reservedWords = new string[] { 
                "END",
                "FOR",
                "GOTO",
                "GOSUB", 
                "IF",
                "LET",
                "NEXT",
                "RETURN",
                "REM",
                "STEP",
                "TO" };

            foreach (string word in reservedWords)
                eta.Add(word);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            eta.Print(dataGridView1);

            this.Width = dataGridView1.GetPreferredSize(this.Size).Width + 45;
        }

        // add
        private void button1_Click(object sender, EventArgs e)
        {
            eta.Add(textBox1.Text);
            eta.Print(dataGridView1);
        }

        // find
        private void button2_Click(object sender, EventArgs e)
        {
            if (!eta.Find(textBox1.Text))
            {
                MessageBox.Show(this, "Слово не содержится в словаре", "Не найдено",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this,
                    "Выполнено сравнений: " + eta.LastSearchComparsionsCount.ToString(),
                    "Найдено",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // clear
        private void button3_Click(object sender, EventArgs e)
        {
            eta.Clear();
            eta.Print(dataGridView1);
        }
    }
}