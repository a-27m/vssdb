using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            eta = new ExtendingTerminalAutomat();
        }

        ExtendingTerminalAutomat eta;

        private void Form1_Load(object sender, EventArgs e)
        {
            eta.Add("оса");
            eta.Add("бок");
            eta.Add("бока");
            eta.Add("бак");
            eta.Add("око");

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