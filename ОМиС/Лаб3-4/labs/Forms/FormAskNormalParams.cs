using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataProc;

namespace lab1.Forms {
	public partial class FormAskNormalParams : Form {

		public double a = 0, σ = 1;
		public int n = 10;

		public FormAskNormalParams() {
			InitializeComponent();
		}

		private void FormAskNormalParams_Load(object sender, EventArgs e) {
			textA.Text = a.ToString();
			textSigma.Text = σ.ToString();
			textN.Text = n.ToString();
		}

		private void FormAskNormalParams_FormClosing(object sender, FormClosingEventArgs e) {
			if ( this.DialogResult != DialogResult.OK ) { return; }
			errorProvider1.Clear();
			if ( !double.TryParse(textA.Text, out a) ) {
				errorProvider1.SetError(textA, "Bad double number");
				e.Cancel = true;
			}
			if ( !double.TryParse(textSigma.Text, out σ) ) {
				errorProvider1.SetError(textSigma, "Bad double number");
				e.Cancel = true;
			}
			if ( !int.TryParse(textN.Text, out n) ) {
				errorProvider1.SetError(textN, "Bad integer number");
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