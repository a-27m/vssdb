using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace automats
{
    public partial class MMAutomatChlid : Form, IPlayableMDIChild
    {
        const string delims = " \t\n";
        //const string BottomSign = "¶";
        const string BottomSign = "*";
        const string EndSign = "$";

        internal MMAutomat machine;

        private string[] strs;
        protected int pos;

        protected MMAutomatChlid()
        {
            InitializeComponent();
            progressBar.Visible = false;
        }

        public MMAutomatChlid(MMAutomat a)
        {
            if (a == null)
                throw new AutomatException("Automat is a 'null'!");
            InitializeComponent();
            machine = a;
            progressBar.Minimum = 0;
            progressBar.Step = 1;
            txtIn_TextChanged(null, new EventArgs());
            if (machine != null)
            {
                //machine.PrintAutomat(grid);
                PrintAutomat();
            }
        }

        private void PrintAutomat()
        {
            grid.Rows.Clear();
            grid.Columns.Clear();
            for (int i = 0; i < machine.A.Length; i++)
                grid.Columns.Add("column" + i.ToString(), machine.A[i].ToString());

            grid.Rows.Add((machine.M.Length - 5) * machine.S.Length);

            for (int i = 0; i < machine.S.Length; i++)
            {
                for (int j = 0; j < machine.M.Length - 5 - 1; j++)
                {
                    grid.Rows[j].HeaderCell.Value = "(" + machine.S[i].ToString() + ") " + machine.M[j].ToString();
                    grid.Rows[j].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            for (int i = 0; i < machine.S.Length; i++)
            {
                grid.Rows[machine.M.Length - 6].HeaderCell.Value =
                    "(" + machine.S[i].ToString() + ") " + machine.M[machine.M.Length - 1].ToString();
                grid.Rows[machine.M.Length - 6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            for (int k = 0; k < machine.S.Length; k++)
            {
                for (int i = 0; i < machine.M.Length - 5 - 1; i++)
                    for (int j = 0; j < machine.A.Length; j++)
                    {
                        grid.Rows[i].Cells[j].Value = "#" + machine.ManDevice[k][i, j].ToString();
                        // grid.Rows[i- 6].Cells[j].Value = "#" + machine.ManDevice[k][i-1, j].ToString();
                    }
            }

            for (int j = 0; j < machine.A.Length; j++)
            {
                grid.Rows[machine.M.Length - 6].Cells[j].Value = "#" + machine.ManDevice[0][machine.M.Length - 1, j].ToString();
            }

            grid.AutoResizeColumns();
            grid.AutoResizeRows();

            listBoxStack.Items.Clear();
            listBoxStack.Items.Add("Stack:");
            foreach (int el in machine.GetStackAsArray())
            {
                listBoxStack.Items.Add(machine.M[el]);
            }
        }

        protected object[] ss;
        protected object[] oo;
        protected object[] stst;

        private void MDIChildTemplate_FormClosing(object sender, FormClosingEventArgs e)
        {
            //machine.Step -= machine_OnStep;
        }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string[] newS;
        }

        private void txtIn_TextChanged(object sender, EventArgs e)
        {
            strs = txtIn.Text.Split(delims.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            progressBar.Maximum = strs.Length;
        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // find out what's changed in automat
            // change automat, and say to parent we did it
            //throw new Exception("Editing isn't implemented yet!");
        }

        bool machine_Step(int inIndex, int newStateIndex, int outSymbolIndex, int[] stackState, int[] transIndex)
        {
            progressBar.PerformStep();
            if (inIndex != -1)
            // highlite new cell in grid
            {
                if (outSymbolIndex != -1)
                    txtOut.Text += machine.Z[outSymbolIndex].ToString() + " ";
                txtTrans.Text = machine.TranslationString;
                if (stackState[0] < machine.M.Length - 5)
                    grid.Rows[(newStateIndex) * machine.M.Length + stackState[0]].Cells[inIndex].Selected = true;
                else
                    grid.Rows[(newStateIndex) * machine.M.Length + stackState[0]-6].Cells[inIndex].Selected = true;

                //while(paused)
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);

                grid.Rows[newStateIndex].Cells[inIndex].Selected = false;

                listBoxStack.Items.Clear();
                listBoxStack.Items.Add("Stack:");
                foreach (int el in stackState)
                {
                    listBoxStack.Items.Insert(listBoxStack.Items.Count, machine.M[el]);
                }

                return true;
            }
            else
            {
                // notify user about error, ask for continue/abortation of the process
                return MessageBox.Show(
                    "Wrong input symbol <" + strs[progressBar.Value - 1] + ">, skip?", "Skip?",
                    MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
        }

        #region IPlayable Members

        public void Play()
        {
            machine.Reset();
            progressBar.Value = 0;
            pos = 0;

            PrintAutomat();

            txtOut.Clear();

            machine.Step += new MMAutomat.MMStepDelegate(machine_Step);
            machine.Process(strs, out ss, out oo, out stst);
            machine.Step -= new MMAutomat.MMStepDelegate(machine_Step);

            #region "output: release version" - commented
            //txtOut.Clear();
            //foreach (object s in oo)
            //{
            //    if (s != null)
            //        txtOut.Text += s.ToString() + ' ';
            //}
            #endregion
        }


        public void Step()
        {
            Play();
            //throw new Exception("Need it? Write it!");
        }

        #endregion

        private void bnCheck_Click(object sender, EventArgs e)
        {
            string tmpstr = "";
            foreach (string s in strs)
            {
                if (Array.IndexOf(machine.A, s) != -1)
                    tmpstr += s + " ";
            }
            txtIn.Text = tmpstr;
        }
    }
}