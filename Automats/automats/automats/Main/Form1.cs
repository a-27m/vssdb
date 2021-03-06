using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using automats.Main;

namespace automats
{
    public partial class Form1 : Form
    {
        MinimizationPiClasses minimizationShower;
        /// <summary>Default window constructor</summary>
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            minimizationShower = new MinimizationPiClasses(this);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Automat auto = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form child = null;

                object[] A;
                object[] Z;
                object[] S;
                int[,] ν;
                //int[,] ζ;

                // reading automat
                try
                {
                    StreamReader file = new StreamReader(openFileDialog1.FileName);
                    string type = GetSplittedLine(file)[0];
                    A = GetSplittedLine(file);
                    Z = GetSplittedLine(file);
                    S = GetSplittedLine(file);
                    switch (type)
                    {
                        case "MM":
                            #region Stack-memory automat loading
                            object[] M;
                            int[][,] MDev;
                            List<MMAutomatAct[]> rulesList;
                            ReadMMFromFile(A.Length, S.Length, file, out M, out MDev, out rulesList);

                            auto = new MMAutomat(A, Z, S, M, MDev, rulesList.ToArray());
                            child = new MMAutomatChlid((MMAutomat)auto);
                            (child as MMAutomatChlid).machine.Step +=new MMAutomat.MMStepDelegate(machine_Step);
                            #endregion
                            break;
                        case "Mili":
                            ν = TableRead(file, S.Length, A.Length);
                            auto = new AutomatMili(A, Z, S, ν,
                                TableRead(file, S.Length, A.Length));
                            child = new MDIChildTemplate((TerminalAutomat)auto);
                            (child as MDIChildTemplate).machine.Step += new TerminalStepDelegate(machine_Step);
                            break;
                        case "Mura":
                            ν = TableRead(file, S.Length, A.Length);
                            auto = new AutomatMura(A, Z, S, ν,
                                TableRead(file, S.Length));
                            child = new MDIChildTemplate((TerminalAutomat)auto);
                            break;
                        default:
                            break;
                    }
                }
                catch (IOException excp)
                {
                    MessageBox.Show(excp.Message);
                    return;
                }

