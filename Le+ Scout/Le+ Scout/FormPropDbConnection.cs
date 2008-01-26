using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Le__Scout.Properties;

namespace Le__Scout
{
    public partial class FormPropDbConnection : Form
    {
        Settings appSettings = new Settings();
        bool textDbPassIsChanged;

        public FormPropDbConnection()
        {
            InitializeComponent();
        }

        private void FormPropDbConnection_Load(object sender, EventArgs e)
        {
            textBoxHost.Text = appSettings.DbHostName;
            numericUpDownPort.Value = appSettings.DbHostPort;
            textBoxLogin.Text = appSettings.DbLogin;
            textBoxPass.Text = "****";
            textDbPassIsChanged = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            appSettings.DbHostName = textBoxHost.Text;
            appSettings.DbHostPort = (int)numericUpDownPort.Value;
            appSettings.DbLogin = textBoxLogin.Text;
            if (textDbPassIsChanged)
                appSettings.DbPass = textBoxPass.Text;
            textBoxPass.Text = "****";
            appSettings.Save();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxPass_Enter(object sender, EventArgs e)
        {
            if (!textDbPassIsChanged)
                textBoxPass.Text = "";
        }

        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {
            textDbPassIsChanged = true;
        }
    }
}