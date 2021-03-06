using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab1
{
    public partial class FormMain : Form
    {
        Transliterator translit;

        public FormMain()
        {
            InitializeComponent();
            translit = new Transliterator();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
			listIdentificators.Items.Clear();
			listNumbers.Items.Clear();
			listSigns.Items.Clear();
		
            translit.DoAsync(textIn.Text, new AsyncCallback(TransDone));
        }

        private delegate void VoidDelegate();

        private void TransDone(IAsyncResult iar)
        {
            Transliterator.TranslitResult tiar =
                iar as Transliterator.TranslitResult;

            this.BeginInvoke(new VoidDelegate(delegate
            {
                textOut.Text = tiar.AsyncState as String;

                PrintDictonaryToListBox(listIdentificators,
                    translit.NameTableIdentificators);
                PrintDictonaryToListBox(listNumbers, translit.NameTableNumbers);
                PrintDictonaryToListBox(listSigns, translit.NameTableOther);
            }));
        }

        private void PrintDictonaryToListBox(ListBox listBox,
            Dictionary<string, string> dictionary)
        {
            foreach (string key in dictionary.Keys)
                listBox.Items.Add(key + " ~ " + dictionary[key]);
        }
    }
}