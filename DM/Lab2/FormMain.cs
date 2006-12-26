using System;
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
        Transliterator translit = new Transliterator();

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            Lexema[] lex = translit.Do(textIn.Text);
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

            int[,] njuTab =
{ 
/*1*/{ Array.IndexOf(stats, do2A), Array.IndexOf(stats, doError), Array.IndexOf(stats, do7),Array.IndexOf(stats, doError)},
/*2*/{ Array.IndexOf(stats, do2B), Array.IndexOf(stats, do4A),    Array.IndexOf(stats, do3C),Array.IndexOf(stats, doError)},
/*3*/{ Array.IndexOf(stats, do3A), Array.IndexOf(stats, do4B),    Array.IndexOf(stats, doError),Array.IndexOf(stats, doError)},
/*4*/{ Array.IndexOf(stats, do6A), Array.IndexOf(stats, doError), Array.IndexOf(stats, doError),Array.IndexOf(stats, do5)},
/*5*/{ Array.IndexOf(stats, do6B), Array.IndexOf(stats, doError), Array.IndexOf(stats, doError),Array.IndexOf(stats, doError)},
/*6*/{ Array.IndexOf(stats, do6C), Array.IndexOf(stats, doError), Array.IndexOf(stats, doError),Array.IndexOf(stats, doError)},
/*7*/{ Array.IndexOf(stats, do3B), Array.IndexOf(stats, doError), Array.IndexOf(stats, doError),Array.IndexOf(stats, doError)},
/*e*/{ Array.IndexOf(stats, doError), Array.IndexOf(stats, doError), Array.IndexOf(stats, doError),Array.IndexOf(stats, doError)},
};

            AutomatNumConstParser auto = new AutomatNumConstParser(
                // A
                new object[] {
                    Transliterator.KindOfSymbol.Digit,
                    Transliterator.KindOfSymbol.E,
                    Transliterator.KindOfSymbol.Dot,
                    Transliterator.KindOfSymbol.Sign },
                // Z
                new string[] { "Error", "int", "float", "real" },
                stats,
                njuTab,
                new int[] { 0, 1, 2, 0, 0, 3, 0, 0 });

            object[] whatToDo;
            object[] outsSequence;
            auto.Process(lex, out whatToDo, out outsSequence);

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
                    break;
            }

            textOut.Text = String.Format("Formal: {0}, usual: {1}.",
                formalRepresentation, constant.ToString()
                );
        }

        //private delegate void VoidDelegate();

        #region Actions

        void do1(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            newAutomatStateIndex =1;
        }

        void do2A(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RCh = (byte)lexema.value;
            newAutomatStateIndex = 2;
        }

        void do2B(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RCh *= 10;
            RCh += (byte)lexema.value;
            newAutomatStateIndex = 2;
        }

        void do3A(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RCh *= 10;
            RCh += (byte)lexema.value;
            RS++;
            newAutomatStateIndex = 3;
        }

        void do3B(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RCh = (byte)lexema.value;
            RS++;
            newAutomatStateIndex = 3;
        }

        void do3C(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RS = 0;
            RCh = (byte)lexema.value;
            newAutomatStateIndex = 3;
        }

        void do4A(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RS = 0;
            newAutomatStateIndex = 4;
        }

        void do4B(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            newAutomatStateIndex = 4;
            return;
        }

        void do5(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RZn = ((char)lexema.value == '+' ? 1 : -1);
            newAutomatStateIndex = 5;
        }

        void do6A(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RZn = 1;
            RP = (byte)lexema.value;
            newAutomatStateIndex = 6;
        }

        void do6B(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RP = (byte)lexema.value;
            newAutomatStateIndex = 6;
        }

        void do6C(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RP *= 10;
            RP += (byte)lexema.value;
            newAutomatStateIndex = 6;
        }

        void do7(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            RS = 0;
            newAutomatStateIndex = 7;
        }

        void doError(Lexema lexema, ref int RCh, ref int RP, ref int RS, ref int RZn, out int newAutomatStateIndex)
        {
            MessageBox.Show("— doError invoked.\r\n— So what now?");
            newAutomatStateIndex = 8;
        }

        #endregion
    }
}