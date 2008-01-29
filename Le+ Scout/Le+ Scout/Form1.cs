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

        int r_id = -1;

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
            QidByCode(textBox1.Text, dataSet1.Tables["chetab"]);

            //MySqlCommand cmd = new MySqlCommand();
            //MySqlParameter p1 = cmd.CreateParameter();
// ...
// create myDataSet and myDataAdapter
// ...
            /*
            select q.id from q where code=?pcode;
            update q set count = (select count-1 from 
            
            */

            PrintLog("ImportRow done");
        }

        private int Sell(string strCode)
        {
            try
            {
                int code = int.Parse(strCode);
            }
            catch (FormatException)
            {
                PrintLog("[Error] bad code: Int.Parse threw FormatException");
                return;
            }

            DataTable tableToFill;
            tableToFill = new DataTable("tableToFill");

            MySqlDataAdapter adapter;
            adapter = new MySqlDataAdapter(@"select * from q where code=?pcode", connection);
            adapter.SelectCommand.Parameters.AddWithValue("?pcode", code);
            adapter.Fill(tableToFill);

            int n = tableToFill.Rows.Count;
            int q_id = -1;

            #region Determine exact ware q_id
            if (n == 0)
            {
                PrintLog("[Oops] The ware not found by code: count(*) == 0");
                return;
            }

            if (n > 1)
            {
                FormSearch fs = new FormSearch();
                fs.DataGridView1.DataSource = tableToFill;
                if (fs.ShowDialog() != DialogResult.OK)
                {
                    PrintLog("[Abort] Search canceled (fs.ShowDialog != OK)");
                    return;
                }
                q_id = fs.SelectedId;
                fs.Dispose();
            }
            else
            {
                q_id = tableToFill.Rows[0].ItemArray[0];
            }
            #endregion

            DataRow wareRow = tableToFill.Rows.Find(q_id);
            dataSet1.Tables["chetab"].Rows.Add(wareRow);
            //dataGridView1.AutoResizeColumns();

            // Focus on kol-vo
            dataGridView1["count", dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Visible)];
            //dataGridView1.BeginEdit(true);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectToolStripMenuItem_Click(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Sell(textBox1.Text);
            }
        }

        private void buttonNewReceipt_Click(object sender, EventArgs e)
        {
            if (r_id != -1)
            {
                PrintLog("[Warning] r_id <> -1");
                // ask to interrupt or complete current receipt
            }

            MySqlCommand cmdStartSell = new MySqlCommand("start_sell", connection);
            cmdStartSell.CommandType = CommandType.StoredProcedure;
            cmdStartSell.Parameters.Add("?rv", MySqlDbType.Int32).Direction =
                ParameterDirection.ReturnValue;
            cmdStartSell.ExecuteNonQuery();
            r_id = (int)cmdStartSell.Parameters["?rv"].Value;
            PrintLog("Start sell returned:" + r_id);
        }
    }
}