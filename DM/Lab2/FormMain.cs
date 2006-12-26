using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyTypes;
using automats;

namespace Lab2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            Lexema[] lex = Transliterator.Do(textIn.Text, true);

            textOut.Clear();

            ActionOnLexem[] stats = {
                do1,
                do2A, do2B,
                do3A, do3B, do3C,
                do4A, do4B,
                do5,
                do6A, do6B, do6C,
                do7,
                doError };

            #region transitions table initialization

            int[,] njuTab =
{
/*(0) 1*/{ Array.IndexOf(stats, do2A), Array.IndexOf(stats, doError), Array.IndexOf(stats, do7),Array.IndexOf(stats, doError)},
/*(1) 2*/{ Array.IndexOf(stats, do2B), Array.IndexOf(stats, do4A),    Array.IndexOf(stats, do3C),Array.IndexOf(stats, doError)},
/*(2) 3*/{ Array.IndexOf(stats, do3A), Array.IndexOf(stats, do4B),    Array.IndexOf(stats, doError),Array.IndexOf(stats, doError)},
/*(3) 4*/{ Array.IndexOf(stats, do6A), Array.IndexOf(stats, doError), Array.IndexOf(stats, doError),Array.IndexOf(stats, do5)},
/*(4) 5*/{ Array.IndexOf(stats, do6B), Array.IndexOf(stats, doError), Array.IndexOf(stats, doError),Array.IndexOf(stats, doError)},
/*(5) 6*/{ Array.IndexOf(stats, do6C), Array.IndexOf(stats, doError), Array.IndexOf(stats, doError),Array.IndexOf(stats, doError)},
/*(6) 7*/{ Array.IndexOf(stats, do3B), Array.IndexOf(stats, doError), Array.IndexOf(stats, doError),Array.IndexOf(stats, doError)},
/*(7) e*/{ Array.IndexOf(stats, doError), Array.IndexOf(stats, doError), Array.IndexOf(stats, doError),Array.IndexOf(stats, doError)},
};
            #endregion

            AutomatNumConst auto = new AutomatNumConst(
                // A
                new object[] {
                    new Lexema(Transliterator.KindOfSymbol.Digit, null),
                    new Lexema(Transliterator.KindOfSymbol.E, null),
                    new Lexema(Transliterator.KindOfSymbol.Dot, null),
                    new Lexema(Transliterator.KindOfSymbol.Sign,null)},
                // Z
                new string[] { "error", "int", "float", "real" },
                // S
                stats,
                // nju
                njuTab,
                // zeta
                new int[] { 0, 1, 2, 0, 0, 3, 0, 0 }
                );

            object[] whatsDone;
            object[] outsSequence;

            auto.StateIndex = 0;
            StepCount =1;
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = 10;
            auto.Step += new TerminalStepDelegate(auto_Step);
            auto.Process(lex, out whatsDone, out outsSequence);

            object constant = null;
            string formalRepresentation = "";

            switch (outsSequence[outsSequence.Length - 1] as string)
            {
                case "int":
                    constant = auto.РЧ;
                    formalRepresentation = auto.РЧ.ToString();
                    break;

                case "float":
                    auto.РП = -auto.РС;
                    constant = auto.РЧ * Math.Pow(10, auto.РП);
                    formalRepresentation =
                        String.Format("{0}*10^{1}", auto.РЧ, auto.РП);
                    break;

                case "real":
                    auto.РП -= auto.РС;
                    constant = auto.РЧ * (int)(Math.Pow(10, auto.РЗ * auto.РП));
                    formalRepresentation =
                        String.Format("{0}*10^{1}", auto.РЧ, auto.РП);
                    break;
                default:
                    MessageBox.Show("Cannot parse constant", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
            }

            textOut.Text = String.Format("{0} (={1}).",
                formalRepresentation, constant.ToString()
                );
        }

        static int StepCount;
        bool auto_Step(int inIndex, int newStateIndex, int outSymbolIndex)
        {
            //dataGridView1.RowCount = dataGridView1.RowCount + 1;
            //++Add();
            dataGridView1["Step", dataGridView1.Rows.Count-1].Value = StepCount++;
            return true;
        }

        //private delegate void VoidDelegate();

        #region Actions

        void do1(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            newAutomatStateIndex = 1 - 1;
        }

        void do2A(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RCh = (byte)lexema.value;
            newAutomatStateIndex = 2 - 1;
        }

        void do2B(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RCh *= 10;
            RCh += (byte)lexema.value;
            newAutomatStateIndex = 2 - 1;
        }

        void do3A(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RCh *= 10;
            RCh += (byte)lexema.value;
            RS++;
            newAutomatStateIndex = 3 - 1;
        }

        void do3B(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RCh = (byte)lexema.value;
            RS++;
            newAutomatStateIndex = 3 - 1;
        }

        void do3C(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RS = 0;
            newAutomatStateIndex = 3 - 1;
        }

        void do4A(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RS = 0;
            newAutomatStateIndex = 4 - 1;
        }

        void do4B(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            newAutomatStateIndex = 4 - 1;
            return;
        }

        void do5(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RZn = ((char)lexema.value == '+' ? 1 : -1);
            newAutomatStateIndex = 5 - 1;
        }

        void do6A(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RZn = 1;
            RP = (byte)lexema.value;
            newAutomatStateIndex = 6 - 1;
        }

        void do6B(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RP = (byte)lexema.value;
            newAutomatStateIndex = 6 - 1;
        }

        void do6C(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RP *= 10;
            RP += (byte)lexema.value;
            newAutomatStateIndex = 6 - 1;
        }

        void do7(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RS = 0;
            newAutomatStateIndex = 7 - 1;
        }

        void doError(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            //MessageBox.Show("— doError invoked.\r\n— So what now?");
            newAutomatStateIndex = 8 - 1;
        }

        #endregion
    }
}