                if (child == null)
                    return;
                child.MdiParent = this;
                child.Text = openFileDialog1.FileName;
                child.Show();
            }
        }

        private void ReadMMFromFile(int ALength, int SLength, StreamReader file, out object[] M, out int[][,] MDev, out List<MMAutomatAct[]> rulesList)
        {
            M = GetSplittedLine(file);
            MDev = new int[SLength][,];

            for (int s = 0; s < SLength; s++)
                MDev[s] = TableRead(file, M.Length, ALength);

            rulesList = new List<MMAutomatAct[]>();
            List<MMAutomatAct> ruleActs = new List<MMAutomatAct>();

            // reads first rule title (e.g. ";Rule;1;")
            string[] line = GetSplittedLine(file);

            while (!file.EndOfStream)
            {
                line = GetSplittedLine(file);
                if (line[0].ToUpper() == "RULE")
                {
                    // new rule reading start
                    rulesList.Add(ruleActs.ToArray());
                    ruleActs.Clear();
                }

                int[] args;

                if (line == null)
                    continue;

                if (line.Length > 1)
                {
                    args = new int[line.Length - 1];

                    try
                    {
                        for (int j = 0; j < line.Length - 1; j++)
                            args[j] = int.Parse(line[j + 1]);
                    }
                    catch (FormatException)
                    {
                        throw new AutomatException(
                            "Automat loadig error: not an index in operation arguments");
                    }
                }
                else
                {
                    args = null;
                }

                for (int i = 0; i < MMAutomat.RulesNames.Length; i++)
                {
                    if (line[0].ToUpper() == MMAutomat.RulesNames[i])
                    {
                        ruleActs.Add(new MMAutomatAct((MMAutomatActTypes)i, args));
                        break;
                    }
                }

            }
            if (ruleActs.Count > 0)
                rulesList.Add(ruleActs.ToArray());
        }

        bool machine_Step(int inSymbol, int newStateIndex, int outSymbolIndex, int[] stackState, int[] transIndex)
        {
            toolStripProgressBar1.PerformStep();
            return true;           
        }

        bool machine_Step(object inIndex, int newStateIndex, int outSymbolIndex)
        {
            toolStripProgressBar1.PerformStep();
            return true;
        }


        private int[] TableRead(StreamReader file, int len)
        {
            int[] line = new int[len];

            string[] splited = GetSplittedLine(file);
            if (splited.Length != len)
                throw new AutomatException("Automat file loadig error: wrong table size!");
            try
            {
                for (int j = 0; j < len; j++)
                    line[j] = int.Parse(splited[j]);
            }
            catch (FormatException)
            {
                throw new AutomatException("Automat file loadig error: wrong index in table!");
            }
            return line;
        }

        private int[,] TableRead(StreamReader file, int rows, int cols)
        {
            int[,] table = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] ln = TableRead(file, cols);
                for (int j = 0; j < cols; j++)
                    table[i, j] = ln[j];
            }
            return table;
        }

        private string[] GetSplittedLine(StreamReader file)
        {
            string line;
            string[] splitted;

            do
            {
                do
                {
                    if (file.EndOfStream)
                        return null;
                    line = file.ReadLine();
                }
                while (IsComment(line));

                char[] delims = new char[] { ' ', '\t' };
                StringSplitOptions opt = StringSplitOptions.RemoveEmptyEntries;
                splitted = line.Split(delims, opt);
            } while (splitted.Length <= 0);
            return splitted;
        }

        private bool IsComment(string line)
        {
            if ((line.IndexOf("//") == 0) || (line.Length == 0))
                return true;
            return false;
        }

        private void playToolBn_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                toolStripBnStart.Enabled = false;
                ((IPlayableMDIChild)ActiveMdiChild).Play();
                toolStripBnStart.Enabled = true;
            }
        }

        private void stepToolBn_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                toolStripBnStart.Enabled = false;
                ((IPlayableMDIChild)ActiveMdiChild).Step();
                toolStripBnStart.Enabled = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolBn_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog(this);
        }

        private void saveToolBn_Click(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void minimizeToolBn_Click(object sender, EventArgs e)
        {
            if ((ActiveMdiChild is MDIChildTemplate) && (ActiveMdiChild != null))
            {
                TerminalAutomat min, old =
                    ((MDIChildTemplate)ActiveMdiChild).machine;


                if (minimizationShower.Visible)
                {
                    minimizationShower.Clear();
                }
                else
                {
                    minimizationShower = new MinimizationPiClasses(this);
                }

                old.ClassesChanged += min_ClassesChanged;
                min = old.GetMinimized();
                old.ClassesChanged -= min_ClassesChanged;

                MDIChildTemplate child = new MDIChildTemplate(min);
                child.MdiParent = this;
                child.Text = "Minimized automat " +
                    ((MDIChildTemplate)ActiveMdiChild).Text;

                child.Show();
                minimizationShower.Show();
                minimizationShower.Left = Right - minimizationShower.Width;
            }
        }

        void min_ClassesChanged(List<List<int>> Classes, object[] States)
        {
            if (minimizationShower != null)
            {
                string item = "";

                foreach (List<int> list in Classes)
                {
                    item += "{ ";
                    foreach (int state in list)
                    {
                        item += States[state].ToString() + ' ';
                    }
                    item += "} ";
                }

                minimizationShower.AddLine(item);
                minimizationShower.Update();
            }
        }
    }
}


//"SHIFT":
//    case RulesNames[1]:
//        rulesList.Add(new MMAutomatRule(MMAutomatRuleTypes.Shift, null));
//        break;
//    //"PUSH":
//    case RulesNames[2]:
//        rulesList.Add(new MMAutomatRule());
//        break;
//    //"POP":
//    case RulesNames[3]:
//        rulesList.Add(new MMAutomatRule(MMAutomatRuleTypes.PopHold, null));
//        break;
//    //"REJECT":
//    case RulesNames[4]:
//        rulesList.Add(new MMAutomatRule(MMAutomatRuleTypes.Reject, null));
//        break;
//    //"ACCEPT":
//    case RulesNames[5]:
//        rulesList.Add(new MMAutomatRule(MMAutomatRuleTypes.Accept, null));
//        break;
//    //"REPLACE":
//    case RulesNames[6]:
//        rulesList.Add(new MMAutomatRule());
//        break;

//    default:
//        break;
//}
