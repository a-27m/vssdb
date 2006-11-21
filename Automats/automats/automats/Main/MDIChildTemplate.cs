using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace automats
{
    public partial class MDIChildTemplate : Form, IPlayableMDIChild
    {
        public TerminalAutomat machine;
        private string[] strs;
        protected int pos;
        protected const string delims = " ;,\t";
        protected MDIChildTemplate()
        {
            InitializeComponent();
            //progressBar1.Visible = false;
        }
        public MDIChildTemplate(TerminalAutomat a)
        {
            if (a == null)
                throw new AutomatException("Automat is a 'null'!");
            InitializeComponent();
            machine = a;
            //progressBar.Minimum = 0;
            //progressBar.Step = 1;
            txtIn_TextChanged(null, new EventArgs());
            if (machine != null)
                machine.PrintAutomat(grid);
        }
        protected object[] ss;
        protected object[] oo;
        bool machine_OnStep(int inIndex, int newStateIndex, int outSymbolIndex)
        {
            if (pos < strs.Length)
                pos++;
            else
                return false;

            //progressBar.PerformStep();
            if (inIndex != -1)
            // highlite new cell in grid
            {
                txtOut.Text += machine.Z[outSymbolIndex].ToString() + " ";
                txtStates.Text += machine.S[newStateIndex].ToString() + " ";
                grid.Rows[newStateIndex].Cells[inIndex].Selected = true;

                Application.DoEvents();
                System.Threading.Thread.Sleep(200);


                grid.Rows[newStateIndex].Cells[inIndex].Selected = false;

                return true;
            }
            else
            {
                // notify user about error, ask for continue/abortion of process
                return MessageBox.Show(
                    "Wrong input symbol", "Skip?",// <" + strs[progressBar.Value - 1] + ">, skip?
                    MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
        }

        private void MDIChildTemplate_FormClosing(object sender, FormClosingEventArgs e)
        {
            machine.Step -= machine_OnStep;
        }

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

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string[] newS;
        }

        private void txtIn_TextChanged(object sender, EventArgs e)
        {
            strs = txtIn.Text.Split(delims.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //progressBar.Maximum = strs.Length;
        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // find out what's changed in automat
            // change automat, and say to parent we did it
            //throw new Exception("Editing isn't implemented yet!");
        }

        #region IPlayable Members

        public void Play()
        {
            machine.Reset();
            //progressBar.Value = 0;
            pos = 0;

            txtOut.Clear();
            txtStates.Text = machine.State.ToString() + " ";

            machine.Step += new TerminalStepDelegate(machine_OnStep);
            machine.Process(strs, out ss, out oo);
            machine.Step -= new TerminalStepDelegate(machine_OnStep);

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
            machine.Step += new TerminalStepDelegate(machine_OnStep);
            machine.Process(new object[] { strs[pos] }, out oo, out ss);
            machine.Step -= new TerminalStepDelegate(machine_OnStep);
        }

       #endregion
    }
}