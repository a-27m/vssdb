using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataProc;

namespace lab1.Forms {
	public partial class FormAskExpParams : Form {

		public double λ= 1;
		public int n = 10;

		public FormAskExpParams() {
			InitializeComponent();
		}

		private void FormAskExpParams_Load(object sender, EventArgs e) {
			textLambda.Text = λ.ToString();
			textN.Text = n.ToString();
		}

		private void FormAskExpParams_FormClosing(object sender, FormClosingEventArgs e) {
			if ( this.DialogResult != DialogResult.OK ) { return; }
			errorProvider1.Clear();
			if ( !double.TryParse(textLambda.Text, out λ) ) {
				errorProvider1.SetError(textLambda, "Bad double number");
				e.Cancel = true;
			}
			if ( Math.Abs(λ)<double.Epsilon ) {
				errorProvider1.SetError(textLambda, "Cannot be zero");
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