using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataProc;

namespace lab1.Forms {
	public partial class FormAskZnSelection : Form {

		public double a = 0, b = 0;
		public int n = 0;

		public FormAskZnSelection() {
			InitializeComponent();
		}

		private void FormAskRavnomParams_FormClosing(object sender, FormClosingEventArgs e) {
			if ( this.DialogResult != DialogResult.OK ) { return; }
			errorProvider1.Clear();
			if ( !double.TryParse(textA.Text, out a) ) {
				errorProvider1.SetError(textA, "Bad double number A");
				e.Cancel = true;
			}
			if ( !double.TryParse(textB.Text, out b) ) {
				errorProvider1.SetError(textB, "Bad double number B");
				e.Cancel = true;
			}
			if ( !int.TryParse(textN.Text, out n) ) {
				errorProvider1.SetError(textN, "Bad integer number N");
				e.Cancel = true;
			}
		}

		private void buttonOK_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}