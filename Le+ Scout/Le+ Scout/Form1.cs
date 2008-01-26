using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Le__Scout.Properties;

namespace Le__Scout
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = null;
        string connectionStringFormat =
@"Database={0};Data Source={1};Port={2};User Id={3};Password={4}";


        public Form1()
        {
            InitializeComponent();
        }

        private void propDBConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormPropDbConnection().ShowDialog();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings appSettings = new Settings();
            connection = new MySqlConnection( string.Format(connectionStringFormat, 
                "leplus",
                appSettings.DbHostName,
                appSettings.DbHostPort,
                appSettings.DbLogin,
                appSettings.DbPass)
                );

            PrintLog("Connection: " + connection.State.ToString());
            PrintLog("Trying to open...");
            //try
            connection.Open();
            PrintLog("Connection: " + connection.State.ToString());

        }

        private void PrintLog(string text)
        {
            textBoxDebug.Text += string.Format("[{0}] {1}{2}",
                DateTime.Now.ToString("HH:MM:ss.fff"), text, Environment.NewLine
                );
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        //    try

            if (connection != null)
                connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            MySqlDataAdapter adapter;

            command = new MySqlCommand("SELECT * from q where code="+maskedTextBox1.Text, connection);
            adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);//dataSet1, "tab_q");

            dataGridView1.DataSource = table;
            //dataGridView1.DataMember = "tab_q";

            dataGridView1.AutoResizeColumns();
        }
    }
}